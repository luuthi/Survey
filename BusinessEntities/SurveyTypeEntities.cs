using System;

namespace BusinessEntities
{
    public class SurveyTypeEntities
    {
        public Guid IdSurType { get; set; }
        public string TypeName { get; set; }
        public string Descriptions { get; set; }
        public DateTime LastEditedAt { get; set; }
        public bool Status { get; set; }
        public SurveyTypeEntities()
        {

        }
        public SurveyTypeEntities(Guid id, string name, string description, DateTime date, bool status)
        {
            IdSurType = id;
            TypeName = name;
            Descriptions = description;
            LastEditedAt = date;
            Status = status;
        }
    }
}
