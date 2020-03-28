using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
	class MultipleLogWriter : AbstractLogWriter, IDisposable
	{
		private IEnumerable<ILogWriter> _logWriters;
		public MultipleLogWriter(params ILogWriter[] writers)
		{
			_logWriters = writers;
		}		

		protected override void LogRecordType(string message, MessageType logRecordType)
		{
			foreach (var item in _logWriters)
			{
				if(item is ConsoleLogWriter)
				{
					Console.WriteLine(base.GetLogRecord(message, logRecordType));
				}
				else
				{
					item.
				}
					
			}
			Console.WriteLine(base.GetLogRecord(message, logRecordType));
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
