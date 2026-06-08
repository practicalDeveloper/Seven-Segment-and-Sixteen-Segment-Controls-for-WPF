using SegmentsControls;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace SegmentsApplication
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string sevenSegmentValue;
        private string sevenSegmentStackValue;
        private string sixteenSegmentValue;
        private string sixteenSegmentStackValue;
        private string sixteenSegmentStackValue2;
        private ObservableCollection<SevenSegmentsFlags> selectedSevenSegments;
        private ObservableCollection<SixteenSegmentsFlags> selectedSixteenSegments;
        private ObservableCollection<SegmentBrush<SixteenSegmentsFlags>> sixteenSegmentsBrushes;
        private ObservableCollection<SegmentBrush<SevenSegmentsFlags>> sevenSegmentsBrushes;


        public string SevenSegmentValue
        {
            get
            {
                return sevenSegmentValue;
            }
            set
            {
                sevenSegmentValue = value;
                OnPropertyChanged("SevenSegmentValue");
            }
        }

        public string SixteenSegmentValue
        {
            get
            {
                return sixteenSegmentValue;
            }
            set
            {
                sixteenSegmentValue = value;
                OnPropertyChanged("SixteenSegmentValue");
            }
        }

        public string SevenSegmentStackValue
        {
            get
            {
                return sevenSegmentStackValue;
            }
            set
            {
                sevenSegmentStackValue = value;
                OnPropertyChanged("SevenSegmentStackValue");
            }
        }


        public string SixteenSegmentStackValue
        {
            get
            {
                return sixteenSegmentStackValue;
            }
            set
            {
                sixteenSegmentStackValue = value;
                OnPropertyChanged("SixteenSegmentStackValue");
            }
        }

        public string SixteenSegmentStackValue2
        {
            get
            {
                return sixteenSegmentStackValue2;
            }
            set
            {
                sixteenSegmentStackValue2 = value;
                OnPropertyChanged("SixteenSegmentStackValue2");
            }
        }

        public ObservableCollection<SevenSegmentsFlags> SelectedSevenSegments
        {
            get
            {
                return selectedSevenSegments;
            }
            set
            {
                selectedSevenSegments = value;
                OnPropertyChanged("SelectedSevenSegments");
            }
        }

        public ObservableCollection<SixteenSegmentsFlags> SelectedSixteenSegments
        {
            get
            {
                return selectedSixteenSegments;
            }
            set
            {
                selectedSixteenSegments = value;
                OnPropertyChanged("SelectedSixteenSegments");
            }
        }

        public ObservableCollection<SegmentBrush<SixteenSegmentsFlags>> SixteenSegmentsBrushes
        {
            get
            {
                return sixteenSegmentsBrushes;
            }
            set
            {
                sixteenSegmentsBrushes = value;
                OnPropertyChanged("SixteenSegmentsBrushes");
            }
        }


        public ObservableCollection<SegmentBrush<SevenSegmentsFlags>> SevenSegmentsBrushes
        {
            get
            {
                return sevenSegmentsBrushes;
            }
            set
            {
                sevenSegmentsBrushes = value;
                OnPropertyChanged("SevenSegmentsBrushes");
            }
        }


        public ICommand ChangeValueCommand
        {
            get;
        }

        public ICommand ChangeSevenStackValueCommand
        {
            get;
        }

        public ICommand ChangeSixteenStackValueCommand
        {
            get;
        }

        public ICommand ShowCustomSegmentsCommand
        {
            get;
        }

        public ICommand ShowColoredSegmentsCommand
        {
            get;
        }

        public ICommand SixteenStackCyrillicCommand
        {
            get;
        }

        

        public ApplicationViewModel()
        {
            Clear();
            SevenSegmentValue = "8";
            SixteenSegmentValue = "Q";

            ChangeValueCommand = new RelayCommand(ChangeValue);
            ChangeSevenStackValueCommand = new RelayCommand(ChangeSevenStackValue);
            ChangeSixteenStackValueCommand = new RelayCommand(ChangeSixteenStackValue);
            SixteenStackCyrillicCommand = new RelayCommand(SixteenStackCyrillicValue);
            ShowCustomSegmentsCommand = new RelayCommand(ShowCustomSegments);
            ShowColoredSegmentsCommand = new RelayCommand(ShowColoredSegments);
        }

        private void ChangeValue()
        {
            Clear();

            SevenSegmentValue = "5";
            SixteenSegmentValue = "R";
        }

        private void ChangeSevenStackValue()
        {
            SevenSegmentStackValue = "18:30";
        }

        private void ChangeSixteenStackValue()
        {
            SixteenSegmentStackValue = "segments";
            SixteenSegmentStackValue2 = "display.";
        }

        private void SixteenStackCyrillicValue()
        {
            SixteenSegmentStackValue = "сегменты";
            SixteenSegmentStackValue2 = "дисплей.";
        }

        private void Clear()
        {
            SevenSegmentValue = string.Empty;
            SixteenSegmentValue = string.Empty;

            SelectedSevenSegments = new ObservableCollection<SevenSegmentsFlags>();
            SelectedSixteenSegments = new ObservableCollection<SixteenSegmentsFlags>();
            SixteenSegmentsBrushes = new ObservableCollection<SegmentBrush<SixteenSegmentsFlags>>();
            SevenSegmentsBrushes = new ObservableCollection<SegmentBrush<SevenSegmentsFlags>>();
        }


        private void ShowCustomSegments()
        {
            Clear();

            SelectedSevenSegments.Add(SevenSegmentsFlags.Top);
            SelectedSevenSegments.Add(SevenSegmentsFlags.Middle);
            SelectedSevenSegments.Add(SevenSegmentsFlags.Bottom);
            SelectedSixteenSegments.Add(SixteenSegmentsFlags.LeftMiddle);
            SelectedSixteenSegments.Add(SixteenSegmentsFlags.RightMiddle);
            SelectedSixteenSegments.Add(SixteenSegmentsFlags.RightBottomDiagonal);
        }

        private void ShowColoredSegments()
        {
            Clear();

            var redBrush = new LinearGradientBrush( Colors.Orange, Colors.Red, 90);
            var orangeBrush = new LinearGradientBrush(Colors.Yellow, Colors.Orange, 90);

            SevenSegmentsBrushes =
                 new ObservableCollection<SegmentBrush<SevenSegmentsFlags>>
                 {
                        new SegmentBrush<SevenSegmentsFlags>
                        {
                            Segment = SevenSegmentsFlags.Top,
                            FillBrush = redBrush,
                            PenColor = Colors.Black
                        },

                        new SegmentBrush<SevenSegmentsFlags>
                        {
                            Segment = SevenSegmentsFlags.RightTop,
                            FillBrush = orangeBrush,
                            PenColor = Colors.Black
                        },

                        new SegmentBrush<SevenSegmentsFlags>
                        {
                            Segment = SevenSegmentsFlags.Middle,
                            FillBrush = redBrush,
                            PenColor = Colors.Black
                        },

                        new SegmentBrush<SevenSegmentsFlags>
                        {
                            Segment = SevenSegmentsFlags.LeftBottom,
                            FillBrush = orangeBrush,
                            PenColor = Colors.Black
                        },

                        new SegmentBrush<SevenSegmentsFlags>
                        {
                            Segment = SevenSegmentsFlags.Bottom,
                            FillBrush =redBrush,
                            PenColor = Colors.Black
                        },
                 };


                 }



    }
}
