using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SegmentsControls
{
    /// <summary>
    /// A base classs for segment controls
    /// </summary>
    [DesignTimeVisible(false)]
    public class SegmentBase : UserControl, iSegment
    {
        protected event PropertyChangedCallback PropertyChanged = (sender, e) => { };
        protected static double defVertDividerSixteen = 7.5;
        protected static double defHorizDividerSixteen = 11.5;

        public static DependencyProperty PenColorProperty;
        public static DependencyProperty SelectedPenColorProperty;
        public static DependencyProperty FillBrushProperty;
        public static DependencyProperty PenThicknessProperty;
        public static DependencyProperty SelectedFillBrushProperty;
        public static DependencyProperty ValueProperty;
        public static DependencyProperty GapWidthProperty;
        public static DependencyProperty ShowDotProperty;
        public static DependencyProperty OnDotProperty;
        public static DependencyProperty ShowColonProperty;
        public static DependencyProperty OnColonProperty;
        public static DependencyProperty TiltAngleProperty;
        public static DependencyProperty RoundedCornersProperty;
        public static DependencyProperty SelectedSegmentsProperty;
        public static DependencyProperty SegmentsBrushProperty;
        public static DependencyProperty VertSegDividerProperty;
        public static DependencyProperty HorizSegDividerProperty;


        
        static SegmentBase()
        {
            PenThicknessProperty = DependencyProperty.Register("PenThickness", typeof(Double),
                typeof(SegmentBase), new PropertyMetadata(1.0, VisualChanged));

            PenColorProperty = DependencyProperty.Register("PenColor", typeof(Color),
                typeof(SegmentBase), new PropertyMetadata(Color.FromRgb(234, 234, 234), 
                    VisualChanged));

            SelectedPenColorProperty = DependencyProperty.Register("SelectedPenColor", typeof(Color),
                typeof(SegmentBase), new PropertyMetadata(Colors.Black, VisualChanged));

            FillBrushProperty = DependencyProperty.Register("FillBrush", typeof(Brush),
                typeof(SegmentBase),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(248, 248, 248)), 
                    VisualChanged));

            SelectedFillBrushProperty = DependencyProperty.Register("SelectedFillBrush", typeof(Brush),
                typeof(SegmentBase), new PropertyMetadata(new SolidColorBrush(Colors.Green), VisualChanged));

            TiltAngleProperty = DependencyProperty.Register("TiltAngle", typeof(double),
                typeof(SegmentBase), new PropertyMetadata(10.0, VisualChanged));

            GapWidthProperty = DependencyProperty.Register("GapWidth", typeof(double),
                typeof(SegmentBase), new PropertyMetadata(3.0, VisualChanged));

            RoundedCornersProperty = DependencyProperty.Register("RoundedCorners", typeof(bool),
                typeof(SegmentBase), new PropertyMetadata(false, VisualChanged));

            ValueProperty = DependencyProperty.Register("Value", typeof(string),
                typeof(SegmentBase), new PropertyMetadata("", VisualChanged));

            ShowDotProperty = DependencyProperty.Register("ShowDot", typeof(bool),
                typeof(SegmentBase), new PropertyMetadata(false, VisualChanged));

            OnDotProperty = DependencyProperty.Register("OnDot", typeof(bool),
                typeof(SegmentBase), new PropertyMetadata(false, VisualChanged));

            ShowColonProperty = DependencyProperty.Register("ShowColon", typeof(bool),
                typeof(SegmentBase), new PropertyMetadata(false, VisualChanged));

            OnColonProperty = DependencyProperty.Register("OnColon", typeof(bool),
                typeof(SegmentBase), new PropertyMetadata(false, VisualChanged));

            SelectedSegmentsProperty = DependencyProperty.Register("SelectedSegments", typeof(List<int>),
                typeof(SegmentBase), new PropertyMetadata(new List<int>(), VisualChanged));

            SegmentsBrushProperty = DependencyProperty.Register("SegmentsBrush", typeof(List<Tuple<int, Brush, Color>>),
                typeof(SegmentBase), new PropertyMetadata(new List<Tuple<int, Brush, Color>>(), VisualChanged));

            VertSegDividerProperty = DependencyProperty.Register("VertSegDivider", typeof(double),
                typeof(SegmentBase), new PropertyMetadata(5.0, VisualChanged));

            HorizSegDividerProperty = DependencyProperty.Register("HorizSegDivider", typeof(double),
                typeof(SegmentBase), new PropertyMetadata(9.0, VisualChanged));
        }

        /// <summary>
        /// A list of selected segments set by user
        /// </summary>
        public List<int> SelectedSegments
        {
            get { return (List<int>)this.GetValue(SelectedSegmentsProperty); }
            set { this.SetValue(SelectedSegmentsProperty, value); }
        }

        /// <summary>
        /// A list of segments numbers, fill brushes and pen colors
        /// </summary>
        public List<Tuple<int, Brush, Color>> SegmentsBrush
        {
            get { return (List<Tuple<int, Brush, Color>>)this.GetValue(SegmentsBrushProperty); }
            set { this.SetValue(SegmentsBrushProperty, value); }
        } 

        /// <summary>
        /// A brush for not selected elements
        /// </summary>
        public Brush FillBrush
        {
            get { return (Brush)GetValue(FillBrushProperty); }
            set { SetValue(FillBrushProperty, value); }
        }

        /// <summary>
        /// A brush for selected elements
        /// </summary>
        public Brush SelectedFillBrush
        {
            get { return (Brush)GetValue(SelectedFillBrushProperty); }
            set { SetValue(SelectedFillBrushProperty, value); }
        }

        /// <summary>
        /// A pen color for not selected elements
        /// </summary>
        public Color PenColor
        {
            get { return (Color)GetValue(PenColorProperty); }
            set { SetValue(PenColorProperty, value); }
        }

        /// <summary>
        /// A pen color for selected elements
        /// </summary>
        public Color SelectedPenColor
        {
            get { return (Color)GetValue(SelectedPenColorProperty); }
            set { SetValue(SelectedPenColorProperty, value); }
        }

        /// <summary>
        /// A pen thickness of elements
        /// </summary>
        public Double PenThickness
        {
            get { return (Double)GetValue(PenThicknessProperty); }
            set { SetValue(PenThicknessProperty, value); }
        }

        /// <summary>
        /// A value for segments control
        /// </summary>
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        /// <summary>
        /// A gap between segments (in pixels)
        /// </summary>
        public Double GapWidth
        {
            get { return (Double)GetValue(GapWidthProperty); }
            set { SetValue(GapWidthProperty, value); }
        }


        /// <summary>
        /// Checks whether or not the corners are rounded 
        /// </summary>
        public bool RoundedCorners
        {
            get { return (bool)GetValue(RoundedCornersProperty); }
            set { SetValue(RoundedCornersProperty, value); }
        }


        /// <summary>
        /// A tilt angle (in degrees)
        /// </summary>
        public Double TiltAngle
        {
            get { return (Double)GetValue(TiltAngleProperty); }
            set { SetValue(TiltAngleProperty, value); }
        }


        /// <summary>
        /// Shows/Hides dot for segments control
        /// </summary>
        public bool ShowDot
        {
            get { return (bool)GetValue(ShowDotProperty); }
            set { SetValue(ShowDotProperty, value); }
        }

        /// <summary>
        /// On/Off dot for segments control
        /// </summary>
        public bool OnDot
        {
            get { return (bool)GetValue(OnDotProperty); }
            set { SetValue(OnDotProperty, value); }
        }

        /// <summary>
        /// Shows/Hides colon for segments control
        /// </summary>
        public bool ShowColon
        {
            get { return (bool)GetValue(ShowColonProperty); }
            set { SetValue(ShowColonProperty, value); }
        }

        /// <summary>
        /// On/Off colon for segments control
        /// </summary>
        public bool OnColon
        {
            get { return (bool)GetValue(OnColonProperty); }
            set { SetValue(OnColonProperty, value); }
        }

        /// <summary>
        /// A divider for vert. segments width
        /// </summary>
        public Double VertSegDivider
        {
            get { return (Double)GetValue(VertSegDividerProperty); }
            set { SetValue(VertSegDividerProperty, value); }
        }


        /// <summary>
        /// A divider for horiz. segments height
        /// </summary>
        public Double HorizSegDivider
        {
            get { return (Double)GetValue(HorizSegDividerProperty); }
            set { SetValue(HorizSegDividerProperty, value); }
        }


        private static void VisualChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SegmentBase segments = (SegmentBase)sender;
            segments.PropertyChanged(sender, e);
        }


    }
}
