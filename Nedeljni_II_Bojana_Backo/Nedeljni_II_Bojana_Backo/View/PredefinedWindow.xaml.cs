using Nedeljni_II_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_II_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for PredefinedWindow.xaml
    /// </summary>
    public partial class PredefinedWindow : Window
    {
        public PredefinedWindow()
        {
            InitializeComponent();
            this.DataContext = new PredefinedWindowViewModel(this);
        }
    }
}
