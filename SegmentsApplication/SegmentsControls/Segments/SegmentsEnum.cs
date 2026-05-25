using System;

namespace SegmentsControls
{
    /// <summary>
    /// Segments flags for seven segment control
    /// </summary>
    [Flags]
    public enum SevenSegmentsFlags
    {
        None = 0,

        Top = 1 << 0,
        RightTop = 1 << 1,
        RightBottom = 1 << 2,
        Bottom = 1 << 3,
        LeftBottom = 1 << 4,
        LeftTop = 1 << 5,
        Middle = 1 << 6
    }


    /// <summary>
    /// Segments flags for sixteen segment control
    /// </summary>
    [Flags]
    public enum SixteenSegmentsFlags
    {
        None = 0,

        LeftHorizTop = 1 << 0,
        RightHorizTop = 1 << 1,
        RightVertTop = 1 << 2,
        RightVertBottom = 1 << 3,
        RightHorizBottom = 1 << 4,
        LeftHorizBottom = 1 << 5,
        LeftVertBottom = 1 << 6,
        LeftVertTop = 1 << 7,
        LeftTopDiagonal = 1 << 8,
        TopVertical = 1 << 9,
        RightTopDiagonal = 1 << 10,
        LeftMiddle = 1 << 11,
        RightMiddle = 1 << 12,
        LeftBottomDiagonal = 1 << 13,
        BottomVertical = 1 << 14,
        RightBottomDiagonal = 1 << 15
    }
}
