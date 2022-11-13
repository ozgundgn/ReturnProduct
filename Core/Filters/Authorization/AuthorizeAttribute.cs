using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Core.Filters.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // yetki kontrolü yapmaması için allowannym attribute eklendi.
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;
            try
            {
                string authHeader = context.HttpContext.Request.Headers["Authorization"];
                if (authHeader == null)
                {
                    context.Result = new UnauthorizedResult();

                    // set 'WWW-Authenticate' header to trigger login popup in browsers
                    context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
                    new UnauthorizedResult();
                }
                else
                {
                    var authHeaderValue = AuthenticationHeaderValue.Parse(authHeader);
                    if (authHeaderValue.Scheme.Equals(AuthenticationSchemes.Basic.ToString(), StringComparison.OrdinalIgnoreCase))
                    {
                        var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeaderValue.Parameter ?? string.Empty))
                                            .Split(':', 2);
                        if (credentials.Length == 2)
                        {
                            //{
                            //   tablodan yetkili mi kontrolü yapılabilir
                            //}
                        }
                    }
                }
            }
            catch (FormatException ex)
            {
                context.Result = new UnauthorizedResult();

                context.HttpContext.Response.Headers["WWW-Authenticate"] = "Basic realm=\"\", charset=\"UTF-8\"";
            }
        }
    }
}
