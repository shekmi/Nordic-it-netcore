using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
	class ConsoleLogWriter : ILogWriter
	{
		public void LogError(string message)
		{
			Console.WriteLine(DateTimeOffset.Now.ToString("yyyy-MM-ddThh:mm:ss+0000"), MessageType.Error, message);
		}

		public void LogInfo(string message)
		{
			Console.WriteLine(DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss+0000"), MessageType.Info, message);

		}

		public void LogWarning(string message)
		{
			Console.WriteLine(DateTimeOffset.Now.ToString("yyyy-MM-ddTHH:mm:ss+0000"), MessageType.Warning, message);
		}
	}
}
