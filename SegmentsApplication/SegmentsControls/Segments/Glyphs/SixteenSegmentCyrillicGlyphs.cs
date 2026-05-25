using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentsControls
{
    public static class SixteenSegmentCyrillicGlyphs
    {
        public static readonly Dictionary<char, SixteenSegmentsFlags>
            CyrillicMap = new Dictionary<char, SixteenSegmentsFlags>
            {
                ['А'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle,

                ['Б'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.RightVertBottom,

                ['В'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.TopVertical |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightHorizBottom,

                ['Г'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom,

                ['Д'] =
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.TopVertical,

                ['Е'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightHorizBottom,

                ['Ж'] =
                    SixteenSegmentsFlags.LeftTopDiagonal |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.LeftBottomDiagonal |
                    SixteenSegmentsFlags.RightBottomDiagonal |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.TopVertical,

                ['З'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.LeftHorizBottom,

                ['И'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.LeftBottomDiagonal,

                ['Й'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.LeftBottomDiagonal |
                    SixteenSegmentsFlags.TopVertical,

                ['К'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.RightBottomDiagonal,

                ['Л'] =
                    SixteenSegmentsFlags.LeftBottomDiagonal |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom,

                ['М'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftTopDiagonal |
                    SixteenSegmentsFlags.RightTopDiagonal,

                ['Н'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle,

                ['О'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftVertTop,

                ['П'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom,

                ['Р'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle,

                ['С'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightHorizBottom,

                ['Т'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.TopVertical |
                    SixteenSegmentsFlags.BottomVertical,

                ['У'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.LeftHorizBottom,

                ['Ф'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.TopVertical |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.BottomVertical,
                ['Х'] =
                    SixteenSegmentsFlags.LeftTopDiagonal |
                    SixteenSegmentsFlags.RightTopDiagonal |
                    SixteenSegmentsFlags.LeftBottomDiagonal |
                    SixteenSegmentsFlags.RightBottomDiagonal,

                ['Ц'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.RightBottomDiagonal |
                    SixteenSegmentsFlags.LeftHorizBottom,

                ['Ч'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle,

                ['Ш'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.BottomVertical,

                ['Щ'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.RightBottomDiagonal,

                ['Ъ'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.TopVertical |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom,

                ['Ы'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.LeftHorizBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom,

                ['Ь'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.LeftHorizBottom,

                ['Э'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.LeftHorizBottom,

                ['Ю'] =
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.LeftVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.TopVertical |
                    SixteenSegmentsFlags.BottomVertical |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.RightHorizBottom |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom,

                ['Я'] =
                    SixteenSegmentsFlags.LeftHorizTop |
                    SixteenSegmentsFlags.RightHorizTop |
                    SixteenSegmentsFlags.LeftVertTop |
                    SixteenSegmentsFlags.RightVertTop |
                    SixteenSegmentsFlags.RightVertBottom |
                    SixteenSegmentsFlags.LeftMiddle |
                    SixteenSegmentsFlags.RightMiddle |
                    SixteenSegmentsFlags.LeftBottomDiagonal,
            };
    }
}
