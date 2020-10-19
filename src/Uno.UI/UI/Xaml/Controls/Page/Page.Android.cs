using Android.Views;
using Android.Widget;
using Uno.Logging;
using Uno.Extensions;
using Uno.UI.DataBinding;
using Uno.UI.Controls;
using Windows.UI.Xaml.Data;
using System;
using System.Collections.Generic;
using Uno.Disposables;
using System.Runtime.CompilerServices;
using System.Text;
using Android.Graphics;
using Android.Graphics.Drawables;
using System.Drawing;
using System.Linq;
using Uno.UI;

namespace Windows.UI.Xaml.Controls
{
	public partial class Page
	{
		private BorderLayerRenderer _borderRenderer = new BorderLayerRenderer();

		private void InitializeBorder()
		{
			LayoutUpdated += (s, e) => UpdateBorder();
		}

		internal override void Enter()
		{
			base.Enter();
			UpdateBorder();
		}

		internal override void Leave()
		{
			base.Leave();
			_borderRenderer.Clear();
		}

		private void UpdateBorder()
		{
			UpdateBorder(false);
		}

		private void UpdateBorder(bool willUpdateMeasures)
		{
			if (IsActive)
			{
				_borderRenderer.UpdateLayers(
					this,
					Background,
					Thickness.Empty,
					null,
					CornerRadius.None,
					Thickness.Empty,
					willUpdateMeasures
				);
			}
		}
	}
}
