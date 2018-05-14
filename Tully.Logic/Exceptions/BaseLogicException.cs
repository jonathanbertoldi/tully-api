using System;
namespace Tully.Logic.Exceptions
{
  public class BaseLogicException : Exception
  {
    public int ErrorCode { get; set; }
    public dynamic Body { get; set; }

    public BaseLogicException(int errorCode)
    {
      ErrorCode = errorCode;
    }

    public BaseLogicException(int errorCode, dynamic body) : this(errorCode)
    {
      Body = body;
    }
  }
}
