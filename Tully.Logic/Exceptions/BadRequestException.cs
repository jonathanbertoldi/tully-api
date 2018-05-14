using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Tully.Logic.Exceptions
{
  public class BadRequestException : BaseLogicException
  {
    public BadRequestException() : base(400) { }

    public BadRequestException(dynamic body) : base(400){
      Body = body;
    }
  }
}
