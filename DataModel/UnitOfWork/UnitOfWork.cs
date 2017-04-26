using DataModel.GenericType;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataModel.UnitOfWork
{
    public class UnitOfWork :IDisposable, IUnitOfWork
    {
        /// <summary>
        /// Chứa các thuộc tính là các thực thể với kiểu dùng chung GenericType
        /// </summary>
        //
        private bool _disposed = false;
        private SurveyEntities _context = null;
        private GenericType<SurveyType> _surveytype;
        private GenericType<SurveyInfo> _surveyinfo;
        private GenericType<QuestionType> _questiontype;
        private GenericType<QuestionGroup> _questiongroup;
        private GenericType<Question> _question;
        private GenericType<Choice> _choice;
        private GenericType<Answer> _answer;
        private GenericType<AnswerPaper> _answerpaper;
        private GenericType<Account> _account;
        private GenericType<AccountGroup> _accountgr;
        private GenericType<Role> _role;
        private GenericType<RolesDetail> _roledetail;
        private GenericType<Token> _token;

        public UnitOfWork()
        {
                _context = new SurveyEntities();
        }

        public GenericType<Token> TokenGenericType
        {
            get
            {
                if (this._token == null)
                {
                    this._token = new GenericType<Token>(_context);
                }
                return _token;
            }
        }
        public GenericType<SurveyType> SurveyTypeGenericType
        {
            get
            {
                if (this._surveytype == null)
                {
                    this._surveytype = new GenericType<SurveyType>(_context);
                }
                return _surveytype;
            }
        }
        public GenericType<SurveyInfo> SurveyinfoGenericType
        {
            get
            {
                if (this._surveyinfo == null)
                {
                    this._surveyinfo = new GenericType<SurveyInfo>(_context);
                }
                return _surveyinfo;
            }
        }
        public GenericType<QuestionType> QuestionTypeGenericType
        {
            get
            {
                if (this._questiontype == null)
                {
                    this._questiontype = new GenericType<QuestionType>(_context);
                }
                return _questiontype;
            }
        }
        public GenericType<QuestionGroup> QuestionGroupGenericType
        {
            get
            {
                if (this._questiongroup == null)
                {
                    this._questiongroup = new GenericType<QuestionGroup>(_context);
                }
                return _questiongroup;
            }
        }
        public GenericType<Question> QuestionGenericType
        {
            get
            {
                if (this._question == null)
                {
                    this._question = new GenericType<Question>(_context);
                }
                return _question;
            }
        }
        public GenericType<Choice> ChoiceGenericType
        {
            get
            {
                if (this._choice == null)
                {
                    this._choice = new GenericType<Choice>(_context);
                }
                return _choice;
            }
        }
        public GenericType<Answer> AnswerGenericType
        {
            get
            {
                if (this._answer == null)
                {
                    this._answer = new GenericType<Answer>(_context);
                }
                return _answer;
            }
        }
        public GenericType<AnswerPaper> AnswerPaperGenericType
        {
            get
            {
                if (this._answerpaper == null)
                {
                    this._answerpaper = new GenericType<AnswerPaper>(_context);
                }
                return _answerpaper;
            }
        }
        public GenericType<Account> AccontGenericType
        {
            get
            {
                if (this._account == null)
                {
                    this._account = new GenericType<Account>(_context);
                }
                return _account;
            }
        }
        public GenericType<AccountGroup> AccountGroupGenericType
        {
            get
            {
                if (this._accountgr == null)
                {
                    this._accountgr = new GenericType<AccountGroup>(_context);
                }
                return _accountgr;
            }
        }
        public GenericType<Role> RoleGenericType
        {
            get
            {
                if (this._role == null)
                {
                    this._role = new GenericType<Role>(_context);
                }
                return _role;
            }
        }
        public GenericType<RolesDetail> RoleDetailGenericType
        {
            get
            {
                if (this._roledetail == null)
                {
                    this._roledetail = new GenericType<RolesDetail>(_context);
                }
                return _roledetail;
            }
        }


        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"D:\errors.txt", outputLines);

                throw e;
            }

        }
    }
}
