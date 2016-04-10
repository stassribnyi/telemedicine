using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Domain.Core.Models
{
    public class ECG
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime LastMeasurement { get; set; }

        [Required]
        public virtual Analyze Analyze { get; set; }

        public ECG()
        {
            Comments = new List<Comment>();
            Datas = new List<ECGData>();
        }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<ECGData> Datas { get; set; }
    }
}
