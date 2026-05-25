using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentsControls
{
    public static class SevenSegmentGlyphs
    {
        public static readonly Dictionary<char, SevenSegmentsFlags>
            Map = new Dictionary<char, SevenSegmentsFlags>
            {
                ['0'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom |
                        SevenSegmentsFlags.LeftBottom |
                        SevenSegmentsFlags.LeftTop,

                ['1'] =
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom,

                ['2'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.Middle |
                        SevenSegmentsFlags.LeftBottom |
                        SevenSegmentsFlags.Bottom,

                ['3'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.Middle |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom,
                ['4'] =
                        SevenSegmentsFlags.LeftTop |
                        SevenSegmentsFlags.Middle |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom,
                ['5'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.LeftTop |
                        SevenSegmentsFlags.Middle |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom,
                ['6'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.LeftTop |
                        SevenSegmentsFlags.Middle |
                        SevenSegmentsFlags.LeftBottom |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom,
                ['7'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom,
                ['8'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom |
                        SevenSegmentsFlags.LeftBottom |
                        SevenSegmentsFlags.LeftTop |
                        SevenSegmentsFlags.Middle,
                ['9'] =
                        SevenSegmentsFlags.Top |
                        SevenSegmentsFlags.RightTop |
                        SevenSegmentsFlags.RightBottom |
                        SevenSegmentsFlags.Bottom |
                        SevenSegmentsFlags.LeftTop |
                        SevenSegmentsFlags.Middle

            };
    }
}
