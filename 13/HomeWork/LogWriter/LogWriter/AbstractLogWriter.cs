using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
    abstract class AbstractLogWriter
    {
		private readonly string _logRecordFormat =
		"{0:yyyy-MM-ddThh:mm:ss}+0000\t{1}\t{2}";
		public void LogError(string message)
		{
			LogRecordType(message, MessageType.Error);
		}

		public void LogInfo(string message)
		{
			LogRecordType(message, MessageType.Info);
		}

		public void LogWarning(string message)
		{
			LogRecordType(message, MessageType.Warning);
		}

		protected string GetLogRecord(string message, MessageType logRecordType)
		{
			return String.Format(
				_logRecordFormat,
				DateTime.UtcNow,
				logRecordType,
				message);
		}

		protected abstract void LogRecordType(string message, MessageType logRecordType);
	}
}
