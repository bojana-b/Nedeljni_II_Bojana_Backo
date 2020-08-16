using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedeljni_II_Bojana_Backo.Services
{
    class ServiceClinic
    {
        // Method that add Clinic to database
        public void AddClinic(tblClinic clinic)
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    tblClinic newClinic = new tblClinic();
                    newClinic.ClinicName = clinic.ClinicName;
                    newClinic.CreatingDate = DateTime.Now;
                    newClinic.ClinicOwner = clinic.ClinicOwner;
                    newClinic.ClinicAddress = clinic.ClinicAddress;
                    newClinic.ClinicFloorNumber = clinic.ClinicFloorNumber;
                    newClinic.RoomsPerFloor = clinic.RoomsPerFloor;
                    newClinic.Balcony = clinic.Balcony;
                    newClinic.Garden = clinic.Garden;
                    newClinic.EmergencyVehicleParkingLoots = clinic.EmergencyVehicleParkingLoots;
                    newClinic.InvalidVehicleParkingLoots = clinic.InvalidVehicleParkingLoots;

                    context.tblClinics.Add(newClinic);
                    context.SaveChanges();
                    clinic.ClinicID = newClinic.ClinicID;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }

        // Method that reads all Clinics from database
        public List<tblClinic> GetAllClinics()
        {
            try
            {
                using (ClinicDBEntities context = new ClinicDBEntities())
                {
                    List<tblClinic> list = new List<tblClinic>();
                    list = (from x in context.tblClinics select x).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }
}
