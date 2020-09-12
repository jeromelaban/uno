using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Uno;
using _Calendar = global::System.Globalization.Calendar;

namespace Windows.Globalization
{
	public partial class Calendar
	{
		#region Static id parsing helpers
		private static _Calendar GetCalendar(string calendar)
		{
			switch (calendar)
			{
				case CalendarIdentifiers.JulianValue: return new global::System.Globalization.JulianCalendar();
				case CalendarIdentifiers.GregorianValue: return new global::System.Globalization.GregorianCalendar();
				case CalendarIdentifiers.HebrewValue: return new global::System.Globalization.HebrewCalendar();
				case CalendarIdentifiers.HijriValue: return new global::System.Globalization.HijriCalendar();
				case CalendarIdentifiers.JapaneseValue: return new global::System.Globalization.JapaneseCalendar();
				case CalendarIdentifiers.KoreanValue: return new global::System.Globalization.KoreanCalendar();
				case CalendarIdentifiers.TaiwanValue: return new global::System.Globalization.TaiwanCalendar();
				case CalendarIdentifiers.ThaiValue: return new global::System.Globalization.ThaiBuddhistCalendar();
				case CalendarIdentifiers.UmAlQuraValue: return new global::System.Globalization.UmAlQuraCalendar();
				case CalendarIdentifiers.PersianValue: return new global::System.Globalization.PersianCalendar();
				case CalendarIdentifiers.ChineseLunarValue: return new global::System.Globalization.ChineseLunisolarCalendar();

				// Not supported by UWP as of 2019-05-23
				// https://docs.microsoft.com/en-us/uwp/api/windows.globalization.calendaridentifiers
				// case CalendarIdentifiers.VietnameseLunarValue: return new global::System.Globalization.VietnameseLunarCalendar();
				// case CalendarIdentifiers.TaiwanLunarValue: return new global::System.Globalization.TaiwanLunarCalendar();
				// case CalendarIdentifiers.KoreanLunarValue: return new global::System.Globalization.KoreanLunarCalendar();
				// case CalendarIdentifiers.JapaneseLunarValue: return new global::System.Globalization.JapaneseLunarCalendar();

				default: throw new ArgumentException(nameof(calendar));
			}
		}

		private static string GetCalendarSystem(_Calendar calendar)
		{
			switch (calendar)
			{
				case global::System.Globalization.JulianCalendar _: return CalendarIdentifiers.Julian;
				case global::System.Globalization.GregorianCalendar _: return CalendarIdentifiers.Gregorian;
				case global::System.Globalization.HebrewCalendar _: return CalendarIdentifiers.Hebrew;
				case global::System.Globalization.HijriCalendar _: return CalendarIdentifiers.Hijri;
				case global::System.Globalization.JapaneseCalendar _: return CalendarIdentifiers.Japanese;
				case global::System.Globalization.KoreanCalendar _: return CalendarIdentifiers.Korean;
				case global::System.Globalization.TaiwanCalendar _: return CalendarIdentifiers.Taiwan;
				case global::System.Globalization.ThaiBuddhistCalendar _: return CalendarIdentifiers.Thai;
				case global::System.Globalization.UmAlQuraCalendar _: return CalendarIdentifiers.UmAlQura;
				case global::System.Globalization.PersianCalendar _: return CalendarIdentifiers.Persian;
				case global::System.Globalization.ChineseLunisolarCalendar _: return CalendarIdentifiers.ChineseLunar;

				// Not supported by UWP as of 2019-05-23
				// https://docs.microsoft.com/en-us/uwp/api/windows.globalization.calendaridentifiers
				// case CalendarIdentifiers.VietnameseLunar: return new global::System.Globalization.VietnameseLunarCalendar();
				// case CalendarIdentifiers.TaiwanLunar: return new global::System.Globalization.TaiwanLunarCalendar();
				// case CalendarIdentifiers.KoreanLunar: return new global::System.Globalization.KoreanLunarCalendar();
				// case CalendarIdentifiers.JapaneseLunar: return new global::System.Globalization.JapaneseLunarCalendar();

				default: throw new ArgumentException(nameof(calendar));
			}
		}

		private static string GetDefaultClock()
		{
			// Windows.System.UserProfile.GlobalizationPreferences.Clocks.FirstOrDefault();
			return new DateTime(1983, 9, 9, 13, 0, 0).ToString("g", CultureInfo.CurrentCulture).Contains("PM")
				? ClockIdentifiers.TwelveHour
				: ClockIdentifiers.TwentyFourHour;
		}

