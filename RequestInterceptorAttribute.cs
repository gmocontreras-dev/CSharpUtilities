using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequestInterceptorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var method = filterContext.HttpContext.Request.Method; //Obtiene el metodo utilizado GET, POST, ETC
            var form = filterContext.HttpContext.Request.Form; //Obtiene formulario
            var query = filterContext.HttpContext.Request.Query; // Obtiene parámetros de la url
            var headers = filterContext.HttpContext.Request.Headers; //Obtiene cabeceras
            var controller = filterContext.ActionDescriptor.DisplayName; //Obtiene el nombre del controlador
            //ejemplo
            var userAgent=headers[HeaderNames.UserAgent]; //Obtener navegador
            var token=header["token"]; //obtiene el token
            
            //Hacer lo que sea necesario: Guardar en base de datos, logs, etc.

        }
    }
}

//Agregar referencia en archivo Startup.cs 
 public void ConfigureServices(IServiceCollection services)
 {
     services.AddMvc(options =>
             {
                 options.Filters.Add(typeof(RequestInterceptorAttribute));
             })
 }

//Agregar en controladores
[RequestInterceptor] //Usar en los controladores que se necesitan interceptar
  public class ProductosController : ControllerBase
  {
  }
