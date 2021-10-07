// MUX reference InfoBar.cpp, commit 1f7779d

using Microsoft.UI.Xaml.Automation.Peers;
using Uno.UI.Helpers.WinUI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;

namespace Microsoft.UI.Xaml.Controls
{	
	[ContentProperty(Name = nameof(Content))]
	public partial class InfoBar : Control
	{
		private const string c_closeButtonName = "CloseButton";
		private const string c_iconTextBlockName = "StandardIcon";
		private const string c_contentRootName = "ContentRoot";

		private readonly long _foregroundChangedCallbackRegistration;

		private bool m_applyTemplateCalled = false;
		private bool m_notifyOpen = false;
		private bool m_isVisible = false;
		private FrameworkElement m_standardIconTextBlock = null;
		private InfoBarCloseReason m_lastCloseReason = InfoBarCloseReason.Programmatic;

		public InfoBar()
		{
			//__RP_Marker_ClassById(RuntimeProfiler.ProfId_InfoBar);

			SetValue(TemplateSettingsProperty, new InfoBarTemplateSettings());

			_foregroundChangedCallbackRegistration = RegisterPropertyChangedCallback(Control.ForegroundProperty, OnForegroundChanged);

			DefaultStyleKey = typeof(InfoBar);
		}

		protected override AutomationPeer OnCreateAutomationPeer()
		{
			return new InfoBarAutomationPeer(this);
		}

		protected override void OnApplyTemplate()
		{
			m_applyTemplateCalled = true;

			var closeButton = GetTemplateChild<Button>(c_closeButtonName);
			if (closeButton != null)
			{
				closeButton.Click += OnCloseButtonClick;

				// Do localization for the close button
				if (string.IsNullOrEmpty(AutomationProperties.GetName(closeButton)))
				{
					var closeButtonName = ResourceAccessor.GetLocalizedStringResource(ResourceAccessor.SR_InfoBarCloseButtonName);
					AutomationProperties.SetName(closeButton, closeButtonName);
				}

				// Setup the tooltip for the close button
				var tooltip = new ToolTip();
				var closeButtonTooltipText = ResourceAccessor.GetLocalizedStringResource(ResourceAccessor.SR_InfoBarCloseButtonTooltip);
				tooltip.Content = closeButtonTooltipText;
				ToolTipService.SetToolTip(closeButton, tooltip);
			}

			var iconTextblock = GetTemplateChild<FrameworkElement>(c_iconTextBlockName);
			if (iconTextblock != null)
			{
				m_standardIconTextBlock = iconTextblock;
				AutomationProperties.SetName(iconTextblock, ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)));
			}

			var contentRootGrid = GetTemplateChild<Button>(c_contentRootName);
			if (contentRootGrid != null)
			{
				AutomationProperties.SetLocalizedLandmarkType(contentRootGrid, ResourceAccessor.GetLocalizedStringResource(ResourceAccessor.SR_InfoBarCustomLandmarkName));
			}

			UpdateVisibility(m_notifyOpen, true);
			m_notifyOpen = false;

