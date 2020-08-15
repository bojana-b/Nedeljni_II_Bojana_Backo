using Nedeljni_II_Bojana_Backo.Command;
using Nedeljni_II_Bojana_Backo.Services;
using Nedeljni_II_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_II_Bojana_Backo.ViewModel
{
    class AddAdminWindowViewModel : ViewModelBase
    {
        AddAdminWindow addAdminWindow;
        ServiceAdmin serviceAdmin;

        public AddAdminWindowViewModel(AddAdminWindow addAdminWindowOpen)
        {
            addAdminWindow = addAdminWindowOpen;
            serviceAdmin = new ServiceAdmin();
            Admin = new vwClinicAdministrator();
        }

        #region Properties
        private vwClinicAdministrator admin;
        public vwClinicAdministrator Admin
        {
            get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }
        private DateTime dateOfBirth = DateTime.Now;
        public DateTime DateOfBirth
        {
            get 
            { 
                return dateOfBirth; 
            }
            set 
            { 
                dateOfBirth = value; 
                OnPropertyChanged("DateOfBirth"); 
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
                string password = (obj as PasswordBox).Password;
                if (!PasswordValidation.PasswordOk(password))
                {
                    MessageBox.Show("Password is not valid");
                    return;
                }
                Admin.UserPassword = password;
                Admin.DateOfBirth = dateOfBirth;
                LoginScreen login = new LoginScreen();
                serviceAdmin.AddAdmin(Admin);
                addAdminWindow.Close();
                MessageBox.Show("Account created!");
                login.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(Admin.FirstName) || String.IsNullOrEmpty(Admin.LastName)
                || String.IsNullOrEmpty(Admin.IdentificationCard) || String.IsNullOrEmpty(Admin.Gender)
                || String.IsNullOrEmpty(Admin.Citizenship)
                || String.IsNullOrEmpty(Admin.Username) || String.IsNullOrEmpty((obj as PasswordBox).Password))
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
                addAdminWindow.Close();
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
