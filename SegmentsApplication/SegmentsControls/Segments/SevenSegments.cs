using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SegmentsControls
{
    /// <summary>
    /// A seven segments control
    /// </summary>
    public class SevenSegments : SegmentBase<SevenSegmentsFlags>
    {
        protected override void ValueSegmentsSelection()
        {
            ResetSegments();

            char c =
                string.IsNullOrWhiteSpace(Value)
                    ? ' '
                    : char.ToUpperInvariant(Value[0]);


            if (!SevenSegmentGlyphs.Map.TryGetValue(c, out SevenSegmentsFlags mask))
            {
                mask = SevenSegmentsFlags.None;
            }

            ApplyMask(Convert.ToUInt32(mask));
        }


        /// <summary>
        /// Assigns a segment number to required path geometry. Order is important!
        /// </summary>
        protected override void AssignSegments()
        {
            GeometryFigures = new List<GeometryWithSegm<SevenSegmentsFlags>>();

            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(LeftBottomSegment(), SevenSegmentsFlags.LeftBottom));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(LeftTopSegment(), SevenSegmentsFlags.LeftTop));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(RightTopSegment(), SevenSegmentsFlags.RightTop));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(RightBottomSegment(), SevenSegmentsFlags.RightBottom));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(MiddleSegment(), SevenSegmentsFlags.Middle));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(TopSegment(), SevenSegmentsFlags.Top));
            GeometryFigures.Add(new GeometryWithSegm<SevenSegmentsFlags>(BottomSegment(), SevenSegmentsFlags.Bottom));

        }


    }
}
