using Nedeljni_II_Bojana_Backo.Command;
using Nedeljni_II_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Nedeljni_II_Bojana_Backo.ViewModel
{
    class PredefinedWindowViewModel : ViewModelBase
    {
        PredefinedWindow predefinedWindow;

        public PredefinedWindowViewModel(PredefinedWindow predefinedWindowOpen)
        {
            predefinedWindow = predefinedWindowOpen;
        }
        #region Properties
        private string userName;
        public string UserName
        {

            get
            {
                return userName;
            }
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
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
                MasterWindow master = new MasterWindow();
                WriteUsernameAndPasswordToFile(UserName, password);
                predefinedWindow.Close();
                MessageBox.Show("New Username or Password created!");
                master.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute(object obj)
        {
            if (String.IsNullOrEmpty(UserName) || String.IsNullOrEmpty((obj as PasswordBox).Password))
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
                MasterWindow master = new MasterWindow();
                predefinedWindow.Close();
                master.Show();
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

        void WriteUsernameAndPasswordToFile(string user, string pass)
        {
            try
            {
                using (StreamWriter sw = File.CreateText(@"..\..\ClinicAccess.txt"))
                {
                    sw.WriteLine("Username: " + user);
                    sw.WriteLine("Password: " + pass);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"The file was not found: '{e}'");
            }
            catch (IOException e)
            {
                Console.WriteLine($"The file could not be opened: '{e}'");
            }
        }
    }
}
