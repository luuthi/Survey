using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class ChoicesEntites
    {
        public Guid IdChoices { get; set; }
        public Guid IdQuestion { get; set; }
        public int NumericalOrder { get; set; }
        public string Content { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string LastEditedBy { get; set; }
        public ChoicesEntites()
        {

        }
        public ChoicesEntites(Guid idChoice, Guid idQuestion, int num, string content, DateTime lasteditedat, string lasteditedby)
        {
            this.IdChoices = idChoice;
            this.IdQuestion = idQuestion;
            this.NumericalOrder = num;
            this.Content = content;
            this.LastEditedAt = lasteditedat;
            this.LastEditedBy = lasteditedby;
        }
    }
}
