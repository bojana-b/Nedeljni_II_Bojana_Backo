using Nedeljni_II_Bojana_Backo.ViewModel;
using System.Windows;

namespace Nedeljni_II_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for CreateClinic.xaml
    /// </summary>
    public partial class CreateClinic : Window
    {
        public CreateClinic()
        {
            InitializeComponent();
            this.DataContext = new CreateClinicViewModel(this);
        }
    }
}
