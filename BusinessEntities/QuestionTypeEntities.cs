using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public  class QuestionTypeEntities
    {
        public Guid IdQuestionType { get; set; }
        public string TypeName { get; set; }
        public bool Status { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string LastEditedBy { get; set; }

        public QuestionTypeEntities()
        {

        }
        public QuestionTypeEntities(Guid questionTypeId, string typename, bool status, DateTime lasteditedat, string lasteditedby)
        {
            this.IdQuestionType = questionTypeId;
            this.TypeName = typename;
            this.Status = status;
            this.LastEditedAt = lasteditedat;
            this.LastEditedBy = LastEditedBy;
        }
    }
}
