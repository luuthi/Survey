using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class QuestionEntities
    {
        public Guid IdQuestion { get; set; }
        public Guid IdQuestionGroup { get; set; }
        public int NumericalOrder { get; set; }
        public Guid IdSurvey { get; set; }
        public Guid IdQuesType { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        public bool IsRequired { get; set; }
        public bool Status { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string LastEditedBy { get; set; }

        public QuestionEntities()
        {

        }
        public QuestionEntities(Guid idQuestion, Guid idQuestionGroup, int num, Guid idSurvey, Guid idQuestype, string content, string images, bool isRequired, DateTime lasteditedAt, string lasteditedBy, bool status)
        {
            this.IdQuestion = idQuestion;
            this.IdQuestionGroup = idQuestionGroup;
            this.IdQuesType = idQuestype;
            this.IdSurvey = idSurvey;
            this.NumericalOrder = num;
            this.Content = content;
            this.Images = images;
            this.IsRequired = isRequired;
            this.Status = status;
            this.LastEditedAt = lasteditedAt;
            this.LastEditedBy = lasteditedBy;
        }
    }
}
