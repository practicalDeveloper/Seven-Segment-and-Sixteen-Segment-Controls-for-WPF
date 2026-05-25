using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentsControls
{
    public static class SixteenSegmentLatinGlyphs
    {
        public static readonly Dictionary<char, SixteenSegmentsFlags>
            LatinMap = new Dictionary<char, SixteenSegmentsFlags>
            {

                ['A'] =
                 SixteenSegmentsFlags.LeftHorizTop |
                 SixteenSegmentsFlags.RightHorizTop |
                 SixteenSegmentsFlags.RightVertTop |
                 SixteenSegmentsFlags.RightVertBottom |
                 SixteenSegmentsFlags.LeftVertBottom |
                 SixteenSegmentsFlags.LeftVertTop |
                 SixteenSegmentsFlags.LeftMiddle |
                 SixteenSegmentsFlags.RightMiddle,

                ['B'] =
                 SixteenSegmentsFlags.LeftHorizTop |
                 SixteenSegmentsFlags.RightHorizTop |
                 SixteenSegmentsFlags.RightVertTop |
                 SixteenSegmentsFlags.RightVertBottom |
                 SixteenSegmentsFlags.RightMiddle |
                 SixteenSegmentsFlags.TopVertical |
                 SixteenSegmentsFlags.BottomVertical |
                 SixteenSegmentsFlags.LeftHorizBottom |
                 SixteenSegmentsFlags.RightHorizBottom,
                ['C'] =
                 SixteenSegmentsFlags.LeftHorizTop |
                 SixteenSegmentsFlags.RightHorizTop |
                 SixteenSegmentsFlags.RightHorizBottom |
                 SixteenSegmentsFlags.LeftHorizBottom |
                 SixteenSegmentsFlags.LeftVertBottom |
                 SixteenSegmentsFlags.LeftVertTop,
                ['D'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.BottomVertical,

                ['E'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,
                ['F'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,

                ['G'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightMiddle,
                ['H'] =
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,

                ['I'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.BottomVertical,
                ['J'] =
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom,

                ['K'] =
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightTopDiagonal |
                SixteenSegmentsFlags.RightBottomDiagonal,
                ['L'] =
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop,

                ['M'] =
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftTopDiagonal |
                SixteenSegmentsFlags.RightTopDiagonal,
                ['N'] =
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftTopDiagonal |
                SixteenSegmentsFlags.RightBottomDiagonal,

                ['O'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop,
                ['P'] =
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,

                ['Q'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightBottomDiagonal,
                ['R'] =
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.RightBottomDiagonal,

                ['S'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom,
                ['T'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.BottomVertical,

                ['U'] =
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop,
                ['V'] =
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftBottomDiagonal |
                SixteenSegmentsFlags.RightTopDiagonal,

                ['W'] =
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.LeftBottomDiagonal |
                SixteenSegmentsFlags.RightBottomDiagonal,

                ['X'] =
                SixteenSegmentsFlags.LeftTopDiagonal |
                SixteenSegmentsFlags.RightTopDiagonal |
                SixteenSegmentsFlags.LeftBottomDiagonal |
                SixteenSegmentsFlags.RightBottomDiagonal,

                ['Y'] =
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.BottomVertical |
                SixteenSegmentsFlags.RightVertTop,

                ['Z'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightTopDiagonal |
                SixteenSegmentsFlags.LeftBottomDiagonal |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightHorizBottom,

            };
    }
}
