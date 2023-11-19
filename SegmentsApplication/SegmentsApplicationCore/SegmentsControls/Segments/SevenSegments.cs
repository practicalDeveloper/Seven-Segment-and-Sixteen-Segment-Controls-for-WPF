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
    public class SevenSegments : SegmentBase
    {
        #region Protected variables

        protected bool isPropertyCahnged = true;
        protected double startPointThickness;

        protected double vertRoundCoef = 0;
        protected double horizRoundCoef = 0;

        /// <summary>
        /// The width of the vert. segm
        /// </summary>
        protected double VertSegW { get; private set; }

        /// <summary>
        /// The width of the vert. segment's part
        /// </summary>
        protected double VertSegPartW { get; private set; }

        /// <summary>
        /// The height of the vert. segment's part
        /// </summary>
        protected double VertSegSmallPartH { get; private set; }

        /// <summary>
        /// The height of the horiz. segment
        /// </summary>
        protected double HorizSegH { get; private set; }

        /// <summary>
        /// The height of the horiz. segment's part
        /// </summary>
        protected double HorizSegSmallPartH { get; private set; }

        /// <summary>
        /// The width of the horiz. segment's part
        /// </summary>
        protected double HorizSegSmallPartW { get; private set; }

        /// <summary>
        /// The horizontal midlle point
        /// </summary>
        protected double MidPoint { get; private set; }

        /// <summary>
        /// The gap between segments
        /// </summary>
        protected double GapW { get; private set; }


        /// <summary>
        /// The diameter of the dot
        /// </summary>
        protected double DotDiameter { get; private set; }

        /// <summary>
        /// The diameter of the colon
        /// </summary>
        protected double ColonDiameter { get; private set; }

        /// <summary>
        /// The height depending on the decimal dot
        /// </summary>
        protected double VirtualWidth { get; private set; }

        /// <summary>
        /// The width depending on the decimal dot
        /// </summary>
        protected double VirtualHeight { get; private set; }


        /// <summary>
        /// The list of geometries to detect selected segments
        /// </summary>
        protected List<GeometryWithSegm> GeometryFigures;

        /// <summary>
        /// The width of the vert. segment's bottom part
        /// </summary>
        protected double VertSegBotPartW { get; private set; }
      
        /// <summary>
        /// Points collection for the left bottom segment
        /// </summary>
        protected PointCollection LeftBottomSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the left top segment
        /// </summary>
        protected PointCollection LeftTopSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the top segment
        /// </summary>
        protected PointCollection TopSegmPoints { get;  set; }

        /// <summary>
        /// Points collection for the bottom segment
        /// </summary>
        protected PointCollection BottomSegmPoints { get; set; }

        /// <summary>
        /// Points collection for the middle segment
        /// </summary>
        protected PointCollection MiddleSegmPoints { get; set; }

        /// <summary>
        /// Points collection for the right top segment
        /// </summary>
        protected PointCollection RightTopSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right bottom segment
        /// </summary>
        protected PointCollection RightBottomSegmPoints { get; private set; }

        protected double figureStartPointY;

        #endregion

        #region Constructor

        public SevenSegments()
        {
            PropertyChanged += OnPropertyChanged;
            vertRoundCoef = 5.5;
            horizRoundCoef = 15;
        }

        private void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            SegmentBase segments = (SegmentBase)sender;
            isPropertyCahnged = true;

            segments.InvalidateVisual();
        }

        #endregion

        #region Drawing

        protected override void OnRender(DrawingContext drawingContext)
        {
           base.OnRender(drawingContext);
           CalculateMeasures();

           AssignSegments();
           ClearSegmentsSelection();
           SetSegments();

            // Draws segments
            foreach (var entry in GeometryFigures)
            {

                if (SegmentsBrush.Any())
                {
                    var brush = SegmentsBrush.SingleOrDefault(s => s.Item1 == (int)entry.SegmentNumber);
                    Pen figurePen = new Pen(new SolidColorBrush(brush != null ? brush.Item3 : PenColor), 
                        PenThickness);


                    drawingContext.DrawGeometry(brush != null ? brush.Item2 : FillBrush,
                        figurePen, entry.Geometry);

                }
                else
                {
                    Pen figurePen = new Pen(new SolidColorBrush(entry.IsSelected ? SelectedPenColor : PenColor), PenThickness);

                    drawingContext.DrawGeometry(entry.IsSelected ? SelectedFillBrush : FillBrush,
                        figurePen, entry.Geometry);
                }
            }

            // Draws decimal dot
            DrawDot(drawingContext);

            // Draws colon
            DrawColon(drawingContext);
        }

        /// <summary>
        /// Clear selected segments and value
        /// </summary>
        public void ClearSegments()
        {
            Value = string.Empty;
            SelectedSegments = new List<int>();
            SegmentsBrush = new List<Tuple<int, Brush, Color>>();
        }

        /// <summary>
        /// Assigns a segment number to required path geometry. Order is important!
        /// </summary>
        protected virtual void AssignSegments()
        {
            GeometryFigures = new List<GeometryWithSegm>();

            GeometryFigures.Add(new GeometryWithSegm(LeftBottomSegement(), Segments.LeftBottom));
            GeometryFigures.Add(new GeometryWithSegm(LeftTopSegement(), Segments.LeftTop));
            GeometryFigures.Add(new GeometryWithSegm(RightTopSegement(), Segments.RightTop));
            GeometryFigures.Add(new GeometryWithSegm(RightBottomSegement(), Segments.RightBottom));
            GeometryFigures.Add(new GeometryWithSegm(MiddleSegement(), Segments.Middle));
            GeometryFigures.Add(new GeometryWithSegm(TopSegement(), Segments.Top));
            GeometryFigures.Add(new GeometryWithSegm(BottomSegement(), Segments.Bottom));
        }

        /// <summary>
        /// Selects required segments
        /// </summary>
        protected void SetSegments()
        {
            if (SelectedSegments.Any())
            {
                for (int i = 0; i < SelectedSegments.Count; i++)
                {
                    GeometryFigures.Single(t => (int)t.SegmentNumber == SelectedSegments[i]).IsSelected = true;
                }
            }
            else
            {
                ValueSegmentsSelection();
            }
        }


        /// <summary>
        /// Calculates required points and measures
        /// </summary>
        private void CalculateMeasures()
        {
            //Horiz. figure
            HorizSegH = ActualHeight / HorizSegDivider;
            HorizSegSmallPartH = HorizSegH / 4;

            //Vert. figure
            VertSegW = ActualWidth / VertSegDivider;
            VertSegPartW = (VertSegW / 3.5);
            VertSegSmallPartH = VertSegW / 3.5;
            VertSegBotPartW = VertSegW / 2;

            HorizSegSmallPartW = VertSegW / 4;

            //The points calculation
            MidPoint = ActualHeight / 2;
            GapW = GapWidth;

            DotDiameter = HorizSegH;
            ColonDiameter = HorizSegH;

            VirtualHeight = ShowDot ? ActualHeight - DotDiameter / 1.5 : ActualHeight;
            VirtualWidth = ShowDot ? ActualWidth - DotDiameter / 1.5 : ActualWidth;

            figureStartPointY = VirtualHeight - (HorizSegSmallPartH + GapW + VertSegSmallPartH);
            startPointThickness = PenThickness / 2;

        }

        /// <summary>
        /// Selects segments depending on the value 
        /// </summary>
        protected virtual void ValueSegmentsSelection()
        {
            int tempValue;
            if (int.TryParse(Value, out tempValue))
            {
                if (tempValue > 9) tempValue = 9;
                if (tempValue < 0) tempValue = 0;
                switch (tempValue)
                {
                    case 0:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top, (int)Segments.RightTop,
                            (int)Segments.RightBottom, (int)Segments.Bottom, (int)Segments.LeftBottom);
                        break;
                    case 1:
                        SelectSegments((int)Segments.RightTop, (int)Segments.RightBottom);
                        break;
                    case 2:
                        SelectSegments((int)Segments.Top, (int)Segments.RightTop, (int)Segments.Middle,
                            (int)Segments.LeftBottom, (int)Segments.Bottom);
                        break;
                    case 3:
                        SelectSegments((int)Segments.Top, (int)Segments.RightTop,
                            (int)Segments.Middle, (int)Segments.RightBottom, (int)Segments.Bottom);
                        break;
                    case 4:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.RightTop,
                            (int)Segments.Middle, (int)Segments.RightBottom);
                        break;
                    case 5:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top, (int)Segments.Middle,
                            (int)Segments.RightBottom, (int)Segments.Bottom);
                        break;
                    case 6:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top, (int)Segments.Middle,
                            (int)Segments.RightBottom, (int)Segments.LeftBottom, (int)Segments.Bottom);
                        break;
                    case 7:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top,
                            (int)Segments.RightTop, (int)Segments.RightBottom);
                        break;
                    case 8:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top, (int)Segments.RightTop,
                            (int)Segments.Middle,
                            (int)Segments.LeftBottom, (int)Segments.RightBottom, (int)Segments.Bottom);
                        break;
                    case 9:
                        SelectSegments((int)Segments.LeftTop, (int)Segments.Top, (int)Segments.RightTop,
                             (int)Segments.Middle, (int)Segments.RightBottom, (int)Segments.Bottom);
                        break;
                }
            }

            // Selects segment for the minus sign 
            if (Value == "-")
            {
                SelectSegments((int)Segments.Middle);
            }

        }


        /// <summary>
        /// Draws decimal dot separator
        /// </summary>
        protected void DrawDot(DrawingContext drawingContext)
        {
            if (ShowDot)
            {
                PathGeometry pathGeometry = new PathGeometry();
                Pen dotPen = new Pen(new SolidColorBrush(OnDot ? SelectedPenColor : PenColor), PenThickness);
                var centerPoint = new Point(ActualWidth - DotDiameter / 2, ActualHeight - DotDiameter / 2);
                pathGeometry = CreateEllipseGeometry(centerPoint, pathGeometry, DotDiameter / 2);
                drawingContext.DrawGeometry(OnDot ? SelectedFillBrush : FillBrush,
                    dotPen, pathGeometry);
            }
        }

        /// <summary>
        /// Draws colon
        /// </summary>
        private void DrawColon(DrawingContext drawingContext)
        {
            if (ShowColon)
            {
                PathGeometry pathGeometry = new PathGeometry();

                var hUpper = (MiddleSegmPoints[2].Y - GapW - HorizSegH) - (HorizSegH + GapW);
                var yTop = HorizSegH + GapW + hUpper / 2 + ColonDiameter / 2;
                var xTop = XByAngle(yTop) + VertSegW;

                var hLower = (BottomSegmPoints[2].Y - GapW) - (MiddleSegmPoints[0].Y + GapW + HorizSegH);
                var yBottom = MiddleSegmPoints[0].Y + GapW + HorizSegH + hLower / 2 - ColonDiameter / 2;
                var xBottom = XByAngle(yBottom) + VertSegW;

                var xTopMiddle = xTop + (((VirtualWidth - xBottom) - xTop) / 2);
                var xBottomMiddle = xBottom + (((VirtualWidth - xTop) - xBottom) / 2);

                Pen colonPen = new Pen(new SolidColorBrush(OnColon ? SelectedPenColor : PenColor), PenThickness);

                // the top ellipse
                var centerPoint = new Point(xTopMiddle, yTop);
                pathGeometry = CreateEllipseGeometry(centerPoint, pathGeometry, ColonDiameter / 2);
                drawingContext.DrawGeometry(OnColon ? SelectedFillBrush : FillBrush,
                    colonPen, pathGeometry);

                //the bottom ellipse
                centerPoint = new Point(xBottomMiddle, yBottom);
                pathGeometry = CreateEllipseGeometry(centerPoint, pathGeometry, ColonDiameter / 2);
                drawingContext.DrawGeometry(OnColon ? SelectedFillBrush : FillBrush,
                    colonPen, pathGeometry);

            }
        }

        private PathGeometry CreateEllipseGeometry(Point centerPoint, 
            PathGeometry pathGeometry,
            double diameter)
        {
            EllipseGeometry ellipseGeometry;
            SkewTransform transform;
            ellipseGeometry = new EllipseGeometry();
            ellipseGeometry.Center = centerPoint;
            ellipseGeometry.RadiusX = diameter;
            ellipseGeometry.RadiusY = diameter;

            pathGeometry = PathGeometry.CreateFromGeometry(ellipseGeometry);

            transform = new SkewTransform(-TiltAngle,
                0, centerPoint.X, centerPoint.Y);
            pathGeometry.Transform = transform;
            return pathGeometry;
        }


        /// <summary>
        /// Sets required geometry figures as selected
        /// </summary>
        protected void SelectSegments(params int[] segmNumbers)
        {
            for (int i = 0; i < segmNumbers.Length; i++)
            {
                GeometryFigures.Single(t => (int)t.SegmentNumber == segmNumbers[i]).IsSelected = true;
            }

        }

        /// <summary>
        /// Clears selection for all geometry figures 
        /// </summary>
        protected void ClearSegmentsSelection()
        {
            GeometryFigures.ForEach(c => c.IsSelected = false);
        }


        /// <summary>
        /// Draws custom path geometry
        /// </summary>
        protected PathGeometry SegmentPathGeometry(Point startPoint, PolyLineSegment polyLineSegment)
        {
            PathGeometry pathGeometry = new PathGeometry();

            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(polyLineSegment);
            return pathGeometry;
        }

        /// <summary>
        /// Required segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry SegmentGeometry(PointCollection assignPoints, PointCollection drawnPoints)
        {
            assignPoints = drawnPoints;
            Point startPoint = assignPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = assignPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// Returns X-coord by the angle and height
        /// </summary>
        /// <param name="y">Y-coordinate to calculate height</param>
        protected double XByAngle(double y)
        {
            var h = figureStartPointY - y;
            return (TanAngle() * h);
        }

        /// <summary>
        /// Returns tangent of the tilt angle in degrees
        /// </summary>
        protected double TanAngle()
        {
            return Math.Tan(TiltAngle * (Math.PI / 180.0));
        }

        /// <summary>
        /// Returns gap shift for the top and bottom segments
        /// </summary>
        private double GapShift()
        {
            return GapW * 0.75;
        }


        #endregion

        #region Points' locations

        /// <summary>
        /// Calulates points  for the left top segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetLeftTopSegmPoints()
        {
            PointCollection points = new PointCollection();

            var intermPoint = VirtualHeight / 2 - HorizSegH / 2;
            var startTopY = HorizSegSmallPartH + GapW + VertSegSmallPartH + startPointThickness;
            var x1 = XByAngle(startTopY);

            // the bezier point
            Point bezPoint;
            if (RoundedCorners)
            {
                var yBezier = (VirtualHeight - startPointThickness) / vertRoundCoef;
                var xBezier = RoundedCorners ? XByAngle(yBezier) : 0;
                bezPoint = new Point(xBezier + startPointThickness, yBezier);
            }
            else
            {
                bezPoint = new Point(x1 + startPointThickness, HorizSegSmallPartH + startPointThickness + GapW + VertSegSmallPartH);
            }


            startTopY = HorizSegSmallPartH + GapShift();
            var x2 = XByAngle(startTopY);

            startTopY = HorizSegH + GapW / 2;
            var x3 = XByAngle(startTopY);

            startTopY = intermPoint - (GapW / 2);
            var x4 = XByAngle(startTopY - startPointThickness);

            startTopY = (VirtualHeight / 2) - GapW / 2;
            var x5 = XByAngle(startTopY - startPointThickness);


            // three top points, starting from the left point
            points.Add(new Point(x1 + startPointThickness, HorizSegSmallPartH + GapW + VertSegSmallPartH + startPointThickness));
            points.Add(new Point(x2 + VertSegPartW + startPointThickness, HorizSegSmallPartH + startPointThickness + GapShift()));
            points.Add(new Point(x3 + VertSegW + startPointThickness, HorizSegH + startPointThickness + GapW / 2));

            // three bottom points, starting from the right point
            points.Add(new Point(x4 + VertSegW + startPointThickness, intermPoint - (GapW / 2)));
            points.Add(new Point(x5 + VertSegBotPartW + startPointThickness, (VirtualHeight / 2) - GapW / 2));
            points.Add(new Point(x5 + startPointThickness, (VirtualHeight / 2) - GapW / 2));


            // the point for rounded Bezier curve
            points.Add(bezPoint);

            return points;
        }

        /// <summary>
        /// Calulates points for the left bottom segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetLeftBottomSegmPoints()
        {
            var points = new PointCollection();

            var startBottomY = (VirtualHeight / 2) + HorizSegH / 2 + (GapW / 2);
            var startBottomY2 = VirtualHeight - (HorizSegH + GapW / 2) - startPointThickness;

            var x1 = XByAngle((VirtualHeight / 2) + GapW / 2);
            var x = XByAngle(startBottomY);
            var x2 = XByAngle(startBottomY2);

            // the bezier point
            Point bezPoint;
            if (RoundedCorners)
            {
                var yBezier = VirtualHeight - startPointThickness - VirtualHeight / vertRoundCoef;
                var xBezier = RoundedCorners ? XByAngle(yBezier) : 0;
                bezPoint = new Point(xBezier + startPointThickness, yBezier);
            }
            else
            {
                bezPoint = new Point(startPointThickness, figureStartPointY - startPointThickness);
            }

            // three top points, starting from left top point
            points.Add(new Point(x1 + startPointThickness, (VirtualHeight / 2) + GapW / 2));
            points.Add(new Point(x1 + VertSegBotPartW + startPointThickness, (VirtualHeight / 2) + GapW / 2));
            points.Add(new Point(x + VertSegW + startPointThickness, startBottomY));

            // three bottom points, starting from right
            points.Add(new Point(x2 + VertSegW + startPointThickness, startBottomY2));
            points.Add(new Point(VertSegPartW + startPointThickness, VirtualHeight - startPointThickness - (HorizSegSmallPartH + GapShift())));
            points.Add(new Point(startPointThickness, figureStartPointY - startPointThickness));

            // the point for rounded Bezier curve
            points.Add(bezPoint);

            return points;
        }

        /// <summary>
        /// Calulates points for the right bottom segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetRightBottomSegmPoints()
        {
            PointCollection points = new PointCollection();

            // three top points, starting from the left point
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[3].X, VirtualHeight - LeftTopSegmPoints[3].Y));
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[4].X, VirtualHeight - LeftTopSegmPoints[4].Y));
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[5].X, VirtualHeight - LeftTopSegmPoints[5].Y));

            // the point for rounded Bezier curve
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[6].X, VirtualHeight - LeftTopSegmPoints[6].Y));


            // three bottom points, starting from the right point
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[0].X, VirtualHeight - LeftTopSegmPoints[0].Y));
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[1].X, VirtualHeight - LeftTopSegmPoints[1].Y));
            points.Add(new Point(VirtualWidth - LeftTopSegmPoints[2].X, VirtualHeight - LeftTopSegmPoints[2].Y));

            return points;
        }


        /// <summary>
        /// Calulates points  for the right top segment
        /// </summary>
        protected PointCollection GetRightTopSegmPoints()
        {
            PointCollection points = new PointCollection();

            // three top points, starting from the left point
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[3].X, VirtualHeight - LeftBottomSegmPoints[3].Y));
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[4].X, VirtualHeight - LeftBottomSegmPoints[4].Y));
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[5].X, VirtualHeight - LeftBottomSegmPoints[5].Y));
            
            // the point for rounded Bezier curve
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[6].X, VirtualHeight - LeftBottomSegmPoints[6].Y));

            // three bottom points, starting from the right point
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[0].X, VirtualHeight - LeftBottomSegmPoints[0].Y));
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[1].X, VirtualHeight - LeftBottomSegmPoints[1].Y));
            points.Add(new Point(VirtualWidth - LeftBottomSegmPoints[2].X, VirtualHeight - LeftBottomSegmPoints[2].Y));
            
            return points;
        }

        /// <summary>
        /// Calculates points collection for the middle segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetMiddleSegmPoints()
        {
            var x = XByAngle((VirtualHeight / 2) + HorizSegH / 2) + (VertSegW + GapW);
            var x1 = XByAngle(VirtualHeight / 2) + VertSegBotPartW + GapW;
            var x2 = XByAngle(VirtualHeight / 2 - HorizSegH / 2) + VertSegW + GapW;

            PointCollection points = new PointCollection();

            // three left points, starting from the bottom point
            points.Add(new Point(x, (VirtualHeight / 2) + HorizSegH / 2));
            points.Add(new Point(x1, (VirtualHeight / 2)));
            points.Add(new Point(x2, (VirtualHeight / 2) - HorizSegH / 2));

            // three right points, starting from the top point
            points.Add(new Point(VirtualWidth - x, RightTopSegmPoints[6].Y + GapW / 2));
            points.Add(new Point(VirtualWidth - x1, VirtualHeight / 2));
            points.Add(new Point(VirtualWidth - x2, RightBottomSegmPoints[0].Y - GapW / 2));           
            return points;
        }


        /// <summary>
        /// Calulates points for the top segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetTopSegmPoints()
        {
            PointCollection points = new PointCollection();
            var topLeftX = LeftTopSegmPoints[1].X + HorizSegSmallPartW;
            var topRightX = RightTopSegmPoints[1].X - HorizSegSmallPartW;
            var coefRound = RoundedCorners ? VirtualWidth / horizRoundCoef : 0;

            // three left points, starting from the bottom point
            points.Add(new Point(LeftTopSegmPoints[2].X + GapW, HorizSegH + startPointThickness));
            points.Add(new Point(LeftTopSegmPoints[1].X + GapShift(), HorizSegSmallPartH + startPointThickness));
            points.Add(new Point(topLeftX, startPointThickness));

            // two top Bezier points starting from the left point
            points.Add(new Point(topLeftX + coefRound, startPointThickness));
            points.Add(new Point(topRightX - coefRound, startPointThickness));

            // three right points, starting from the top left point
            points.Add(new Point(topRightX, startPointThickness));
            points.Add(new Point(RightTopSegmPoints[1].X - GapShift(), HorizSegSmallPartH + startPointThickness));
            points.Add(new Point(RightTopSegmPoints[0].X - GapW, HorizSegH + startPointThickness));

            return points;
        }


        /// <summary>
        /// Calulates points for the bottom segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetBottomSegmPoints()
        {
            PointCollection points = new PointCollection();
            var botLeftX = LeftBottomSegmPoints[4].X + HorizSegSmallPartW;
            var botRightX = RightBottomSegmPoints[5].X - HorizSegSmallPartW;
            var coefRound = RoundedCorners ? VirtualWidth / horizRoundCoef : 0;

            // three left points, starting from the bottom point
            points.Add(new Point(botLeftX, VirtualHeight - startPointThickness));
            points.Add(new Point(LeftBottomSegmPoints[4].X + GapShift(), VirtualHeight - HorizSegSmallPartH - startPointThickness));
            points.Add(new Point(LeftBottomSegmPoints[3].X + GapW, VirtualHeight - HorizSegH - startPointThickness));

            // three right points, starting from the top left point
            points.Add(new Point(RightBottomSegmPoints[6].X - GapW, VirtualHeight - HorizSegH - startPointThickness));
            points.Add(new Point(RightBottomSegmPoints[5].X - GapShift(), VirtualHeight - HorizSegSmallPartH - startPointThickness));
            points.Add(new Point(botRightX, VirtualHeight - startPointThickness));

            // two bottom Bezier points starting from the right point
            points.Add(new Point(botRightX - coefRound, VirtualHeight - startPointThickness));
            points.Add(new Point(botLeftX + coefRound, VirtualHeight - startPointThickness));

            return points;
        }


        #endregion

        #region Segments' geometries

        /// <summary>
        /// Right top segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry RightTopSegement()
        {

            RightTopSegmPoints = GetRightTopSegmPoints();
            Point startPoint = RightTopSegmPoints[0];
            LineSegment line0 = new LineSegment(RightTopSegmPoints[0], true);
            LineSegment line1 = new LineSegment(RightTopSegmPoints[1], true);
            LineSegment line4 = new LineSegment(RightTopSegmPoints[4], true);
            LineSegment line5 = new LineSegment(RightTopSegmPoints[5], true);
            LineSegment line6 = new LineSegment(RightTopSegmPoints[6], true);

            // The Bezier curve for rounded corners
            var pointsBezier = new PointCollection
            {
                RightTopSegmPoints[1],
                RightTopSegmPoints[2],
                RightTopSegmPoints[3]
            };

            PolyBezierSegment bez = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezier)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(line0);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(bez);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(line5);
            pathFigure.Segments.Add(line6);

            return pathGeometry;
        }


        /// <summary>
        /// Middle segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry MiddleSegement()
        {
            MiddleSegmPoints = GetMiddleSegmPoints();

            Point startPoint = MiddleSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = MiddleSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }


        /// <summary>
        /// Right bottom segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry RightBottomSegement()
        {

            RightBottomSegmPoints = GetRightBottomSegmPoints();
            Point startPoint = RightBottomSegmPoints[0];
            LineSegment line0 = new LineSegment(RightBottomSegmPoints[0], true);
            LineSegment line1 = new LineSegment(RightBottomSegmPoints[1], true);
            LineSegment line2 = new LineSegment(RightBottomSegmPoints[2], true);
            LineSegment line3 = new LineSegment(RightBottomSegmPoints[3], true);
            LineSegment line6 = new LineSegment(RightBottomSegmPoints[6], true);

            // The Bezier curve for rounded corners
            var pointsBezier = new PointCollection
            {
                RightBottomSegmPoints[3],
                RightBottomSegmPoints[4],
                RightBottomSegmPoints[5]
            };

            PolyBezierSegment bez = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezier)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(line0);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(line2);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(bez);

            pathFigure.Segments.Add(line6);

            return pathGeometry;
        }


        /// <summary>
        /// Top segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry TopSegement()
        {
            TopSegmPoints = GetTopSegmPoints();
            Point startPoint = TopSegmPoints[0];
            LineSegment line0 = new LineSegment(TopSegmPoints[0], true);
            LineSegment line1 = new LineSegment(TopSegmPoints[1], true);
            LineSegment line3 = new LineSegment(TopSegmPoints[3], true);
            LineSegment line4 = new LineSegment(TopSegmPoints[4], true);
            LineSegment line6 = new LineSegment(TopSegmPoints[6], true);
            LineSegment line7 = new LineSegment(TopSegmPoints[7], true);

            // The left Bezier curve for rounded corners
            var pointsBezierLeft= new PointCollection
            {
                TopSegmPoints[1], TopSegmPoints[2], TopSegmPoints[3]
            };

            PolyBezierSegment bezLeft = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezierLeft)
            };


            // The right Bezier curve for rounded corners
            var pointsBezierRight= new PointCollection
            {
                TopSegmPoints[4], TopSegmPoints[5], TopSegmPoints[6]
            };

            PolyBezierSegment bezRight = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezierRight)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(line0);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(bezLeft);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(bezRight);
            pathFigure.Segments.Add(line6);
            pathFigure.Segments.Add(line7);

            return pathGeometry;
        }



        /// <summary>
        /// Left top segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry LeftTopSegement()
        {
            LeftTopSegmPoints = GetLeftTopSegmPoints();
            Point startPoint = LeftTopSegmPoints[6];
            LineSegment line0 = new LineSegment(LeftTopSegmPoints[6], true);
            LineSegment line1 = new LineSegment(LeftTopSegmPoints[1], true);
            LineSegment line2 = new LineSegment(LeftTopSegmPoints[2], true);
            LineSegment line3 = new LineSegment(LeftTopSegmPoints[3], true);
            LineSegment line4 = new LineSegment(LeftTopSegmPoints[4], true);
            LineSegment line5 = new LineSegment(LeftTopSegmPoints[5], true);

            // The Bezier curve for rounded corners
            var pointsBezier = new PointCollection
            {
                LeftTopSegmPoints[6],
                LeftTopSegmPoints[0],
                LeftTopSegmPoints[1]
            };

            PolyBezierSegment bez = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezier)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(bez);
            pathFigure.Segments.Add(line2);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(line4); 
            pathFigure.Segments.Add(line5);
            

            return pathGeometry;
        }


        

        /// <summary>
        /// Left Bottom segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry LeftBottomSegement()
        {
            LeftBottomSegmPoints = GetLeftBottomSegmPoints();
            Point startPoint = LeftBottomSegmPoints[0];
            LineSegment line0 = new LineSegment(LeftBottomSegmPoints[0], true);
            LineSegment line1 = new LineSegment(LeftBottomSegmPoints[1], true);
            LineSegment line2 = new LineSegment(LeftBottomSegmPoints[2], true);
            LineSegment line3 = new LineSegment(LeftBottomSegmPoints[3], true);
            LineSegment line4 = new LineSegment(LeftBottomSegmPoints[4], true);

            // The Bezier curve for rounded corners
            var pointsBezier = new PointCollection
            {
                LeftBottomSegmPoints[4],
                LeftBottomSegmPoints[5],
                LeftBottomSegmPoints[6]
            };

            PolyBezierSegment bez = new PolyBezierSegment  
            {
                Points = new PointCollection(pointsBezier)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            pathFigure.Segments.Add(line0);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(line2);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(bez);
            
            return pathGeometry;
        }




        /// <summary>
        /// Bottom segment drawing
        /// </summary>
        protected PathGeometry BottomSegement()
        {
            BottomSegmPoints = GetBottomSegmPoints();
            Point startPoint = BottomSegmPoints[1];

            LineSegment line0 = new LineSegment(BottomSegmPoints[0], true);
            LineSegment line1 = new LineSegment(BottomSegmPoints[1], true);
            LineSegment line2 = new LineSegment(BottomSegmPoints[2], true);
            LineSegment line3 = new LineSegment(BottomSegmPoints[3], true);
            LineSegment line4 = new LineSegment(BottomSegmPoints[4], true);
            LineSegment line6 = new LineSegment(BottomSegmPoints[6], true);
            LineSegment line7 = new LineSegment(BottomSegmPoints[7], true);


            // The right Bezier curve for rounded corners
            var pointsBezierRight = new PointCollection
            {
                BottomSegmPoints[4], BottomSegmPoints[5], BottomSegmPoints[6]
            };

            PolyBezierSegment bezRight = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezierRight)
            };

            // The left Bezier curve for rounded corners
            var pointsBezierLeft = new PointCollection
            {
                BottomSegmPoints[7], BottomSegmPoints[0], BottomSegmPoints[1]
            };

            PolyBezierSegment bezLeft = new PolyBezierSegment
            {
                Points = new PointCollection(pointsBezierLeft)
            };

            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure();
            pathFigure.StartPoint = startPoint;
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);

            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(line2);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(bezRight);
            pathFigure.Segments.Add(line6);
            pathFigure.Segments.Add(line7);
            pathFigure.Segments.Add(bezLeft);

            return pathGeometry;
        }

        #endregion

    }
}
