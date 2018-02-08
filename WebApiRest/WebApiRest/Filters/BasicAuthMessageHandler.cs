using System;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace WebApiRest.Filters
{
    public class BasicAuthMessageHandler : DelegatingHandler

    {

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {

            var headers = request.Headers;

            if (headers.Authorization != null && headers.Authorization.Scheme == "Basic")

            {

                var userPwd = Encoding.UTF8.GetString(Convert.FromBase64String(headers.Authorization.Parameter));

                var user = userPwd.Substring(0, userPwd.IndexOf(':'));

                var password = userPwd.Substring(userPwd.IndexOf(':') +1);

                // Validamos user y password (aquí asumimos que siempre son ok)

                var principal = new GenericPrincipal(new GenericIdentity(user), null);

                PutPrincipal(principal);

            }
            

            return base.SendAsync(request, cancellationToken);

        }



        private void PutPrincipal(IPrincipal principal)
        {

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {

                HttpContext.Current.User = principal;

            }

        }

    }
}