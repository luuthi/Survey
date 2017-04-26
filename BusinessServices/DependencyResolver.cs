using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resolver;
using System.ComponentModel.Composition;
using BusinessServices.Implements;
using BusinessServices.Interfaces;

namespace BusinessServices
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<ISurveyTypeServices, SurveyTypeServices>();
            registerComponent.RegisterType<ISurveyServices, SurveyServices>();
            registerComponent.RegisterType<IAccountServices, AccountServices>();
            registerComponent.RegisterType<IAccountGroupServices, AccountGroupServices>();
            registerComponent.RegisterType<IAnswerServices, AnswerServices>();
            registerComponent.RegisterType<IAnswerPaperServices, AnswerPaperServices>();
            registerComponent.RegisterType<IChoicesServices, ChoicesServices>();
            registerComponent.RegisterType<IQuestionGroupServices, QuestionGroupServices>();
            registerComponent.RegisterType<IQuestionTypeService, QuestionTypeServices>();
            registerComponent.RegisterType<IQuestionServices, QuestionServices>();
            registerComponent.RegisterType<IRoleServives, RoleServices>();
            registerComponent.RegisterType<IRoleDetailServices, RoleDetailServices>();
            registerComponent.RegisterType<ITokenServices, TokenServices>();
        }
    }
}
