using ppedv.HalloTaco.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ppedv.HalloTaco.UI.WPF.Views
{
    /// <summary>
    /// Interaction logic for FleischControl.xaml
    /// </summary>
    public partial class FleischControl : UserControl
    {
        private Fleischart fleischart;

        public FleischControl()
        {
            InitializeComponent();
            UpdateImage();
        }

        public Fleischart Fleischart
        {
            get { return (Fleischart)GetValue(FleischartProperty); }
            set
            {
                SetValue(FleischartProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Fleischart.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FleischartProperty =
            DependencyProperty.Register("Fleischart", typeof(Fleischart), typeof(FleischControl), new PropertyMetadata(Model.Fleischart.Pferd, PropChanged));

        private static void PropChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FleischControl fc)
                fc.UpdateImage();
        }


        private void UpdateImage()
        {
            string imgUriBase = "pack://application:,,,/ppedv.HalloTaco.UI.WPF;component/Assets/";

            switch (Fleischart)
            {
                case Fleischart.Vegetarisch:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}tree.png") as ImageSource;
                    break;
                case Fleischart.Rind:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}moon.png") as ImageSource;
                    break;
                case Fleischart.Huhn:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}chiken_leg.png") as ImageSource;
                    break;
                case Fleischart.Schwein:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}star.png") as ImageSource;
                    break;
                case Fleischart.Pferd:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}user_yoda.png") as ImageSource;
                    break;
                case Fleischart.Kalb:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}yellow_submarine.png") as ImageSource;
                    break;
                case Fleischart.Katze:
                    img.Source = new ImageSourceConverter().ConvertFromString($"{imgUriBase}cat.png") as ImageSource;
                    break;
            }


        }

        private void PrevClick(object sender, RoutedEventArgs e)
        {
            int prev = (int)Fleischart - 1;
            if (prev < 0)
                prev = Enum.GetValues(typeof(Fleischart)).Length - 1;
            Fleischart = (Fleischart)prev;
        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            int next = (int)Fleischart + 1;
            if (next > Enum.GetValues(typeof(Fleischart)).Length)
                next = 0;
            Fleischart = (Fleischart)next;
        }


    }
}
