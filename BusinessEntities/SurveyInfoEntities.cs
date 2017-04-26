using System;

namespace BusinessEntities
{
    public class SurveyInfoEntities
    {
        public Guid IdSurvey { get; set; }
        public Guid IdSurType { get; set; }
        public string SurveyName { get; set; }
        public string Descriptions { get; set; }
        public string Images { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedAt { get; set; }
        public string LastEditedBy { get; set; }
        public string OwnedUserID { get; set; }
        public SurveyInfoEntities()
        {

        }
        public SurveyInfoEntities(Guid idSurvey, Guid IdSurType, string name, string des, string image, bool status, DateTime createdate, DateTime lastedited, string owner, string lasteditedby)
        {
            this.IdSurType = IdSurType;
            this.IdSurvey = idSurvey;
            this.SurveyName = name;
            this.Descriptions = des;
            this.Images = image;
            this.Status = status;
            this.CreatedDate = createdate;
            this.LastEditedAt = lastedited;
            this.OwnedUserID = owner;
            this.LastEditedBy = lasteditedby;
        }
    }
}
