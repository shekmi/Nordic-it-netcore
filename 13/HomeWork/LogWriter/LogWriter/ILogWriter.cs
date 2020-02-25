using System;
using System.Collections.Generic;
using System.Text;

namespace LogWriter
{
	enum MessageType
	{		
		Info,
		Warning,
		Error
	}
    interface ILogWriter
    {
		void LogInfo(string message);
		void LogWarning(string message);
		void LogError(string message);

	}
}
