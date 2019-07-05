using ppedv.HalloTaco.UI.WPF.ViewModels;
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
    /// Interaction logic for TacoView.xaml
    /// </summary>
    public partial class TacoView : UserControl
    {
        public TacoView()
        {
            InitializeComponent();
            ((TacoViewModel)DataContext).PropertyChanged += TacoView_PropertyChanged;
        }

        private void TacoView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TacoViewModel.DeleteDialogVisible) && ((TacoViewModel)DataContext).DeleteDialogVisible)
            {
                var result = MessageBox.Show("Kill me!!", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Error, MessageBoxResult.None);
                if (result == MessageBoxResult.Yes)
                {
                    ((TacoViewModel)DataContext).DeleteDialogResult.Execute("jo");
                }
            }
        }
    }
}
