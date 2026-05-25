using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SegmentsControls
{
    public static class SixteenSegmentGlyphs
    {
        public static readonly Dictionary<char, SixteenSegmentsFlags> Map;

        static SixteenSegmentGlyphs()
        {
            Map = new Dictionary<char, SixteenSegmentsFlags>();

            Merge(SixteenSegmentNumericGlyphs.NumericMap);
            Merge(SixteenSegmentLatinGlyphs.LatinMap);
            Merge(SixteenSegmentCyrillicGlyphs.CyrillicMap);
        }

        private static void Merge(Dictionary<char, SixteenSegmentsFlags> source)
        {
            foreach (var pair in source)
            {
                Map[pair.Key] = pair.Value;
            }
        }
    }
}
