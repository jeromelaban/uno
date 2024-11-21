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

namespace Uno.UI.Tests.Windows_UI_XAML_Controls.GridTests.Controls
{
	partial class Grid_Uses_New_Assigned_ContentProperty_Syntax : global::Microsoft.UI.Xaml.Controls.Page
	{
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_prefix_Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef = "ms-appx:///TestProject/";
		[global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
		private const string __baseUri_Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef = "ms-appx:///TestProject/";
		private global::Microsoft.UI.Xaml.NameScope __nameScope = new global::Microsoft.UI.Xaml.NameScope();
		private void InitializeComponent()
		{
			NameScope.SetNameScope(this, __nameScope);
			var __that = this;
			base.IsParsing = true;
			// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 1:2)
			base.Content = 
			new global::Microsoft.UI.Xaml.Controls.Grid
			{
				IsParsing = true,
				Name = "grid",
				ColumnDefinitions = 
				{
					new global::Microsoft.UI.Xaml.Controls.ColumnDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 15:14)
						Width = new global::Microsoft.UI.Xaml.GridLength(1f, global::Microsoft.UI.Xaml.GridUnitType.Star)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.ColumnDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 16:14)
						Width = new global::Microsoft.UI.Xaml.GridLength(2f, global::Microsoft.UI.Xaml.GridUnitType.Star)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.ColumnDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 17:14)
						Width = new global::Microsoft.UI.Xaml.GridLength(1f, global::Microsoft.UI.Xaml.GridUnitType.Auto)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.ColumnDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 18:14)
						Width = new global::Microsoft.UI.Xaml.GridLength(1f, global::Microsoft.UI.Xaml.GridUnitType.Star)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.ColumnDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 19:14)
						Width = new global::Microsoft.UI.Xaml.GridLength(300f, global::Microsoft.UI.Xaml.GridUnitType.Pixel)
					}
					,
				}
				,
				RowDefinitions = 
				{
					new global::Microsoft.UI.Xaml.Controls.RowDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 22:14)
						Height = new global::Microsoft.UI.Xaml.GridLength(1f, global::Microsoft.UI.Xaml.GridUnitType.Star)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.RowDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 23:14)
						Height = new global::Microsoft.UI.Xaml.GridLength(1f, global::Microsoft.UI.Xaml.GridUnitType.Auto)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.RowDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 24:14)
						Height = new global::Microsoft.UI.Xaml.GridLength(25f, global::Microsoft.UI.Xaml.GridUnitType.Pixel)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.RowDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 25:14)
						Height = new global::Microsoft.UI.Xaml.GridLength(14f, global::Microsoft.UI.Xaml.GridUnitType.Pixel)
					}
					,
					new global::Microsoft.UI.Xaml.Controls.RowDefinition
					{
						// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 26:14)
						Height = new global::Microsoft.UI.Xaml.GridLength(20f, global::Microsoft.UI.Xaml.GridUnitType.Pixel)
					}
					,
				}
				,
				// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 10:6)
			}
			.Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef_XamlApply((Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509efXamlApplyExtensions.XamlApplyHandler0)(c0 => 
			{
				__nameScope.RegisterName("grid", c0);
				__that.grid = c0;
				// FieldModifier public
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c0, __baseUri_Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef);
				c0.CreationComplete();
			}
			))
			;
			
			
			this
			.GenericApply(((c1) => 
			{
				// Source 0\Grid_Uses_New_Assigned_ContentProperty_Syntax.xaml (Line 1:2)
				
				// WARNING Property c1.base does not exist on {http://schemas.microsoft.com/winfx/2006/xaml/presentation}Page, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.GenericApply(((c2) => 
			{
				// Class Uno.UI.Tests.Windows_UI_XAML_Controls.GridTests.Controls.Grid_Uses_New_Assigned_ContentProperty_Syntax
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c2, __baseUri_Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef);
				c2.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

		}
		partial void OnInitializeCompleted();
		private global::Microsoft.UI.Xaml.Data.ElementNameSubject _gridSubject = new global::Microsoft.UI.Xaml.Data.ElementNameSubject();
		public global::Microsoft.UI.Xaml.Controls.Grid grid
		{
			get
			{
				return (global::Microsoft.UI.Xaml.Controls.Grid)_gridSubject.ElementInstance;
			}
			set
			{
				_gridSubject.ElementInstance = value;
			}
		}
	}
}
namespace MyProject
{
	static class Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509efXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Microsoft.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Microsoft.UI.Xaml.Controls.Grid Grid_Uses_New_Assigned_ContentProperty_Syntax_9f853e56098ff21d39f15479035509ef_XamlApply(this global::Microsoft.UI.Xaml.Controls.Grid instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
