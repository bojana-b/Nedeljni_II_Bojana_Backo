﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_II_Bojana_Backo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ClinicDBEntities : DbContext
    {
        public ClinicDBEntities()
            : base("name=ClinicDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblClinic> tblClinics { get; set; }
        public virtual DbSet<tblClinicAdministrator> tblClinicAdministrators { get; set; }
        public virtual DbSet<tblClinicDoctor> tblClinicDoctors { get; set; }
        public virtual DbSet<tblClinicMaintenance> tblClinicMaintenances { get; set; }
        public virtual DbSet<tblClinicManager> tblClinicManagers { get; set; }
        public virtual DbSet<tblClinicPatient> tblClinicPatients { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<vwClinicAdministrator> vwClinicAdministrators { get; set; }
        public virtual DbSet<vwClinicDoctor> vwClinicDoctors { get; set; }
        public virtual DbSet<vwClinicMaintenance> vwClinicMaintenances { get; set; }
        public virtual DbSet<vwClinicManager> vwClinicManagers { get; set; }
        public virtual DbSet<vwClinicPatient> vwClinicPatients { get; set; }
    }
}
