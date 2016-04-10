using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemedicine.Domain.Core.Models
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long INN { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string FirstName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string LastName { get; set; }
        [MinLength(3)]
        [MaxLength(16)]
        public string Patronimic { get; set; }

        public Gender Gender { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Birth { get; set; }
        public string Phone { get; set; }
        public Guid DeviceId { get; set; }
        public bool IsArchive { get; set; }

        public Patient()
        {
            Doctors = new HashSet<Doctor>();
        }

        public virtual ICollection<Doctor> Doctors{ get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Analyze> Analyzes { get; set; }
    }
}
