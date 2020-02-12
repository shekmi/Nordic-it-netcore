using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_12
{
    class Passport : BaseDocument
    {     
        public string Country { get; set; }

        public string PersonName { get; set; }

        override public string PropertiesString
        {
            get { return $"{DocName}, {DocNumber}, {IssueDate}, {Country}, {PersonName}"; }
        }

        public Passport(string docNumber, DateTimeOffset issueDate, string country, string personName) : base("Passport", docNumber, issueDate)
        {
            Country = country;
            PersonName = personName;
        }

        public void ChangeIssueDate(DateTimeOffset newIssueDate)
        {
            IssueDate = newIssueDate;
        }

    }
}