		private static string GetClock(string clock)
		{
			switch(clock)
			{
				case ClockIdentifiers.TwelveHourValue:
				case ClockIdentifiers.TwentyFourHourValue:
					return clock;

				default: throw new ArgumentException(nameof(clock));
			}
		}
		#endregion

		private IReadOnlyList<string> _languages;
		private _Calendar _calendar;
		private TimeZoneInfo _timeZone;
		private string _clock;
		private DateTimeOffset _time;

		public Calendar()
		{
			_languages = new string[1] { CultureInfo.CurrentCulture.IetfLanguageTag };
			_calendar = CultureInfo.CurrentCulture.Calendar;
			_timeZone = TimeZoneInfo.Local;
			_clock = GetDefaultClock();
			_time = DateTimeOffset.Now;
		}

		public Calendar(IEnumerable<string> languages)
		{
			_languages = languages.ToList();
			_calendar = CultureInfo.CurrentCulture.Calendar;
			_timeZone = TimeZoneInfo.Local;
			_clock = GetDefaultClock();
			_time = DateTimeOffset.Now;
		}

		public Calendar(IEnumerable<string> languages, string calendar, string clock)
		{
			_languages = languages.ToList();
			_calendar = GetCalendar(calendar);
			_timeZone = TimeZoneInfo.Local;
			_clock = GetClock(clock);
			_time = DateTimeOffset.Now;
		}

		[NotImplemented]
		public Calendar(IEnumerable<string> languages, string calendar, string clock, string timeZoneId)
		{
			// timeZoneId are expected to follow the Olson code which is not easily accessible

			global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.Calendar", "Calendar.Calendar(IEnumerable<string> languages, string calendar, string clock, string timeZoneId)");

			// _languages = languages.ToList();
			//_calendar = GetCalendar(calendar);
			//_timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId); // <== this is not valid, as it expect the windows timezone id
			//_clock = GetClock(clock);
			//_time = new DateTimeOffset(DateTime.UtcNow, _timeZone.BaseUtcOffset);
		}

		private Calendar(IReadOnlyList<string> languages, _Calendar calendar, TimeZoneInfo timeZone, string clock, DateTimeOffset time)
		{
			_languages = languages;
			_calendar = calendar;
			_timeZone = timeZone;
			_clock = clock;
			_time = time;
		}

		public void CopyTo(Calendar other)
		{
			other._languages = _languages;
			other._calendar = _calendar;
			other._timeZone = _timeZone;
			other._clock = _clock;
			other._time = _time;
		}

		public Calendar Clone()
			=> new Calendar(_languages, _calendar, _timeZone, _clock, _time);

		#region Read / Write settings (_languages, _calendar, _clock, _timeZone)
		public string NumeralSystem
		{
			[NotImplemented] get => throw new global::System.NotImplementedException("The member string Calendar.NumeralSystem is not implemented in Uno.");
			[NotImplemented] set => global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.Calendar", "string Calendar.NumeralSystem");
		}

		public IReadOnlyList<string> Languages => _languages;

		public string ResolvedLanguage => _languages[0];

		public string GetCalendarSystem()
			=> GetCalendarSystem(_calendar);

		public void ChangeCalendarSystem(string value)
			=> _calendar = GetCalendar(value);

		public string GetClock()
			=> _clock;

		public void ChangeClock(string value)
			=> _clock = GetClock(value);

		[NotImplemented]
		public string GetTimeZone()
			=> throw new global::System.NotImplementedException("The member string Calendar.GetTimeZone() is not implemented in Uno.");

		[NotImplemented]
		public void ChangeTimeZone(string timeZoneId)
			=> global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.Calendar", "void Calendar.ChangeTimeZone(string timeZoneId)");
		#endregion

		#region Read / Write _time
		public int Era
		{
			get => _calendar.GetEra(_time.DateTime);
			[NotImplemented] set => global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.Calendar", "int Calendar.Era");
		}

		public int Year
		{
			get => _calendar.GetYear(_time.DateTime);
			set => AddYears(value - Year);
		}

		public int Month
		{
			get => _calendar.GetMonth(_time.DateTime);
			set => AddMonths(value - Month);
		}

		public global::Windows.Globalization.DayOfWeek DayOfWeek => (global::Windows.Globalization.DayOfWeek)_calendar.GetDayOfWeek(_time.DateTime);

		public int Day
		{
			get => _calendar.GetDayOfMonth(_time.DateTime);
			set => AddDays(value - Day);
		}

		public int Hour
		{
			get
			{
				var hour = _calendar.GetHour(_time.DateTime);

				if(hour < 12 || _clock == ClockIdentifiers.TwentyFourHour)
				{
					return hour;
				}
				else
				{
					return hour - 11;
				}
			}

			set => AddHours(value - Hour);
		}

