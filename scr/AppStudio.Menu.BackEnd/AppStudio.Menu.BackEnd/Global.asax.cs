// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The web api application.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AppStudio.Menu.BackEnd
{
    /// <summary>
    /// The web api application.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The application_ start.
        /// </summary>
        protected void Application_Start()
        {
            WebApiConfig.Register();
        }
    }
}