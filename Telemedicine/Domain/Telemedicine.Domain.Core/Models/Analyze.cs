using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Telemedicine.Domain.Core.Models
{
    public class Analyze
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double Temp { get; set; }
        public int HartRate { get; set; }
        public Pressure Pressure { get; set; }
        public DateTime LastMeasurement { get; set; }

        [Required]
        public virtual Patient Patient { get; set; }

        public virtual ECG ECG { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
