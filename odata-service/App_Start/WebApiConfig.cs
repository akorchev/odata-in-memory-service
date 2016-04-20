using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ODataService.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.Http.Cors;

namespace ODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var corsAttr = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(corsAttr);

            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Product>("Products");

            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}
