using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Domain.Core.Models;

namespace Telemedicine.Infrastructure.Data
{
    public class TelemedicineContext : DbContext
    {
        public TelemedicineContext()
            : base("Name=TelemedicineContext")
        {
            this.Configuration.AutoDetectChangesEnabled = true;
            //Database.CompatibleWithModel(true);
        }

        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<ECG> ECGs { get; set; }
        public virtual DbSet<ECGData> ECGDatas { get; set; }
        public virtual DbSet<Analyze> Analyzes { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
    }
}
