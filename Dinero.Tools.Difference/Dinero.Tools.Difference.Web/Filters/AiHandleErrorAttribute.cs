﻿
using System;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace Dinero.Tools.Difference.Web.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AiHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)
            {
                //If customError is Off, then AI HTTPModule will report the exception
                //if (filterContext.HttpContext.IsCustomErrorEnabled)
                //{   //or reuse instance (recommended!). see note above  

                    //We always want to track the exception
                    var ai = new TelemetryClient();
                    ai.TrackException(filterContext.Exception);
                //}
            }
            base.OnException(filterContext);
        }
    }
}