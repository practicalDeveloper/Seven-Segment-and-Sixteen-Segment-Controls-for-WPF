using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace SegmentsControls
{
    /// <summary>
    /// Interaction logic for SevenSegmentsStack.xaml
    /// </summary>
    public partial class SevenSegmentsStack : SegmentsStackBase
    {

        /// <summary>
        /// Stores chars from the splitted value string
        /// </summary>
        private ObservableCollection<CharItem> ValueChars;

        public SevenSegmentsStack()
        {
            InitializeComponent();
        }

        public override void OnPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ValueChars = GetCharsArray();
            SegmentsArray.ItemsSource = ValueChars;
        }



    }
}
