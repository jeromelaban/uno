﻿namespace Microsoft.UI.Xaml.Controls;

/// <summary>
/// Provides event data for the RefreshVisualizer.RefreshStateChanged event.
/// </summary>
public sealed partial class RefreshStateChangedEventArgs
{
	internal RefreshStateChangedEventArgs(RefreshVisualizerState oldState, RefreshVisualizerState newState)
	{
		OldState = oldState;
		NewState = newState;
	}

	/// <summary>
	/// Gets a value that indicates the previous state of the RefreshVisualizer.
	/// </summary>
	public RefreshVisualizerState OldState { get; }

	/// <summary>
	/// Gets a value that indicates the new state of the RefreshVisualizer.
	/// </summary>
	public RefreshVisualizerState NewState { get; }
}
