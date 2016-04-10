using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telemedicine.Business.Interfaces.CommonDto;

namespace Telemedicine.Business.Interfaces.Services.AnalyzeService
{
    public interface IAnalyzeService
    {
        /// <summary>
        /// Get analyzes by patient id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<AnalyzeDto> GetAnalyzes(int? id);
        AnalyzeDto GetAnalyze(int id);
        /// <summary>
        /// Create analyze by patient id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Analyze"></param>
        /// <returns></returns>
        AnalyzeDto CreateAnalyze(int id, AnalyzeDto Analyze);
        void UpdateAnalyze(AnalyzeDto Analyze);
        void RemoveAnalyze(int id);
        /// <summary>
        /// Add comment by analyze id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        CommentDto AddComment(int id, CommentDto comment);

        /// <summary>
        /// Add comment for ecg by analyze id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="comment"></param>
        CommentDto AddECGComment(int id, CommentDto comment);
    }
}
