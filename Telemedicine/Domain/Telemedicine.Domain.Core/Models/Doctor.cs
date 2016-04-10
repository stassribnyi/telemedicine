using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemedicine.Domain.Core.Models
{
    public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(16)]
        public string Login { get; set; }
        [MinLength(6)]
        [MaxLength(16)]
        public string Password { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string LastName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string Patronimic { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string MedicalSpecialization { get; set; }

        public bool IsArchive { get; set; }

        public Doctor()
        {
            Patients = new HashSet<Patient>();
        }

        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Patient> Patients{ get; set; }
}
}
