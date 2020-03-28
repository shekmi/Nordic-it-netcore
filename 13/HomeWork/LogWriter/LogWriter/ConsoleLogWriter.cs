using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
	class ConsoleLogWriter : AbstractLogWriter
	{
		protected override void LogRecordType(string message, MessageType logRecordType)
		{
			Console.WriteLine(base.GetLogRecord(message, logRecordType));
		}
	}
}
