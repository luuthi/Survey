using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AnswerEntities
    {
        public Guid IdAnswer { get; set; }
        public Guid IdChoices { get; set; }
        public Guid IdAnsPaper { get; set; }
        public Guid IdQuestion { get; set; }
        public AnswerEntities()
        {

        }
        public AnswerEntities(Guid idAnswer, Guid idChoice, Guid idAnswerPaper, Guid idQuestion)
        {
            this.IdAnsPaper = idAnswer;
            this.IdChoices = idChoice;
            this.IdAnsPaper = idAnswerPaper;
            this.IdQuestion = idQuestion;
        }
    }
}
