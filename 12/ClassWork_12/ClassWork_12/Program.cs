using System;

namespace ClassWork_12
{
    class Program
    {
        static void Main(string[] args)
        {
            //BaseDocument baseDocument = new BaseDocument(
            
            //    "New Document",
            //    "12",
            //    DateTimeOffset.Parse("2019-03-03")
            //);

            //Passport passport = new Passport
            //(               
            //    "53",
            //    DateTimeOffset.Now,
            //    "Russia",
            //     "Petr"
            //);

            //baseDocument.WriteToConsole();
            //passport.WriteToConsole();

            BaseDocument[] baseDocumen = new BaseDocument[3];
            baseDocumen[0] = new BaseDocument (
                "Document_one",
                "11",
                DateTimeOffset.Parse("2019-03-03"));

            baseDocumen[1] = new BaseDocument(
                "Document_second",
                "13",
                DateTimeOffset.Parse("2019-03-03"));

            baseDocumen[2] = new Passport(
                 "53",
                DateTimeOffset.Now,
                "Russia",
                 "Petr");

            foreach (var item in baseDocumen)
            {
                if(item is Passport)
                {
                    var temp = item as Passport;
                    temp.ChangeIssueDate(DateTimeOffset.Now);
                }
                item.WriteToConsole();
            }
        }
    }
}
