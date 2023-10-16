﻿// <autogenerated />
#pragma warning disable CS0114
#pragma warning disable CS0108
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers;
using Uno.UI.Helpers.Xaml;
using MyProject;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#else
using _View = Microsoft.UI.Xaml.UIElement;
#endif

namespace TestRepro
{
	partial class UserControl1 : global::Microsoft.UI.Xaml.Controls.UserControl
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_UserControl1_81d855d5b3bba02f594dcda3b149beb2 = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_UserControl1_81d855d5b3bba02f594dcda3b149beb2 = "ms-appx:///TestProject/";
		global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			// Source 0\UserControl1.xaml (Line 1:2)
			base.Content = 
			new global::Microsoft.UI.Xaml.Controls.Grid
			{
				IsParsing = true,
				// Source 0\UserControl1.xaml (Line 12:3)
			}
			.UserControl1_81d855d5b3bba02f594dcda3b149beb2_XamlApply((UserControl1_81d855d5b3bba02f594dcda3b149beb2XamlApplyExtensions.XamlApplyHandler0)(c0 => 
			{
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c0, __baseUri_UserControl1_81d855d5b3bba02f594dcda3b149beb2);
				c0.CreationComplete();
			}
			))
			;
			
			this
			.GenericApply(((c1) => 
			{
				// Source 0\UserControl1.xaml (Line 1:2)
				
				// WARNING Property c1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}UserControl, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.GenericApply(((c2) => 
			{
				// Class TestRepro.UserControl1
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c2, __baseUri_UserControl1_81d855d5b3bba02f594dcda3b149beb2);
				c2.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

		}
		partial void OnInitializeCompleted();
	}
}
namespace MyProject
{
	static class UserControl1_81d855d5b3bba02f594dcda3b149beb2XamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Grid UserControl1_81d855d5b3bba02f594dcda3b149beb2_XamlApply(this global::Microsoft.UI.Xaml.Controls.Grid instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
