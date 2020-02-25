using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
	class MultipleLogWriter : ILogWriter
	{
		public ConsoleLogWriter ConsoleLog { get; }
		public FileLogWriter FileLog { get; }
		public MultipleLogWriter(ConsoleLogWriter consoleLog, FileLogWriter fileLog)
		{
			ConsoleLog = consoleLog;
			FileLog = fileLog;
		}
		public void LogError(string message)
		{
			ConsoleLog.LogError(message);
			FileLog.LogError(message);
		}

		public void LogInfo(string message)
		{
			ConsoleLog.LogInfo(message);
			FileLog.LogInfo(message);
		}

		public void LogWarning(string message)
		{
			ConsoleLog.LogWarning(message);
			FileLog.LogWarning(message);
		}
	}
}
