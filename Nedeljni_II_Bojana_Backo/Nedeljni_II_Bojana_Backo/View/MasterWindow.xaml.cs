using Nedeljni_II_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_II_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow()
        {
            InitializeComponent();
            this.DataContext = new MasterWindowViewModel(this);
        }
    }
}
