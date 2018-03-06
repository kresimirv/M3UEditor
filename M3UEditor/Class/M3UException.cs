using System;

namespace M3UEditor
{
	/// <summary>
	/// M3UException class
	/// </summary>
	public class M3UException: Exception
	{
	    public M3UException()
	    {
	    }
	
	    public M3UException(string message)
	        : base(message)
	    {
	    }
	
	    public M3UException(string message, Exception inner)
	        : base(message, inner)
	    {
	    }
	}
}
