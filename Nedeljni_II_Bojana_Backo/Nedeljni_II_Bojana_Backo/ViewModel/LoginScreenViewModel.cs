using Nedeljni_II_Bojana_Backo.Command;
using Nedeljni_II_Bojana_Backo.Services;
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
    class LoginScreenViewModel : ViewModelBase
    {
        LoginScreen loginScreen;
        public static List<string> userPass;
        //ManagerPassword managerPassword;
        //ServiceManager serviceManager;
        ServiceAdmin serviceAdmin;
        ServiceClinic serviceClinic;

        public LoginScreenViewModel(LoginScreen loginScreenOpen)
        {
            loginScreen = loginScreenOpen;
            userPass = new List<string>();
            clinic = new tblClinic();
            admin = new vwClinicAdministrator();
            //serviceManager = new ServiceManager();
            serviceClinic = new ServiceClinic();
            clinicList = serviceClinic.GetAllClinics().ToList();
            serviceAdmin = new ServiceAdmin();
            
            

            //managerPassword = new ManagerPassword();
            //managerPassword.ApplicationStarted += WriteRandomStrToFile;
            //managerPassword.WriteToFile();
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

        private List<tblClinic> clinicList;
        public List<tblClinic> ClinicList
        {
            get
            {
                return clinicList;
            }
            set
            {
                clinicList = value;
                OnPropertyChanged("ClinicList");
            }
        }
        //private tblUser user;
        //public tblUser User
        //{
        //    get
        //    {
        //        return user;
        //    }
        //    set
        //    {
        //        user = value;
        //        OnPropertyChanged("User");
        //    }
        //}

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

        //public string Error
        //{
        //    get { return null; }
        //}

        //public string this[string someProperty]
        //{
        //    get
        //    {

        //        return string.Empty;
        //    }
        //}
        #endregion

        #region Commands
        private ICommand submit;
        public ICommand Submit
        {
            get
            {
                if (submit == null)
                {
                    submit = new RelayCommand(SubmitCommandExecute,
                        param => CanSubmitCommandExecute());
                }
                return submit;
            }
        }

        private void SubmitCommandExecute(object obj)
        {
            try
            {
                ReadUsernameAndPasswordFromFile();
                string password = (obj as PasswordBox).Password;

                if (UserName.Equals(userPass.ElementAt(1)) && password.Equals(userPass.ElementAt(3)))
                {
                    MasterWindow master = new MasterWindow();
                    loginScreen.Close();
                    master.ShowDialog();
                }
                //else if (serviceManager.IsUser(UserName))
                //{
                //    Manager = serviceManager.FindManager(UserName);
                //    if (SecurePasswordHasher.Verify(password, Manager.UserPassword) || password == Manager.ReservedPassword)
                //    {
                //        if (Manager.LevelOfResponsibility == null)
                //        {
                //            MessageBox.Show("Can't login until the Admin assigns you a level of Responsability.");
                //        }
                //        else
                //        {
                //            ManagerWindow managerWindow = new ManagerWindow();
                //            loginScreen.Close();
                //            managerWindow.ShowDialog();
                //        }
                //    }
                //}
                else if (serviceAdmin.IsUser(UserName))
                {
                    Admin = serviceAdmin.FindAdmin(UserName);
                    if (SecurePasswordHasher.Verify(password, Admin.UserPassword))
                    {
                        clinicList = serviceClinic.GetAllClinics().ToList();
                        if (clinicList.Count == 0)
                        {
                            CreateClinic createClinic = new CreateClinic();
                            loginScreen.Close();
                            createClinic.ShowDialog();
                        }
                        else
                        {
                            AdminWindow adminWindow = new AdminWindow();
                            loginScreen.Close();
                            adminWindow.ShowDialog();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong usename or password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanSubmitCommandExecute()
        {
            return true;
        }
        // Signup button
        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignupExecute(), param => CanCreateSigunExecute());
                }
                return signUp;
            }
        }
        private void SignupExecute()
        {
            try
            {
                //Signup signup = new Signup();
                //loginScreen.Close();
                //signup.ShowDialog();
                MessageBox.Show("Patient registration not implemented yet!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanCreateSigunExecute()
        {
            return true;
        }
        #endregion
        void WriteUsernameAndPasswordToFile(object source, string radnomStr)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\ClinicAccess.txt"))
            {

                sw.WriteLine(radnomStr);

            }
        }

        void ReadUsernameAndPasswordFromFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"..\..\ClinicAccess.txt"))
                {
                    string line;
                    string[] arr;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr = line.Split();
                        for (int i = 0; i < arr.Length; i++)
                        {
                            userPass.Add(arr[i]);
                        }
                    }
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
