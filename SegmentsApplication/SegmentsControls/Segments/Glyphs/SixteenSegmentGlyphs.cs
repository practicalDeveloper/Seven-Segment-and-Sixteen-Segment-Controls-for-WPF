using System.Collections.Generic;

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
            Merge(SixteenSegmentSymbolsGlyphs.SymbolsMap);
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
