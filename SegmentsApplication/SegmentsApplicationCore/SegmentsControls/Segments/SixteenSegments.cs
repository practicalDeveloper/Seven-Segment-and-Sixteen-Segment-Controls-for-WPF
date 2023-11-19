using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SegmentsControls
{
    public class SixteenSegments : SevenSegments
    {
        /// <summary>
        /// The width of diagonal segment
        /// </summary>
        protected double DiagSegW;

        #region Protected variables

        /// <summary>
        /// Points collection for the left top horiz. segment
        /// </summary>
        protected PointCollection LeftTopHorizSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right top horiz. segment
        /// </summary>
        protected PointCollection RightTopHorizSegmPoints { get; private set; }


        /// <summary>
        /// Points collection for the left bottom horiz. segment
        /// </summary>
        protected PointCollection LeftBottomHorizSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right bottom horiz. segment
        /// </summary>
        protected PointCollection RightBottomHorizSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the left middle segment
        /// </summary>
        protected PointCollection LeftMiddleSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right middle segment
        /// </summary>
        protected PointCollection RightMiddleSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the top vertical segment
        /// </summary>
        protected PointCollection TopVerticalSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the bottom vertical segment
        /// </summary>
        protected PointCollection BottomVerticalSegmPoints { get; private set; }


        /// <summary>
        /// Points collection for the left bottom diagonal segment
        /// </summary>
        protected PointCollection BottomLeftDiagSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the left top diagonal segment
        /// </summary>
        protected PointCollection TopLeftDiagSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right top diagonal segment
        /// </summary>
        protected PointCollection TopRightDiagSegmPoints { get; private set; }

        /// <summary>
        /// Points collection for the right bottom diagonal segment
        /// </summary>
        protected PointCollection BottomRightDiagSegmPoints { get; private set; }

        #endregion

        static SixteenSegments()
        {
            VertSegDividerProperty.OverrideMetadata(
                    typeof(SixteenSegments),
                    new FrameworkPropertyMetadata(defVertDividerSixteen));


            HorizSegDividerProperty.OverrideMetadata(
                typeof(SixteenSegments),
                new FrameworkPropertyMetadata(defHorizDividerSixteen));
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            
            base.OnRender(drawingContext);
            
        }

        /// <summary>
        /// Selects segments depending on the value 
        /// </summary>
        protected override void ValueSegmentsSelection()
        {
            char tempValue = Value.ToCharArray().Count() > 0 ? Value[0] : ' ';

            if (tempValue == '0') SelectSegments(15, 16, 1, 2, 17, 18, 4, 5, 11, 12);
            else if (tempValue == '1') SelectSegments(1, 2, 11);
            else if (tempValue == '2') SelectSegments(15, 16, 1, 7, 8, 4, 17, 18);
            else if (tempValue == '3') SelectSegments(15, 16, 1, 7, 8, 2, 17, 18);
            else if (tempValue == '4') SelectSegments(5, 7, 8, 1, 2);
            else if (tempValue == '5') SelectSegments(15, 16, 5, 7, 8, 2, 17, 18);
            else if (tempValue == '6') SelectSegments(15, 16, 5, 7, 8, 4, 17, 18, 2);
            else if (tempValue == '7') SelectSegments(15, 16, 1, 2);
            else if (tempValue == '8') SelectSegments(15, 16, 1, 2, 17, 18, 4, 5, 7, 8);
            else if (tempValue == '9') SelectSegments(15, 16, 1, 2, 17, 18, 5, 7, 8);
            else if (tempValue == 'A') SelectSegments(15, 16, 1, 2, 4, 5, 7, 8);
            else if (tempValue == 'B') SelectSegments(15, 16, 1, 2, 17, 18, 8, 10, 13);
            else if (tempValue == 'C') SelectSegments(15, 16, 5, 4, 17, 18);
            else if (tempValue == 'D') SelectSegments(15, 16, 1, 2, 17, 18, 10, 13);
            else if (tempValue == 'E') SelectSegments(15, 16, 5, 4, 17, 18, 7, 8);
            else if (tempValue == 'F') SelectSegments(15, 16, 5, 7, 4);
            else if (tempValue == 'G') SelectSegments(15, 16, 5, 8, 4, 17, 18, 2);
            else if (tempValue == 'H') SelectSegments(4, 5, 8, 7, 1, 2);
            else if (tempValue == 'I') SelectSegments(15, 16, 17, 18, 10, 13);
            else if (tempValue == 'J') SelectSegments(1, 2, 17, 18, 4);
            else if (tempValue == 'K') SelectSegments(4, 5, 7, 11, 14);
            else if (tempValue == 'L') SelectSegments(4, 5, 17, 18);
            else if (tempValue == 'M') SelectSegments(4, 5, 9, 11, 1, 2);
            else if (tempValue == 'N') SelectSegments(4, 5, 9, 14, 1, 2);
            else if (tempValue == 'O') SelectSegments(4, 5, 1, 2, 15, 16, 17, 18);
            else if (tempValue == 'P') SelectSegments(4, 5, 7, 8, 15, 16, 1);
            else if (tempValue == 'Q') SelectSegments(4, 5, 1, 2, 15, 16, 17, 18, 14);
            else if (tempValue == 'R') SelectSegments(4, 5, 7, 8, 15, 16, 1, 14);
            else if (tempValue == 'S') SelectSegments(15, 16, 5, 7, 8, 2, 17, 18);
            else if (tempValue == 'T') SelectSegments(15, 16, 10, 13);
            else if (tempValue == 'U') SelectSegments(4, 5, 1, 2, 17, 18);
            else if (tempValue == 'V') SelectSegments(4, 5, 12, 11);
            else if (tempValue == 'W') SelectSegments(4, 5, 1, 2, 12, 14);
            else if (tempValue == 'X') SelectSegments(11, 12, 9, 14);
            else if (tempValue == 'Y') SelectSegments(1, 5, 13, 7, 8);
            else if (tempValue == 'Z') SelectSegments(15, 16, 11, 12, 17, 18);
            else if (tempValue == '-') SelectSegments(7, 8);
        }

        protected override void AssignSegments()
        {
            GeometryFigures = new List<GeometryWithSegm>();
            DiagSegW = VertSegBotPartW;

            // Assigns a segment number to required path geometry. Order is important!
            GeometryFigures.Add(new GeometryWithSegm(LeftBottomSegement(), Segments.LeftBottom));
            GeometryFigures.Add(new GeometryWithSegm(LeftTopSegement(), Segments.LeftTop));
            GeometryFigures.Add(new GeometryWithSegm(RightTopSegement(), Segments.RightTop));
            GeometryFigures.Add(new GeometryWithSegm(RightBottomSegement(), Segments.RightBottom));

            TopSegmPoints = GetTopSegmPoints();
            BottomSegmPoints = GetBottomSegmPoints();
            GeometryFigures.Add(new GeometryWithSegm(LeftTopHorizSegement(), Segments.LeftHorizTop));
            GeometryFigures.Add(new GeometryWithSegm(RightTopHorizSegement(), Segments.RightHorizTop));
            GeometryFigures.Add(new GeometryWithSegm(LeftBottomHorizSegement(), Segments.LeftHorizBottom));
            GeometryFigures.Add(new GeometryWithSegm(RightBottomHorizSegement(), Segments.RightHorizBottom));

            MiddleSegmPoints = GetMiddleSegmPoints();
            GeometryFigures.Add(new GeometryWithSegm(LeftMiddleSegement(), Segments.LeftMiddle));
            GeometryFigures.Add(new GeometryWithSegm(RightMiddleSegement(), Segments.RightMiddle));
            GeometryFigures.Add(new GeometryWithSegm(TopVerticalSegment(), Segments.TopVertical));
            GeometryFigures.Add(new GeometryWithSegm(BottomVerticalSegment(), Segments.BottomVertical));
            GeometryFigures.Add(new GeometryWithSegm(BottomLeftDiagSegment(), Segments.LeftBottomDiagonal));
            GeometryFigures.Add(new GeometryWithSegm(TopLeftDiagSegment(), Segments.LeftTopDiagonal));
            GeometryFigures.Add(new GeometryWithSegm(TopRightDiagSegment(), Segments.RightTopDiagonal));
            GeometryFigures.Add(new GeometryWithSegm(BottomRightDiagSegment(), Segments.RightBottomDiagonal));

        }


        #region Points locations


        /// <summary>
        /// Calulates points for the left top horiz. segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetLeftTopHorizSegmPoints()
        {
            PointCollection points = new PointCollection();
            var x1 = XByAngle(0) + VertSegW + GapW;
            var x2 = VirtualWidth - (XByAngle(VirtualHeight) + VertSegW + GapW);

            var topW = x2 - x1;
            var botW = TopSegmPoints[7].X - TopSegmPoints[0].X;

            // three left points, starting from the bottom point
            points.Add(TopSegmPoints[0]);
            points.Add(TopSegmPoints[1]);
            points.Add(TopSegmPoints[2]);

            // the Bezier point 
            points.Add(TopSegmPoints[3]);

            // two right points, starting from the top point
            points.Add(new Point(x1 + (topW / 2 - GapW / 2),
                TopSegmPoints[2].Y));
            points.Add(new Point(TopSegmPoints[0].X + (botW / 2 - GapW / 2),
                TopSegmPoints[7].Y));


            return points;
        }

        /// <summary>
        /// Calulates points for the right top horiz. segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetRightTopHorizSegmPoints()
        {
            PointCollection points = new PointCollection();
            var x1 = XByAngle(0) + VertSegW + GapW;
            var x2 = VirtualWidth - (XByAngle(VirtualHeight) + VertSegW + GapW);

            var topW = x2 - x1;
            var botW = TopSegmPoints[7].X - TopSegmPoints[0].X;

            // two left points, starting from the bottom point
            points.Add(new Point(TopSegmPoints[0].X + (botW / 2 + GapW / 2),
                TopSegmPoints[7].Y));
            points.Add(new Point(x1 + (topW / 2 + GapW / 2),
                TopSegmPoints[2].Y));

            // the Bezier point 
            points.Add(TopSegmPoints[4]);

            // three right points, starting from the top point
            points.Add(TopSegmPoints[5]);
            points.Add(TopSegmPoints[6]);
            points.Add(TopSegmPoints[7]);

            return points;
        }

        /// <summary>
        /// Calulates points for the left bottom horiz. segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetLeftBottomHorizSegmPoints()
        {
            PointCollection points = new PointCollection();
            // three left points, starting from the bottom point
            points.Add(BottomSegmPoints[0]);
            points.Add(BottomSegmPoints[1]);
            points.Add(BottomSegmPoints[2]);

            // two right points, starting from the top point
            points.Add(new Point(VirtualWidth - RightTopHorizSegmPoints[0].X,
                BottomSegmPoints[2].Y));
            points.Add(new Point(VirtualWidth - RightTopHorizSegmPoints[1].X,
                BottomSegmPoints[0].Y));


            // the Bezier point 
            points.Add(BottomSegmPoints[7]);

            return points;
        }

        /// <summary>
        /// Calulates points for the right bottom horiz. segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetRightBottomHorizSegmPoints()
        {
            PointCollection points = new PointCollection();
            // two left points, starting from the bottom point
            points.Add(new Point(VirtualWidth - LeftTopHorizSegmPoints[4].X,
                BottomSegmPoints[0].Y));
            points.Add(new Point(VirtualWidth - LeftTopHorizSegmPoints[5].X,
                BottomSegmPoints[2].Y));

            // three right points, starting from the top point
            points.Add(BottomSegmPoints[3]);
            points.Add(BottomSegmPoints[4]);
            points.Add(BottomSegmPoints[5]);

            // the Bezier point 
            points.Add(BottomSegmPoints[6]);

            return points;
        }

        /// <summary>
        /// Calulates points for the left middle segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetLeftMiddleSegmPoints()
        {
            PointCollection points = new PointCollection();
            var topW = MiddleSegmPoints[3].X - MiddleSegmPoints[2].X;
            var botW = MiddleSegmPoints[5].X - MiddleSegmPoints[0].X;

            // three left points, starting from the bottom point
            points.Add(MiddleSegmPoints[0]);
            points.Add(MiddleSegmPoints[1]);
            points.Add(MiddleSegmPoints[2]);

            // two right points, starting from the top point
            points.Add(new Point(MiddleSegmPoints[2].X + (topW / 2 - GapW / 2),
                MiddleSegmPoints[2].Y));
            points.Add(new Point(MiddleSegmPoints[0].X + (botW / 2 - GapW / 2),
                MiddleSegmPoints[5].Y));


            return points;
        }

        /// <summary>
        /// Calulates points for the right middle segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetRightMiddleSegmPoints()
        {
            PointCollection points = new PointCollection();
            var topW = MiddleSegmPoints[3].X - MiddleSegmPoints[2].X;
            var botW = MiddleSegmPoints[5].X - MiddleSegmPoints[0].X;

            // two left points, starting from the bottom point
            points.Add(new Point(MiddleSegmPoints[0].X + (botW / 2 + GapW / 2),
                MiddleSegmPoints[5].Y));
            points.Add(new Point(MiddleSegmPoints[2].X + (topW / 2 + GapW / 2),
                MiddleSegmPoints[2].Y));

            // three right points, starting from the top point
            points.Add(MiddleSegmPoints[3]);
            points.Add(MiddleSegmPoints[4]);
            points.Add(MiddleSegmPoints[5]);

            return points;
        }

        /// <summary>
        /// Points collection for the top vertical segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetTopVerticalSegmPoints()
        {
            PointCollection points = new PointCollection();
            var w = RightTopSegmPoints[0].X - LeftTopSegmPoints[2].X;
            var botY= MiddleSegmPoints[2].Y - GapW - HorizSegH;
            //var segmH = figureStartPointY - botY;
            var divider = VertSegW / 2.5;
            var xMid = XByAngle(botY) + VertSegW;

            // two top points, starting from the left point
            points.Add(new Point(LeftTopSegmPoints[2].X + (w / 2 - divider),
                HorizSegH + GapW));
            points.Add(new Point(LeftTopSegmPoints[2].X + (w / 2 + divider),
                HorizSegH + GapW));


            // four bottom points, starting from the right point
            points.Add(new Point(xMid + (w / 2 + divider), botY));
            points.Add(new Point(LeftTopSegmPoints[3].X + (w / 2 + divider / 2),
                  MiddleSegmPoints[2].Y - GapW));
            points.Add(new Point(LeftTopSegmPoints[3].X + (w / 2 - divider / 2),
                 MiddleSegmPoints[2].Y - GapW));
            points.Add(new Point(xMid + (w / 2 - divider), botY));

            return points;
        }


        /// <summary>
        /// Points collection for the bottom vertical segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetBottomVerticalSegmPoints()
        {
            PointCollection points = new PointCollection();
            var w = RightBottomSegmPoints[0].X - LeftBottomSegmPoints[2].X;
            var botY = MiddleSegmPoints[0].Y + GapW + HorizSegH;
            var xMid = XByAngle(botY) + VertSegW;
            var divider = VertSegW / 2.5;

            // four top points, starting from the left point
            points.Add(new Point(xMid + (w/2 - divider), botY));
            points.Add(new Point(LeftBottomSegmPoints[2].X + (w / 2 - divider / 2),
                MiddleSegmPoints[0].Y + GapW));
            points.Add(new Point(LeftBottomSegmPoints[2].X + (w / 2 + divider / 2),
                MiddleSegmPoints[0].Y + GapW));
            points.Add(new Point(xMid + (w/2 + divider), botY));


            // two bottom points, starting from the right point
            points.Add(new Point(LeftBottomSegmPoints[3].X + (w / 2 + divider),
                BottomSegmPoints[2].Y - GapW));

            points.Add(new Point(LeftBottomSegmPoints[3].X + (w / 2 - divider),
                BottomSegmPoints[2].Y - GapW));

            return points;
        }


        /// <summary>
        /// Points collection for the left bottom diagonal segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetBottomLeftDiagSegmPoints()
        {
            PointCollection points = new PointCollection();

            var yBot1 = BottomSegmPoints[2].Y - GapW;
            var xBot1 = XByAngle(yBot1) + VertSegW; 

            var yBot2 = yBot1 - HorizSegH/2;
            var xBot2 = XByAngle(yBot2) + VertSegW; 

            // three top points, starting from the left point
            points.Add(new Point(BottomVerticalSegmPoints[1].X - GapW - DiagSegW, 
                BottomVerticalSegmPoints[1].Y));
            points.Add(new Point(BottomVerticalSegmPoints[1].X - GapW,
                BottomVerticalSegmPoints[1].Y));
            points.Add(new Point(BottomVerticalSegmPoints[0].X - GapW,
                BottomVerticalSegmPoints[0].Y));

            // three bottom points, starting from the right point
            points.Add(new Point(xBot1 + GapW + DiagSegW, yBot1));
            points.Add(new Point(xBot1 + GapW, yBot1));
            points.Add(new Point(xBot2 + GapW, yBot2));

            return points;
        }

        /// <summary>
        /// Points collection for the left top diagonal segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetTopLeftDiagSegmPoints()
        {
            PointCollection points = new PointCollection();
            var y1 = HorizSegH + GapW + HorizSegH/2;
            var x1 = XByAngle(y1) + VertSegW;

            var y2 = HorizSegH + GapW;
            var x2 = XByAngle(y2) + VertSegW;

            // three top points, starting from the left point
            points.Add(new Point(x1 + GapW,y1));
            points.Add(new Point(x2 + GapW, y2));
            points.Add(new Point(x2 + GapW + DiagSegW, y2));

            // three bottom points, starting from the right point
            points.Add(new Point(TopVerticalSegmPoints[5].X - GapW,
                TopVerticalSegmPoints[5].Y));
            points.Add(new Point(TopVerticalSegmPoints[4].X - GapW,
                TopVerticalSegmPoints[4].Y));
            points.Add(new Point(TopVerticalSegmPoints[4].X - GapW - DiagSegW,
                TopVerticalSegmPoints[4].Y));

            return points;
        }

        /// <summary>
        /// Points collection for the right top diagonal segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetTopRightDiagSegmPoints()
        {
            PointCollection points = new PointCollection();

            // three top points, starting from the left point
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[3].X, VirtualHeight - BottomLeftDiagSegmPoints[3].Y));
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[4].X, VirtualHeight - BottomLeftDiagSegmPoints[4].Y));
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[5].X, VirtualHeight - BottomLeftDiagSegmPoints[5].Y));

            // three bottom points, starting from the right point
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[0].X, VirtualHeight - BottomLeftDiagSegmPoints[0].Y));
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[1].X, VirtualHeight - BottomLeftDiagSegmPoints[1].Y));
            points.Add(new Point(VirtualWidth - BottomLeftDiagSegmPoints[2].X, VirtualHeight - BottomLeftDiagSegmPoints[2].Y));

            return points;
        }

        /// <summary>
        /// Points collection for the right bottom diagonal segment
        /// </summary>
        /// <returns></returns>
        protected PointCollection GetBottomRightDiagSegmPoints()
        {
            PointCollection points = new PointCollection();

            // three top points, starting from the left point
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[3].X, VirtualHeight - TopLeftDiagSegmPoints[3].Y));
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[4].X, VirtualHeight - TopLeftDiagSegmPoints[4].Y));
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[5].X, VirtualHeight - TopLeftDiagSegmPoints[5].Y));

            // three bottom points, starting from the right point
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[0].X, VirtualHeight - TopLeftDiagSegmPoints[0].Y));
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[1].X, VirtualHeight - TopLeftDiagSegmPoints[1].Y));
            points.Add(new Point(VirtualWidth - TopLeftDiagSegmPoints[2].X, VirtualHeight - TopLeftDiagSegmPoints[2].Y));

            return points;
        }


        #endregion

        #region Segments drawing


        /// <summary>
        /// Left top horiz. segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry LeftTopHorizSegement()
        {

            LeftTopHorizSegmPoints = GetLeftTopHorizSegmPoints();
            Point startPoint = LeftTopHorizSegmPoints[0];
            LineSegment line0 = new LineSegment(LeftTopHorizSegmPoints[0], true);
            LineSegment line1 = new LineSegment(LeftTopHorizSegmPoints[1], true);
            LineSegment line3 = new LineSegment(LeftTopHorizSegmPoints[3], true);
            LineSegment line4 = new LineSegment(LeftTopHorizSegmPoints[4], true);
            LineSegment line5 = new LineSegment(LeftTopHorizSegmPoints[5], true);

            // The Bezier curve for rounded corners
            var pointsBezierLeft = new PointCollection
            {
                LeftTopHorizSegmPoints[1], LeftTopHorizSegmPoints[2], LeftTopHorizSegmPoints[3]
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
            pathFigure.Segments.Add(line0);
            pathFigure.Segments.Add(line1);
            pathFigure.Segments.Add(bezLeft);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(line5);

            return pathGeometry;
        }

        /// <summary>
        /// Right top horiz. segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry RightTopHorizSegement()
        {
            RightTopHorizSegmPoints = GetRightTopHorizSegmPoints();
            Point startPoint = RightTopHorizSegmPoints[0];
            LineSegment line0 = new LineSegment(RightTopHorizSegmPoints[0], true);
            LineSegment line1 = new LineSegment(RightTopHorizSegmPoints[1], true); 
            LineSegment line2 = new LineSegment(RightTopHorizSegmPoints[2], true);
            LineSegment line3 = new LineSegment(RightTopHorizSegmPoints[3], true);
            LineSegment line4 = new LineSegment(RightTopHorizSegmPoints[4], true);
            LineSegment line5 = new LineSegment(RightTopHorizSegmPoints[5], true);

            // The Bezier curve for rounded corners
            var pointsBezier = new PointCollection
            {
                RightTopHorizSegmPoints[2], RightTopHorizSegmPoints[3], RightTopHorizSegmPoints[4]
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
            pathFigure.Segments.Add(bez);
            pathFigure.Segments.Add(line4);
            pathFigure.Segments.Add(line5);

            return pathGeometry;
        }

        /// <summary>
        /// Left bottom horiz.segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry LeftBottomHorizSegement()
        {
            LeftBottomHorizSegmPoints = GetLeftBottomHorizSegmPoints();
            Point startPoint = LeftBottomHorizSegmPoints[1];

            LineSegment line0 = new LineSegment(LeftBottomHorizSegmPoints[0], true);
            LineSegment line1 = new LineSegment(LeftBottomHorizSegmPoints[1], true);
            LineSegment line2 = new LineSegment(LeftBottomHorizSegmPoints[2], true);
            LineSegment line3 = new LineSegment(LeftBottomHorizSegmPoints[3], true);
            LineSegment line4 = new LineSegment(LeftBottomHorizSegmPoints[4], true);
            LineSegment line5 = new LineSegment(LeftBottomHorizSegmPoints[5], true);


            // The left Bezier curve for rounded corners
            var pointsBezierLeft = new PointCollection
            {
                LeftBottomHorizSegmPoints[5], LeftBottomHorizSegmPoints[0], LeftBottomHorizSegmPoints[1]
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
            pathFigure.Segments.Add(line5);
            pathFigure.Segments.Add(bezLeft);

            return pathGeometry;
        }

        /// <summary>
        /// Right bottom horiz.segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry RightBottomHorizSegement()
        {
            RightBottomHorizSegmPoints = GetRightBottomHorizSegmPoints();
            Point startPoint = RightBottomHorizSegmPoints[0];

            LineSegment line0 = new LineSegment(RightBottomHorizSegmPoints[0], true);
            LineSegment line1 = new LineSegment(RightBottomHorizSegmPoints[1], true);
            LineSegment line2 = new LineSegment(RightBottomHorizSegmPoints[2], true);
            LineSegment line3 = new LineSegment(RightBottomHorizSegmPoints[3], true);
            LineSegment line4 = new LineSegment(RightBottomHorizSegmPoints[4], true);
            LineSegment line5 = new LineSegment(RightBottomHorizSegmPoints[5], true);


            // The right Bezier curve for rounded corners
            var pointsBezierRight = new PointCollection
            {
                RightBottomHorizSegmPoints[3], RightBottomHorizSegmPoints[4], RightBottomHorizSegmPoints[5]
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
            pathFigure.Segments.Add(line2);
            pathFigure.Segments.Add(line3);
            pathFigure.Segments.Add(bezRight);
            pathFigure.Segments.Add(line5);



            return pathGeometry;
        }

        /// <summary>
        /// Left middle segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry LeftMiddleSegement()
        {
            LeftMiddleSegmPoints = GetLeftMiddleSegmPoints();
            Point startPoint = LeftMiddleSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = LeftMiddleSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// Middle segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry RightMiddleSegement()
        {
            RightMiddleSegmPoints = GetRightMiddleSegmPoints();

            Point startPoint = RightMiddleSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = RightMiddleSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }


        /// <summary>
        /// The top vertical segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry TopVerticalSegment()
        {
            TopVerticalSegmPoints = GetTopVerticalSegmPoints();
            Point startPoint = TopVerticalSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = TopVerticalSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// The bottom vertical segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry BottomVerticalSegment()
        {
            BottomVerticalSegmPoints = GetBottomVerticalSegmPoints();
            Point startPoint = BottomVerticalSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = BottomVerticalSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }


        /// <summary>
        /// The left bottom diagonal segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry BottomLeftDiagSegment()
        {
            BottomLeftDiagSegmPoints = GetBottomLeftDiagSegmPoints();
            Point startPoint = BottomLeftDiagSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = BottomLeftDiagSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// The left top diagonal segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry TopLeftDiagSegment()
        {
            TopLeftDiagSegmPoints = GetTopLeftDiagSegmPoints();
            Point startPoint = TopLeftDiagSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = TopLeftDiagSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// The right top diagonal segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry TopRightDiagSegment()
        {
            TopRightDiagSegmPoints = GetTopRightDiagSegmPoints();
            Point startPoint = TopRightDiagSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = TopRightDiagSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }

        /// <summary>
        /// The right bottom diagonal segment drawing
        /// </summary>
        /// <returns></returns>
        protected PathGeometry BottomRightDiagSegment()
        {
            BottomRightDiagSegmPoints = GetBottomRightDiagSegmPoints();
            Point startPoint = BottomRightDiagSegmPoints[0];
            PolyLineSegment segment = new PolyLineSegment { Points = BottomRightDiagSegmPoints };
            return SegmentPathGeometry(startPoint, segment);
        }



        #endregion


    }
}
