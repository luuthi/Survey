using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AnswerPaperEntities
    {
        public Guid IdAnsPaper { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid IdSurvey { get; set; }
        public string Descriptions { get; set; }
        public bool Status { get; set; }

        public AnswerPaperEntities()
        {

        }

        public AnswerPaperEntities(Guid idAnswerPaper, DateTime CreatedDate, Guid IdSurvey, string des, bool status)
        {
            this.IdAnsPaper = idAnswerPaper;
            this.CreatedDate = CreatedDate;
            this.IdSurvey = IdSurvey;
            this.Descriptions = des;
            this.Status = status;

        }
    }
}
