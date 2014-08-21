// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileService.cs" company="Xamarin Forms Labs">
//   Copyright (c) 2014 Xamarin Forms Labs. All rights reserved.
// </copyright>
// <summary>
//   Defines the Mobile Service wrapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Microsoft.WindowsAzure.MobileServices;

namespace AppStudio.Data.DataSources
{
    /// <summary>
    /// Defines the Mobile Service wrapper.
    /// </summary>
    /// <typeparam name="T">The type of the DTO.</typeparam>
    public sealed class MobileService<T>
    {
        private static MobileServiceClient _appStudioBackEnd;

        /// <summary>
        /// Gets the application studio back end.
        /// </summary>
        /// <value>The application studio back end.</value>
        private static MobileServiceClient AppStudioBackEnd
        {
            get
            {
              return _appStudioBackEnd ?? (_appStudioBackEnd = new MobileServiceClient("<the service url>", "<the application key from Portal>"));           }
            }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileService{T}"/> class.
        /// </summary>
        public MobileService()
        {
            Table = AppStudioBackEnd.GetTable<T>();
        }

        /// <summary>
        /// Gets or sets the table.
        /// </summary>
        /// <value>
        /// The table.
        /// </value>
        public IMobileServiceTable<T> Table { get; set; }
    }
}
