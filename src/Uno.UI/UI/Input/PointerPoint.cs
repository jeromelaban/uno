﻿// On the UWP branch, only include this file in Uno.UWP (as public Window.whatever). On the WinUI branch, include it in both Uno.UWP (internal as Windows.whatever) and Uno.UI (public as Microsoft.whatever)
#if HAS_UNO_WINUI || !IS_UNO_UI_PROJECT
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Windows.Devices.Input;
using Windows.Foundation;

#if HAS_UNO_WINUI && IS_UNO_UI_PROJECT
namespace Microsoft.UI.Input
#else
namespace Windows.UI.Input
#endif
{
	public partial class PointerPoint
	{
		internal PointerPoint(
			uint frameId,
			ulong timestamp,
			PointerDevice device,
			uint pointerId,
			Point rawPosition,
			Point position,
			bool isInContact,
			PointerPointProperties properties)
		{
			FrameId = frameId;
			Timestamp = timestamp;
			PointerDevice = device;
			PointerDeviceType = (PointerDeviceType)PointerDevice.PointerDeviceType;
			PointerId = pointerId;
			RawPosition = rawPosition;
			Position = position;
			IsInContact = isInContact;
			Properties = properties;
		}

		/// <summary>
		/// Retrieves the relative timestamp in microseconds.
		/// </summary>
		/// <returns>Timestamp in microseconds.</returns>
		internal static ulong GetRelativeTimestamp() =>
			(ulong)Stopwatch.GetElapsedTime(Stopwatch.GetTimestamp()).TotalMicroseconds;

#if HAS_UNO_WINUI && IS_UNO_UI_PROJECT
		public PointerPoint(global::Windows.UI.Input.PointerPoint point)
		{
			FrameId = point.FrameId;
			Timestamp = point.Timestamp;
			PointerDevice = point.PointerDevice;
			PointerId = point.PointerId;
			RawPosition = point.RawPosition;
			Position = point.Position;
			IsInContact = point.IsInContact;
			PointerDeviceType = (PointerDeviceType)point.PointerDevice.PointerDeviceType;

			Properties = new PointerPointProperties(point.Properties);
		}

		// Historically, we had explicit conversion only.
		// In the work for InteractionTracker, we needed an implicit conversion to avoid a breaking change.
		// The compiler doesn't allow to define both. (https://learn.microsoft.com/en-us/dotnet/csharp/misc/cs0557)
		// And changing the explicit conversion operator to implicit conversion operator is a binary breaking change.
		// We manually add this method to avoid this binary breaking change.
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static global::Windows.UI.Input.PointerPoint op_Explicit(Microsoft.UI.Input.PointerPoint muxPointerPoint)
			=> muxPointerPoint;


		public static implicit operator global::Windows.UI.Input.PointerPoint(Microsoft.UI.Input.PointerPoint muxPointerPoint)
		{
			return new global::Windows.UI.Input.PointerPoint(
				muxPointerPoint.FrameId,
				muxPointerPoint.Timestamp,
				muxPointerPoint.PointerDevice,
				muxPointerPoint.PointerId,
				muxPointerPoint.RawPosition,
				muxPointerPoint.Position,
				muxPointerPoint.IsInContact,
				(global::Windows.UI.Input.PointerPointProperties)muxPointerPoint.Properties);
		}
#endif

		internal PointerPoint At(Point position)
			=> new PointerPoint(
				FrameId,
				Timestamp,
				PointerDevice,
				PointerId,
				RawPosition,
				position: position,
				IsInContact,
				Properties);

		internal PointerIdentifier Pointer => new PointerIdentifier(PointerDevice.PointerDeviceType, PointerId);

		public uint FrameId { get; }

		public ulong Timestamp { get; }

		public PointerDevice PointerDevice { get; }

		public PointerDeviceType PointerDeviceType { get; }

		public uint PointerId { get; }

		public Point RawPosition { get; }

		public Point Position { get; }

		public bool IsInContact { get; }

		public PointerPointProperties Properties { get; }

		/// <inheritdoc />
		public override string ToString()
			=> $"[{PointerDevice.PointerDeviceType}-{PointerId}] @{Position.ToDebugString()} (raw: {RawPosition.ToDebugString()} | ts: {Timestamp} | props: {Properties} | inContact: {IsInContact})";
	}
}
#endif
