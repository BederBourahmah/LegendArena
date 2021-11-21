using LegendArena.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LegendArena.WebApi
{
  public class CustomExceptionFilter : IExceptionFilter
  {
    private readonly IWebHostEnvironment _hostingEnvironment;
    private readonly IModelMetadataProvider _modelMetadataProvider;

    public CustomExceptionFilter(
        IWebHostEnvironment hostingEnvironment,
        IModelMetadataProvider modelMetadataProvider)
    {
      _hostingEnvironment = hostingEnvironment;
      _modelMetadataProvider = modelMetadataProvider;
    }

    public void OnException(ExceptionContext context)
    {
      if (!_hostingEnvironment.IsDevelopment())
        return;

      context.Result = new ContentResult
      {
        Content = context.Exception.Message,
        StatusCode = (int)GetStatusCode(context.Exception)
      };
    }

    private static HttpStatusCode GetStatusCode(Exception exception)
    {
      if (exception is LegendArenaException)
        return LegendArenaException.HttpStatusCode;

      return HttpStatusCode.InternalServerError;
    }
  }
}
