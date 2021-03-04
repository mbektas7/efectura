using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Helpers
{
    public class ErrorLog : Attribute, IExceptionFilter
    {


        public void OnException(ExceptionContext context)
        {
            // Bu kısım özelleştirilebilir.
            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            //exception oluşan metotun bilgisi 
            var methodDescriptor = string.Format("{0}.{1}.{2}", controllerActionDescriptor.MethodInfo.ReflectedType.Namespace,
                controllerActionDescriptor.MethodInfo.ReflectedType.Name,
                controllerActionDescriptor.MethodInfo.Name);

            Functions.WriteLog(methodDescriptor.ToString());
        }
    }
}