		public int Minute
		{
			get => _calendar.GetMinute(_time.DateTime);
			set => AddMinutes(value - Minute);
		}

		public int Second
		{
			get => _calendar.GetSecond(_time.DateTime);
			set => AddSeconds(value - Second);
		}

		public int Period
		{
			get => _clock == ClockIdentifiers.TwentyFourHour || _time.Hour < 12 ? 1 : 2;
			set
			{
				switch(value)
				{
					case 1 when _clock == ClockIdentifiers.TwentyFourHour:
						break;

					case 1 when _clock == ClockIdentifiers.TwelveHour && _time.Hour < 12:
						break;

					case 1 when _clock == ClockIdentifiers.TwelveHour:
						AddHours(-12);
						break;

					case 2 when _clock == ClockIdentifiers.TwentyFourHour && _time.Hour < 12:
						AddHours(12);
						break;

					case 2 when _clock == ClockIdentifiers.TwentyFourHour:
						break;

					default:
						throw new ArgumentOutOfRangeException(nameof(value));
				}
			}
		}

		public int Nanosecond
		{
			get => (int)(_calendar.GetMilliseconds(_time.DateTime) * 1000);
			set => AddNanoseconds(value - Nanosecond);
		}

		public void SetDateTime(global::System.DateTimeOffset value)
			=> _time = value;

		public void SetToNow()
			=> _time = DateTime.Now;

		public void SetToMin()
			=> _time = DateTimeOffset.MinValue;

		public void SetToMax()
			=> _time = DateTimeOffset.MaxValue;

		public DateTimeOffset GetDateTime()
			=> _time;

		[NotImplemented]
		public void AddEras(int eras)
			=> global::Windows.Foundation.Metadata.ApiInformation.TryRaiseNotImplemented("Windows.Globalization.Calendar", "void Calendar.AddEras(int eras)");

		public void AddYears(int years)
			=> _time = _time.AddYears(years);

		public void AddMonths(int months)
			=> _time = _time.AddMonths(months);

		public void AddWeeks(int weeks)
			=> _time = _time.AddDays(weeks * 7);

		public void AddDays(int days)
			=> _time = _time.AddDays(days);

		public void AddPeriods(int periods)
			=> AddHours((_clock == ClockIdentifiers.TwentyFourHour ? 24 : 12) * periods);

		public void AddHours(int hours)
			=> _time = _time.AddHours(hours);

		public void AddMinutes(int minutes)
			=> _time = _time.AddMinutes(minutes);

		public void AddSeconds(int seconds)
			=> _time = _time.AddSeconds(seconds);

		public void AddNanoseconds(int nanoseconds)
				=> _time = _time.AddMilliseconds(nanoseconds / 1000d);
		#endregion

		#region IComparable
		public int Compare(global::Windows.Globalization.Calendar other)
			=> _time.CompareTo(other._time);

		public int CompareDateTime(global::System.DateTimeOffset other)
			=> _time.CompareTo(other);
		#endregion

		#region Read _calendar properties !! not implemenated !!
		[NotImplemented] public bool IsDaylightSavingTime => throw new global::System.NotImplementedException("The member bool Calendar.IsDaylightSavingTime is not implemented in Uno.");

		public int NumberOfEras => _calendar.Eras.Length;
		public int NumberOfYearsInThisEra => LastYearInThisEra - FirstYearInThisEra;
		public int NumberOfMonthsInThisYear => _calendar.GetMonthsInYear(Year, Era);
		public int NumberOfDaysInThisMonth => _calendar.GetDaysInMonth(Year, Month, Era);
		public int NumberOfPeriodsInThisDay => _clock == ClockIdentifiers.TwentyFourHour ? 1 : 2;
		public int NumberOfHoursInThisPeriod => _clock == ClockIdentifiers.TwentyFourHour ? 24 : 12;
		public int NumberOfMinutesInThisHour => 60;
		public int NumberOfSecondsInThisMinute => 60;

		public int FirstEra => _calendar.Eras.First();
		public int FirstYearInThisEra => _calendar.MinSupportedDateTime.Year;
		public int FirstMonthInThisYear => 1;
		public int FirstDayInThisMonth => 1;
		public int FirstPeriodInThisDay => 1;
		public int FirstHourInThisPeriod => _clock == ClockIdentifiers.TwentyFourHour ? 0 : 12;
		public int FirstMinuteInThisHour => 0;
		public int FirstSecondInThisMinute => 0;

