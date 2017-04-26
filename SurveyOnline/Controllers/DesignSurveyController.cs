using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurveyOnline.Controllers
{
    public class DesignSurveyController : Controller
    {
        // GET: DesignSuvey DesignSurvey
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddNewQuestionSection()
        {
            return PartialView("_multipleChoiceQuesEdit");
        }
        public ActionResult AppendNewQuestionSection()
        {
            return PartialView("_QuestionModel");
        }
        public ActionResult AddNewTitle()
        {
            return PartialView("_editSurveyDes");
        }

        public ActionResult AppendNewTitle()
        {
            return PartialView("_surveyDesModel");
        }
    }
}