			UpdateSeverity();
			UpdateIcon();
			UpdateIconVisibility();
			UpdateCloseButton();
			UpdateForeground();
		}

		private void OnCloseButtonClick(object sender, RoutedEventArgs args)
		{
			CloseButtonClick?.Invoke(this, null);
			m_lastCloseReason = InfoBarCloseReason.CloseButton;
			IsOpen = false;
		}

		private void RaiseClosingEvent()
		{
			var args = new InfoBarClosingEventArgs(m_lastCloseReason);

			Closing?.Invoke(this, args);

			if (!args.Cancel)
			{
				UpdateVisibility();
				RaiseClosedEvent();
			}
			else
			{
				// The developer has changed the Cancel property to true,
				// so we need to revert the IsOpen property to true.
				IsOpen = true;
			}
		}

		private void RaiseClosedEvent()
		{
			var args = new InfoBarClosedEventArgs(m_lastCloseReason);
			Closed?.Invoke(this, args);
		}

		private void OnIsOpenPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			if (IsOpen)
			{
				//Reset the close reason to the default value of programmatic.
				m_lastCloseReason = InfoBarCloseReason.Programmatic;

				UpdateVisibility();
			}
			else
			{
				RaiseClosingEvent();
			}
		}

		private void OnSeverityPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			UpdateSeverity();
		}

		private void OnIconSourcePropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			UpdateIcon();
			UpdateIconVisibility();
		}

		private void OnIsIconVisiblePropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			UpdateIconVisibility();
		}

		private void OnIsClosablePropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			UpdateCloseButton();
		}

		private void UpdateVisibility(bool notify = true, bool force = true)
		{
			var peer = FrameworkElementAutomationPeer.FromElement(this) as InfoBarAutomationPeer;
			if (!m_applyTemplateCalled)
			{
				// ApplyTemplate() hasn't been called yet but IsOpen has already been set.
				// Since this method will be called again shortly from ApplyTemplate, we'll just wait and send a notification then.
				m_notifyOpen = true;
			}
			else
			{
				// Don't do any work if nothing has changed (unless we are forcing a update)
				if (force || IsOpen != m_isVisible)
				{
					if (IsOpen)
					{
						if (notify && peer != null)
						{
							var notificationString = StringUtil.FormatString(
								ResourceAccessor.GetLocalizedStringResource(ResourceAccessor.SR_InfoBarOpenedNotification),
								ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)),
								Title,
								Message);

							peer.RaiseOpenedEvent(Severity, notificationString);
						}

						VisualStateManager.GoToState(this, "InfoBarVisible", false);
						AutomationProperties.SetAccessibilityView(this, AccessibilityView.Control);
						m_isVisible = true;
					}
					else
					{
						if (notify && peer != null)
						{
							var notificationString = ResourceAccessor.GetLocalizedStringResource(ResourceAccessor.SR_InfoBarClosedNotification);

							peer.RaiseClosedEvent(Severity, notificationString);
						}

						VisualStateManager.GoToState(this, "InfoBarCollapsed", false);
						AutomationProperties.SetAccessibilityView(this, AccessibilityView.Raw);
						m_isVisible = false;
					}
				}
			}
		}

		void UpdateSeverity()
		{
			var severityState = "Informational";

			switch (Severity)
			{
				case InfoBarSeverity.Success:
					severityState = "Success";
					break;
				case InfoBarSeverity.Warning:
					severityState = "Warning";
					break;
				case InfoBarSeverity.Error:
					severityState = "Error";
					break;
			};

			if (m_standardIconTextBlock is FrameworkElement iconTextblock)
			{
				AutomationProperties.SetName(iconTextblock, ResourceAccessor.GetLocalizedStringResource(GetIconSeverityLevelResourceName(Severity)));
			}

			VisualStateManager.GoToState(this, severityState, false);
		}

		private void UpdateIcon()
		{
			var templateSettings = TemplateSettings;
			var source = IconSource;
			if (source != null)
			{
				templateSettings.IconElement = SharedHelpers.MakeIconElementFrom(source);
			}

			else
			{
				templateSettings.IconElement = null;
			}
		}

		void UpdateIconVisibility()
		{
			VisualStateManager.GoToState(this, IsIconVisible ? (IconSource != null ? "UserIconVisible" : "StandardIconVisible") : "NoIconVisible", false);
		}

		void UpdateCloseButton()
		{
			VisualStateManager.GoToState(this, IsClosable ? "CloseButtonVisible" : "CloseButtonCollapsed", false);
		}

		void OnForegroundChanged(DependencyObject sender, DependencyProperty args)
		{
			UpdateForeground();
		}

		void UpdateForeground()
		{
			// If Foreground is set, then change Title and Message Foreground to match.
			VisualStateManager.GoToState(this, ReadLocalValue(Control.ForegroundProperty) == DependencyProperty.UnsetValue ? "ForegroundNotSet" : "ForegroundSet", false);
		}

		string GetSeverityLevelResourceName(InfoBarSeverity severity)
		{
			switch (severity)
			{
				case InfoBarSeverity.Success: return "InfoBarSeveritySuccessName";
				case InfoBarSeverity.Warning: return "InfoBarSeverityWarningName";
				case InfoBarSeverity.Error: return "InfoBarSeverityErrorName";
			};
			return "InfoBarSeverityInformationalName";
		}

		string GetIconSeverityLevelResourceName(InfoBarSeverity severity)
		{
			switch (severity)
			{
				case InfoBarSeverity.Success: return "InfoBarIconSeveritySuccessName";
				case InfoBarSeverity.Warning: return "InfoBarIconSeverityWarningName";
				case InfoBarSeverity.Error: return "InfoBarIconSeverityErrorName";
			};
			return "InfoBarIconSeverityInformationalName";
		}
	}
}