		public int LastEra => _calendar.Eras.Last();
		public int LastYearInThisEra => _calendar.MaxSupportedDateTime.Year;
		public int LastMonthInThisYear => _calendar.GetMonthsInYear(Year);
		public int LastDayInThisMonth => _calendar.GetDaysInMonth(Year, Month, Era);
		public int LastPeriodInThisDay => _clock == ClockIdentifiers.TwentyFourHour ? 1 : 2;
		public int LastHourInThisPeriod => _clock == ClockIdentifiers.TwentyFourHour ? 23 : 11;
		public int LastMinuteInThisHour => 59;
		public int LastSecondInThisMinute => 59;
		#endregion

		#region String formatting (***AsString()) !! not implemenated !!
		[NotImplemented]
		public string EraAsString()
		{
			throw new global::System.NotImplementedException("The member string Calendar.EraAsString() is not implemented in Uno.");
		}

		[NotImplemented]
		public string EraAsString(int idealLength)
		{
			throw new global::System.NotImplementedException("The member string Calendar.EraAsString(int idealLength) is not implemented in Uno.");
		}

		public string YearAsString()
			=> DateTimeOffset.Now.Year.ToString();

		[NotImplemented]
		public string YearAsTruncatedString(int remainingDigits)
		{
			throw new global::System.NotImplementedException("The member string Calendar.YearAsTruncatedString(int remainingDigits) is not implemented in Uno.");
		}

		public string YearAsPaddedString(int minDigits)
			=> _time.Year.ToString(new string('0', minDigits));

		[NotImplemented]
		public string MonthAsString()
		{
			throw new global::System.NotImplementedException("The member string Calendar.MonthAsString(int idealLength) is not implemented in Uno.");
		}

		[NotImplemented]
		public string MonthAsString(int idealLength)
		{
			throw new global::System.NotImplementedException("The member string Calendar.MonthAsString(int idealLength) is not implemented in Uno.");
		}

		public string MonthAsSoloString()
			=> _time.ToString("MMM");

		[NotImplemented]
		public string MonthAsSoloString(int idealLength)
		{
			throw new global::System.NotImplementedException("The member string Calendar.MonthAsSoloString(int idealLength) is not implemented in Uno.");
		}

		[NotImplemented]
		public string MonthAsNumericString()
		{
			throw new global::System.NotImplementedException("The member string Calendar.MonthAsNumericString() is not implemented in Uno.");
		}

		public string MonthAsPaddedNumericString(int minDigits)
			=> _time.Month.ToString(new string('0', minDigits));

		[NotImplemented]
		public string DayAsString()
		{
			throw new global::System.NotImplementedException("The member string Calendar.DayAsString() is not implemented in Uno.");
		}

		public string DayAsPaddedString(int minDigits)
			=> _time.Day.ToString(new string('0', minDigits));

		[NotImplemented]
		public string DayOfWeekAsString()
		{
			throw new global::System.NotImplementedException("The member string Calendar.DayOfWeekAsString() is not implemented in Uno.");
		}

		[NotImplemented]
		public string DayOfWeekAsString(int idealLength)
		{
			throw new global::System.NotImplementedException("The member string Calendar.DayOfWeekAsString(int idealLength) is not implemented in Uno.");
		}

		public string DayOfWeekAsSoloString()
			=> _time.ToString("ddd");

		[NotImplemented]
		public string DayOfWeekAsSoloString(int idealLength)
		{
			throw new global::System.NotImplementedException("The member string Calendar.DayOfWeekAsSoloString(int idealLength) is not implemented in Uno.");
		}

		public string PeriodAsString()
			=> _time.ToString("tt");

		public string PeriodAsString(int idealLength)
			=> _time.ToString("tt");

		public string HourAsString()
			=> _time.Hour.ToString();

		public string HourAsPaddedString(int minDigits)
			=> _time.Hour.ToString(new string('0', minDigits));
		public string MinuteAsString()
			=> _time.Minute.ToString();

		public string MinuteAsPaddedString(int minDigits)
			=> _time.Minute.ToString(new string('0', minDigits));

		public string SecondAsString()
			=> _time.Second.ToString();

		public string SecondAsPaddedString(int minDigits)
			=> _time.Second.ToString(new string('0', minDigits));

		public string NanosecondAsString()
			=> (_time.Millisecond * 1000).ToString();

		public string NanosecondAsPaddedString(int minDigits)
			=> (_time.Millisecond * 1000).ToString(new string('0', minDigits));

		public string TimeZoneAsString()
			=> _time.ToString("z");

		public string TimeZoneAsString(int idealLength)
			=> _time.ToString("zz");
		#endregion
	}
}
