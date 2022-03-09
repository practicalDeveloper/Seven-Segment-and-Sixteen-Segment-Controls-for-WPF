using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace SegmentsApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[] segments = 
            {
                (int) SegmentsControls.SixteenSegmentsNumbers.LeftMiddle,
                (int) SegmentsControls.SixteenSegmentsNumbers.RightBottomDiagonal
            };

           MySegments.ClearSegments();
           MySegments.SelectedSegments = segments.ToList();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MySegments.ClearSegments();
            MySegments.Value = "1";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Tuple<int, Brush, Color>[] brushes =
            {
                new Tuple<int, Brush, Color>(
                (int)SegmentsControls.SixteenSegmentsNumbers.RightVertTop, 
                new SolidColorBrush(Colors.Yellow),
                Colors.Red),

                new Tuple<int, Brush, Color>(
                (int)SegmentsControls.SixteenSegmentsNumbers.RightVertBottom, 
                new SolidColorBrush(Colors.Orange),
                Colors.Blue)
            };

            MySegments.ClearSegments();
            MySegments.SegmentsBrush = brushes.ToList();

        }



    }
}
