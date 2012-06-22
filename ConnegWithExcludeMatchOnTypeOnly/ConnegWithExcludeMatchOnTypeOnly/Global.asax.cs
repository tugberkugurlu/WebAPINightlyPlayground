using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Net.Http.Formatting;

namespace ConnegWithExcludeMatchOnTypeOnly {

    public class Global : System.Web.HttpApplication {

protected void Application_Start(object sender, EventArgs e) {

    var config = GlobalConfiguration.Configuration;
    var routes = config.Routes;

    // From DefaultContentNegotiator class:
    // If ExcludeMatchOnTypeOnly is true then we don't match on type only which means
    // that we return null if we can't match on anything in the request. This is useful
    // for generating 406 (Not Acceptable) status codes.
    config.Services.Replace(
        typeof(IContentNegotiator), 
        new DefaultContentNegotiator(excludeMatchOnTypeOnly: true)
    );

    routes.MapHttpRoute(
        "DefaultHttpRoute",
        "api/{controller}/{id}",
        new { id = RouteParameter.Optional }
    );
}
    }
}