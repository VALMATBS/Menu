// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the WebApiConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity.Migrations;
using AppStudio.Menu.BackEnd.Migrations;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Config;

namespace AppStudio.Menu.BackEnd
{
    /// <summary>
    /// The web api config.
    /// </summary>
    public class WebApiConfig : IBootstrapper
    {
        /// <summary>
        /// The register.
        /// </summary>
        public void Initialize()
        {
            // Use this class to set configuration options for your mobile service
            var options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
            // config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}
