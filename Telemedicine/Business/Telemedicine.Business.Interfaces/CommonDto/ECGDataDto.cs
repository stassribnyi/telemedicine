using System;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class ECGDataDto
    {
        public Guid Id { get; set; }
        public int RR { get; set; }
        public int Time { get; set; }
        
        public virtual ECGDto ECG { get; set; }
    }
}