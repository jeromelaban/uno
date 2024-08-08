﻿#nullable enable

using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.Storage;
using Uno;
using Uno.Foundation.Logging;
using Uno.UI;
using System.Collections.Generic;
using Windows.System.UserProfile;
using System.Diagnostics.CodeAnalysis;

namespace Windows.Globalization;

public static partial class ApplicationLanguages
{
	private static string? _primaryLanguageOverride = string.Empty;

#if !IS_UNIT_TESTS
	private const string PrimaryLanguageOverrideSettingKey = "__Uno.PrimaryLanguageOverride";
#endif

	public static string? PrimaryLanguageOverride
	{
		get => _primaryLanguageOverride;
		set
		{
			value ??= string.Empty;
			if (_primaryLanguageOverride != value)
			{
				typeof(ApplicationLanguages).Log().LogDebug($"PLO: {_primaryLanguageOverride} -> {value}");
				_primaryLanguageOverride = value;

				ApplyLanguages();
				if (WinRTFeatureConfiguration.ApplicationLanguages.UseLegacyPrimaryLanguageOverride)
				{
					ApplyCulture();
				}

#if !IS_UNIT_TESTS
				ApplicationData.Current.LocalSettings.Values[PrimaryLanguageOverrideSettingKey] = _primaryLanguageOverride;
#endif
			}
		}
	}

	public static IReadOnlyList<string> Languages { get; private set; }
	public static IReadOnlyList<string> ManifestLanguages { get; }

	static ApplicationLanguages()
	{
#if !IS_UNIT_TESTS
		if (ApplicationData.Current.LocalSettings.Values.TryGetValue(PrimaryLanguageOverrideSettingKey, out var savedValue) &&
			savedValue is string stringSavedValue)
		{
			_primaryLanguageOverride = stringSavedValue;
		}
#endif

		ManifestLanguages = GetManifestLanguages();
		ApplyLanguages();
	}

	internal static void ApplyCulture()
	{
		var primaryLanguageOverride = PrimaryLanguageOverride;
		if (!string.IsNullOrEmpty(primaryLanguageOverride))
		{
			if (typeof(ApplicationLanguages).Log().IsEnabled(LogLevel.Debug))
			{
				typeof(ApplicationLanguages).Log().Debug($"Using {primaryLanguageOverride} (from PrimaryLanguageOverride) as primary language");
			}

			setCulture(primaryLanguageOverride);
		}
		else if (Languages.Count > 0)
		{
			var language = Languages[0];
			if (typeof(ApplicationLanguages).Log().IsEnabled(LogLevel.Debug))
			{
				typeof(ApplicationLanguages).Log().Debug($"Using {language} (from Languages) as primary language");
			}

			setCulture(language);
		}
		else
		{
			if (typeof(ApplicationLanguages).Log().IsEnabled(LogLevel.Warning))
			{
				typeof(ApplicationLanguages).Log().Warn($"Unable to determine the default culture, using invariant culture");
			}
		}

		static void setCulture(string cultureId)
		{
			var culture = CreateCulture(cultureId);
			CultureInfo.CurrentCulture = culture;
			CultureInfo.DefaultThreadCurrentCulture = culture;
			CultureInfo.CurrentUICulture = culture;
			CultureInfo.DefaultThreadCurrentUICulture = culture;
		}
	}

#if !__IOS__
	private static string[] GetManifestLanguages()
	{
		string AdjustCultureName(string? name)
			=> string.IsNullOrEmpty(name) ? "en-US" : name;

		var languages = new[]
		{
#if __ANDROID__
			ContextHelper.Current?.Resources?.Configuration?.Locales?.Get(0)?.ToLanguageTag(),
#endif
			AdjustCultureName(CultureInfo.InstalledUICulture?.Name),
			AdjustCultureName(CultureInfo.CurrentUICulture?.Name),
			AdjustCultureName(CultureInfo.CurrentCulture?.Name)
		};

		return languages
			.Where(l => !string.IsNullOrWhiteSpace(l))
			.OfType<string>()
			.Distinct()
			.ToArray();
	}
#else
	private static string[] GetManifestLanguages()
	{
		var manifestLanguages = global::Foundation.NSLocale.PreferredLanguages
			.Concat(global::Foundation.NSBundle.MainBundle.PreferredLocalizations)
			.Concat(global::Foundation.NSBundle.MainBundle.Localizations)
			.Distinct()
			.ToArray();

		return manifestLanguages;
	}
#endif

	[MemberNotNull(nameof(Languages))]
	private static void ApplyLanguages()
	{
#if false
		Languages = GlobalizationPreferences.Languages
			.Cast<string?>()
			.Prepend(PrimaryLanguageOverride)
			.Where(x => !string.IsNullOrEmpty(x))
			.OfType<string>()
#if false // On windows, we would filter against ManifestLanguages, but it does not apply to other targets.
			.Intersect(ManifestLanguages, FastBaseCultureComparer.Instance)
#endif
			.ToArray();
#else
		var languages = ManifestLanguages;
#if __SKIA__
		if (OperatingSystem.IsWindows() && GlobalizationPreferences.Languages is { Count: > 0 } preferences)
		{
			languages = preferences;
		}
#endif

		var overriddenLanguage = PrimaryLanguageOverride;
		if (!string.IsNullOrWhiteSpace(overriddenLanguage))
		{
			languages = languages
				.Prepend(overriddenLanguage)
				.Distinct()
				.ToArray();
		}

		Languages = languages;
#endif
	}

	private static Regex? _cultureFormatRegex;

	private static CultureInfo CreateCulture(string cultureId)
	{
		try
		{
			return new CultureInfo(cultureId);
		}
		catch (CultureNotFoundException)
		{
			_cultureFormatRegex ??= CultureRegex();

			var match = _cultureFormatRegex.Match(cultureId);
			try
			{
				// If the script subtag is specified, we'll try to just remove it.
				// Mono is not supporting it.
				if (match.Groups["script"].Success && match.Groups["reg"].Success)
				{
					cultureId = $"{match.Groups["lang"].Value}-{match.Groups["reg"].Value}";
					return new CultureInfo(cultureId);
				}
			}
			catch (CultureNotFoundException)
			{
			}

			// If the runtime is not able to match the language + region, we'll fallback to just the language.
			if (match.Groups["lang"].Success)
			{
				return new CultureInfo(match.Groups["lang"].Value);
			}

			// It seems not possible to resolve this culture.
			throw;
		}
	}

	[GeneratedRegex(@"(?<lang>[a-z]{2,8})(?:(?:\-(?<script>[a-zA-Z]+))?\-(?<reg>[A-Z]+))?", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.CultureInvariant)]
	private static partial Regex CultureRegex();
}
