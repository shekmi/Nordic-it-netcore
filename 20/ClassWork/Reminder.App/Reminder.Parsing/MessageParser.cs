using System;

namespace Reminder.Parsing
{
    public static class MessageParser
    {
        public static ParsedMessage ParseMessage(string text)
        {
            if(string.IsNullOrEmpty(text))
                return null;

            int firstSpacePosition = text.IndexOf(' ');
            if (firstSpacePosition < 10)
                return null;

            string potentialDate = text.Substring(0, firstSpacePosition); //начальный индекс, длина
            if (DateTimeOffset.TryParse(potentialDate, out var date))
                return null;

            var message = text.Substring(firstSpacePosition).Trim();
            if (string.IsNullOrEmpty(message))
                return null;

            ParsedMessage result = new ParsedMessage
            {
                Date = date,
                Message = message
            };

            return result;
        }
    }
}
