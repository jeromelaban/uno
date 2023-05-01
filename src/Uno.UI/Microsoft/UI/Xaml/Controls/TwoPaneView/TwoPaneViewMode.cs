﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// MUX Reference TwoPaneView.idl, commit c6174f1

namespace Microsoft/* UWP don't rename */.UI.Xaml.Controls;

/// <summary>
/// Defines constants that specify how panes are shown in a TwoPaneView.
/// </summary>
public enum TwoPaneViewMode
{
	/// <summary>
	/// Only one pane is shown.
	/// </summary>
	SinglePane = 0,

	/// <summary>
	/// Panes are shown side-by-side.
	/// </summary>
	Wide = 1,

	/// <summary>
	/// Panes are shown top-bottom.
	/// </summary>
	Tall = 2,
}
