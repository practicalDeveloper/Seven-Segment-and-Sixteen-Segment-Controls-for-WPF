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

        public TSegment Sector { get; set; }

        public bool IsSelected { get; set; }

        public GeometryWithSegm(
            PathGeometry geometry,
            TSegment sector,
            bool isSelected = false)
        {
            Geometry = geometry;
            Sector = sector;
            IsSelected = isSelected;
        }
    }
}
