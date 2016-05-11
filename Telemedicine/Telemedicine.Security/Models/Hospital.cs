using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Security.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }

        public virtual ICollection<ApplicationUser> Doctors { get; set; }

    }
}
