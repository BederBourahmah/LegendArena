using System;
using System.Net;

namespace LegendArena.Model
{
  public class LegendArenaException : Exception
  {
    public LegendArenaException() : base()
    {

    }

    public LegendArenaException(string message) : base(message: message)
    {

    }

    public static HttpStatusCode HttpStatusCode => HttpStatusCode.InternalServerError;
  }
}
