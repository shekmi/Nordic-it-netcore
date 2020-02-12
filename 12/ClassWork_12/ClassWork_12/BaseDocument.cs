using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_12
{
    public class BaseDocument
    {
        public string DocName { get; set; }

        public string DocNumber { get; set; }

        public DateTimeOffset IssueDate { get; set; }

        virtual public string PropertiesString 
        {
            get { return $"{DocName}, {DocNumber}, {IssueDate}"; } 
        }

        public BaseDocument(string docName, string docNumber, DateTimeOffset issueDate)
        {
            DocName = docName;
            DocNumber = docNumber;
            IssueDate = issueDate;
        }

        public void WriteToConsole()
        {
            Console.WriteLine(PropertiesString);
        }
    }
}
