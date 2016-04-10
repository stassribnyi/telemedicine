using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class AnalyzeDto
    {
        public int Id { get; set; }
        public double Temp { get; set; }
        public int HartRate { get; set; }
        public PressureDto Pressure { get; set; }
        public DateTime LastMeasurement { get; set; }

        public PatientDto Patient { get; set; }

        public virtual ECGDto ECG { get; set; }
        public virtual ICollection<CommentDto> Comments { get; set; }
    }
}
