using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemedicine.Domain.Core.Models
{
    public class Hospital
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}
