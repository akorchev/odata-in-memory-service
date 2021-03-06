﻿using System.Web.Http;
using ODataService.Models;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace ODataService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();

            builder.EntitySet<Product>("Products");

            config.MapODataServiceRoute("ODataRoute", null, builder.GetEdmModel());
        }
    }
}
