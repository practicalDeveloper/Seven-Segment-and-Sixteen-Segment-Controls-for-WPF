using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SegmentsControls
{
    public class SegmentBrush<TSegment>
    {
        public TSegment Segment { get; set; }

        public Brush FillBrush { get; set; }

        public Color PenColor { get; set; }
    }
}
