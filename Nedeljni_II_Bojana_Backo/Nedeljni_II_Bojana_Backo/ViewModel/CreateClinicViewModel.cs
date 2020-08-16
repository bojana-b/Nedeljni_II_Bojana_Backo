using Nedeljni_II_Bojana_Backo.Command;
using Nedeljni_II_Bojana_Backo.Services;
using Nedeljni_II_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Nedeljni_II_Bojana_Backo.ViewModel
{
    class CreateClinicViewModel : ViewModelBase
    {
        CreateClinic createClinic;
        ServiceClinic serviceClinic;

        public CreateClinicViewModel(CreateClinic createClinicOpen)
        {
            createClinic = createClinicOpen;
            serviceClinic = new ServiceClinic();
            Clinic = new tblClinic();
            Clinic.Balcony = false;
            Clinic.Garden = false;
        }

        #region Properties
        private tblClinic clinic;
        public tblClinic Clinic
        {
            get
            {
                return clinic;
            }
            set
            {
                clinic = value;
                OnPropertyChanged("Clinic");
            }
        }

        private bool balcony;
        public bool Balcony
        {
            get
            {
                return balcony;
            }
            set
            {
                balcony = value;
                OnPropertyChanged("Balcony");
            }
        }

        private bool garden;
        public bool Garden
        {
            get
            {
                return garden;
            }
            set
            {
                garden = value;
                OnPropertyChanged("Garden");
            }
        }
        #endregion

        #region Commands
        // Save Button
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(SaveExecute, CanSaveExecute);
                }
                return save;
            }
        }
        private void SaveExecute(object obj)
        {
            try
            {
                LoginScreen login = new LoginScreen();
                Clinic.Balcony = balcony;
                Clinic.Garden = garden;
                serviceClinic.AddClinic(Clinic);
                createClinic.Close();
                MessageBox.Show("Clinic created!");
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(Clinic.ClinicName) || String.IsNullOrEmpty(Clinic.ClinicOwner)
                || String.IsNullOrEmpty(Clinic.ClinicAddress) || Clinic.ClinicFloorNumber == 0
                || Clinic.RoomsPerFloor == 0 || Clinic.EmergencyVehicleParkingLoots == 0
                || Clinic.InvalidVehicleParkingLoots == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Cancel Button
        private ICommand cancel;
        public ICommand Cancel
        {
            get
            {
                if (cancel == null)
                {
                    cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                }
                return cancel;
            }
        }
        private void CancelExecute()
        {
            try
            {
                LoginScreen login = new LoginScreen();
                createClinic.Close();
                login.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCancelExecute()
        {
            return true;
        }
        #endregion
    }
}
