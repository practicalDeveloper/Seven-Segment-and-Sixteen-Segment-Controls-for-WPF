using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentsControls
{
    public static class SixteenSegmentNumericGlyphs
    {
        public static readonly Dictionary<char, SixteenSegmentsFlags>
            NumericMap = new Dictionary<char, SixteenSegmentsFlags>
            {
                ['0'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop,

                ['1'] =
                SixteenSegmentsFlags.RightTopDiagonal |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom,

                ['2'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom,

                ['3'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,

                ['4'] =
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom,

                ['5'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.RightVertBottom,

                ['6'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle |
                SixteenSegmentsFlags.RightVertBottom,

                ['7'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom,

                ['8'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,

                ['9'] =
                SixteenSegmentsFlags.LeftHorizTop |
                SixteenSegmentsFlags.RightHorizTop |
                SixteenSegmentsFlags.RightVertTop |
                SixteenSegmentsFlags.RightVertBottom |
                SixteenSegmentsFlags.RightHorizBottom |
                SixteenSegmentsFlags.LeftHorizBottom |
                SixteenSegmentsFlags.LeftVertTop |
                SixteenSegmentsFlags.LeftMiddle |
                SixteenSegmentsFlags.RightMiddle,
            };

    }
}
