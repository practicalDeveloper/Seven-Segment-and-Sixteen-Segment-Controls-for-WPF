using System;
using System.Windows.Media;

namespace SegmentsControls
{
    /// <summary>
    /// A char item with segment properties 
    /// </summary>
    public class CharItem : iSegment
    {
        public Char Item { get; set; }
        public Brush FillBrush { get; set; }
        public Brush SelectedFillBrush { get; set; }
        public Color PenColor { get; set; }
        public Color SelectedPenColor { get; set; }
        public Double PenThickness { get; set; }
        public string Value { get; set; }
        public Double GapWidth { get; set; }
        public bool RoundedCorners { get; set; }
        public Double TiltAngle { get; set; }
        public bool ShowDot { get; set; }
        public bool OnDot { get; set; }
        public bool ShowColon { get; set; }
        public bool OnColon { get; set; }
        public Double VertSegDivider { get; set; }
        public Double HorizSegDivider { get; set; }

    }
}
