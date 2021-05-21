using System.Runtime.InteropServices;
using __u32 = System.UInt32;

namespace Uno.UI.Runtime.Skia.Native
{
	[StructLayout(LayoutKind.Sequential)]
	struct fb_bitfield
	{
		public __u32 offset;		/* beginning of bitfield	*/
		public __u32 length;		/* length of bitfield		*/

		public __u32 msb_right;		/* != 0 : Most significant bit is */
									/* right */
	}
}
