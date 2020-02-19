using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassWork
{
    class ErrorList: IDisposable, IEnumerable<string> 
    {
        private List<string> _errors;
        public string Category { get; }
        public static string OutputPrefixformat { get; set; }
        static ErrorList()
        {
            OutputPrefixformat = "O";
        }
        public ErrorList(string category)
        {
            Category = category;
            _errors = new List<string>();
        }

        public void Dispose()
        {
            _errors?.Clear(); //если не null
            _errors = null;
        }

        public void Add(string errorMessage)
        {
            _errors.Add(errorMessage);
        }

        public void WriteToConcole()
        {
            Console.WriteLine(
                DateTimeOffset.Now.ToString(OutputPrefixformat)
                + " " + Category + " " + _errors);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _errors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
