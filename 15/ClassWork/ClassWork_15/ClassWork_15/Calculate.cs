using System;
using System.Collections.Generic;
using System.Text;

namespace ClassWork_15
{
	static class Calculate
	{
		public static T Sum<T>(T a, T b)
		{		
			return (T)((dynamic)a + (dynamic)b);
		}

		public static T Multiply<T>(T a, T b)
		{
			return (T)((dynamic)a * (dynamic)b);
		}
		public static T Subtract<T>(T a, T b)
		{
			return (T)((dynamic)a - (dynamic)b);
		}
		public static T Divide<T>(T a, T b)
		{
			return (T)((dynamic)a / (dynamic)b);
		}
	}
}
