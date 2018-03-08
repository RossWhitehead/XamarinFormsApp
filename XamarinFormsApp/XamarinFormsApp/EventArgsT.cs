using System;

namespace XamarinFormsApp
{
	public class EventArgsT<T>
	{
		public T Value { get;  }

		public EventArgsT(T val)
		{
			this.Value = val;
		}
	}
}
