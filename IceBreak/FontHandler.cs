using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;

namespace IceBreak
{
    public class FontHandler
    {
        private const int SEVEN_SEGMENT_SIZE = 20;
        private readonly PrivateFontCollection privateFontCollection;

        public FontHandler()
        {
            privateFontCollection = new PrivateFontCollection();
            loadFont();
        }

        public Font sevenSegment
        {
            get;
            private set;
        }

        private void loadFont()
        {
            using (MemoryStream ms = new MemoryStream(Properties.Resources.SevenSegment))
            {
                byte[] fontData = ms.ToArray();
                unsafe
                {
                    fixed (byte* fontDataPointer = fontData)
                    {
                        uint installFontCount = 0;
                        AddFontMemResourceEx((IntPtr)fontDataPointer, (uint)fontData.Length, IntPtr.Zero, ref installFontCount);
                        privateFontCollection.AddMemoryFont((IntPtr)fontDataPointer, fontData.Length);
                    }
                }
            }
            sevenSegment = new Font(privateFontCollection.Families[0], SEVEN_SEGMENT_SIZE);
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pointerFont, uint fontSize, IntPtr pointerReserve, [In] ref uint pointerInstallFontCount);
    }
}