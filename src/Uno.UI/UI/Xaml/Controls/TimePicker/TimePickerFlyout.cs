using System;
using Microsoft.UI.Xaml.Controls.Primitives;

namespace Microsoft.UI.Xaml.Controls
{
	partial class TimePickerFlyout : PickerFlyoutBase
	{
#if !__ANDROID__ && !__IOS__
		protected override Control CreatePresenter() => throw new NotImplementedException();
#endif

		protected override void OnConfirmed() => throw new NotImplementedException();

		protected override bool ShouldShowConfirmationButtons() => throw new NotImplementedException();
	}
}
