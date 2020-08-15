using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Bojana_Backo.Services
{
    class ServiceAdmin
    {
        // Method that add Admin to database
        public void AddAdmin(vwClinicAdministrator admin)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    tblUser newUser = new tblUser();
                    tblClinicAdministrator newAdmin = new tblClinicAdministrator();
                    newUser.FirstName = admin.FirstName;
                    newUser.LastName = admin.LastName;
                    newUser.IdentificationCard = admin.IdentificationCard;
                    newUser.Gender = admin.Gender;
                    newUser.DateOfBirth = admin.DateOfBirth;
                    newUser.Citizenship = admin.Citizenship;
                    newUser.Username = admin.Username;
                    newUser.UserPassword = SecurePasswordHasher.Hash(admin.UserPassword);

                    context.tblUsers.Add(newUser);
                    context.SaveChanges();
                    admin.UserID = newUser.UserID;

                    newAdmin.UserID = admin.UserID;

                    context.tblClinicAdministrators.Add(newAdmin);
                    context.SaveChanges();
                    admin.AdminID = newAdmin.AdminID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        // Method that reads all Admins from database
        public List<vwClinicAdministrator> GetAllAdmins()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<vwClinicAdministrator> list = new List<vwClinicAdministrator>();
                    list = (from x in context.vwClinicAdministrators select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
        // Methot to check if Manager username exists in database
        public bool IsUser(string username)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    vwClinicAdministrator admin = (from e in context.vwClinicAdministrators where e.Username == username select e).First();

                    if (admin == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return false;
            }
        }

        public vwClinicAdministrator FindAdmin(string username)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    vwClinicAdministrator admin = (from e in context.vwClinicAdministrators where e.Username == username select e).First();
                    return admin;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
