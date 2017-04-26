using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class QuestionGroupEntities
    {
        public Guid IdQuestionGroup { get; set; }
        public string Content { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string LastEditedBy { get; set; }
        public QuestionGroupEntities()
        {

        }
        public QuestionGroupEntities(Guid id, string content, DateTime lasteditedat, string lasteditedby)
        {
            this.IdQuestionGroup = id;
            this.Content = content;
            this.LastEditedAt = lasteditedat;
            this.LastEditedBy = lasteditedby;
        }
    }
}
