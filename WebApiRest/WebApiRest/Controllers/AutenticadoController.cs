using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace WebApiRest.Controllers
{
    public class AutenticadoController : ApiController
    {
        public string Get(string id)
        {
            FormsAuthentication.SetAuthCookie(id ?? "FooUser", false);

            return "You are authenticated now";
        }
    }
}
