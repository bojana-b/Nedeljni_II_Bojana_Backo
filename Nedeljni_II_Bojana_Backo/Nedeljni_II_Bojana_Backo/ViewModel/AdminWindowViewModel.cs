using Nedeljni_II_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Bojana_Backo.ViewModel
{
    class AdminWindowViewModel : ViewModelBase
    {
        AdminWindow adminWindow;

        public AdminWindowViewModel(AdminWindow adminWindowOpen)
        {
            adminWindow = adminWindowOpen;
        }
    }
}
