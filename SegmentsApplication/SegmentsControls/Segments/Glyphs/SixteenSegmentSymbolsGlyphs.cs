using System.Collections.Generic;

namespace SegmentsControls
{
    public class SixteenSegmentSymbolsGlyphs
    {
        public static readonly Dictionary<char, SixteenSegmentsFlags>
            SymbolsMap = new Dictionary<char, SixteenSegmentsFlags>
            {
                ['"'] =
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.RightVertTop,

                ['№'] =
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftTopDiagonal |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.BottomVertical |
                SixteenSegmentsFlags.RightMiddle,

                ['$'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.BottomVertical,

                ['%'] =
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.TopVertical |
                SixteenSegmentsFlags.RightTopDiagonal |
                SixteenSegmentsFlags.LeftBottomDiagonal |
                SixteenSegmentsFlags.BottomVertical |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.RightVertBottom,

                ['('] =
                 SixteenSegmentsFlags.TopVertical |
                 SixteenSegmentsFlags.BottomVertical |
                 SixteenSegmentsFlags.RightHorizTop |
                 SixteenSegmentsFlags.RightHorizBottom,


                [')'] =
                 SixteenSegmentsFlags.TopVertical |
                 SixteenSegmentsFlags.BottomVertical |
                 SixteenSegmentsFlags.LeftHorizTop |
                 SixteenSegmentsFlags.LeftHorizBottom,

                ['-'] =
                 SixteenSegmentsFlags.LeftMiddle |
                 SixteenSegmentsFlags.RightMiddle,

                ['='] =
                 SixteenSegmentsFlags.LeftMiddle |
                 SixteenSegmentsFlags.RightMiddle |
                 SixteenSegmentsFlags.LeftHorizBottom |
                 SixteenSegmentsFlags.RightHorizBottom,

                [','] =
                 SixteenSegmentsFlags.BottomVertical,

                ['/'] =
                 SixteenSegmentsFlags.RightTopDiagonal |
                 SixteenSegmentsFlags.LeftBottomDiagonal,

                ['?'] =
                 SixteenSegmentsFlags.LeftVertTop |
                 SixteenSegmentsFlags.LeftHorizTop |
                 SixteenSegmentsFlags.RightHorizTop |
                 SixteenSegmentsFlags.RightVertTop |
                 SixteenSegmentsFlags.RightMiddle |
                 SixteenSegmentsFlags.BottomVertical,

            };
    }
}
