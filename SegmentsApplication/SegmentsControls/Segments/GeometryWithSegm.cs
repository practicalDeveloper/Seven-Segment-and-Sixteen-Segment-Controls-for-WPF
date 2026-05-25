using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SegmentsControls
{
    /// <summary>
    /// The class to detect selected segment
    /// </summary>
    public class GeometryWithSegm<TSegment>
    {
        public PathGeometry Geometry { get; set; }

        public TSegment SegmentNumber { get; set; }

        public bool IsSelected { get; set; }

        public GeometryWithSegm(
            PathGeometry geometry,
            TSegment segment,
            bool isSelected = false)
        {
            Geometry = geometry;
            SegmentNumber = segment;
            IsSelected = isSelected;
        }
    }
}
