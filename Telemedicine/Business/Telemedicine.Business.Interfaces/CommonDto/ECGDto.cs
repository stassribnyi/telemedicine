using System;
using System.Collections.Generic;

namespace Telemedicine.Business.Interfaces.CommonDto
{
    public class ECGDto
    {
        public int Id { get; set; }
        public DateTime LastMeasurement { get; set; }
        
        public virtual AnalyzeDto Analyze { get; set; }

        public ECGDto()
        {
            Comments = new List<CommentDto>();
            Datas = new List<ECGDataDto>();
        }

        public virtual ICollection<CommentDto> Comments { get; set; }
        public virtual ICollection<ECGDataDto> Datas { get; set; }
    }
}