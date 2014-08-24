// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PushHelper.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The push extension.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Notifications;

namespace AppStudio.Menu.BackEnd
{
    /// <summary>
    /// The push helper.
    /// </summary>
    public static class PushHelper
    {
        /// <summary>
        /// Gets the windows push message for toast text01.
        /// </summary>
        /// <param name="typeOfOperation">The type of operation.</param>
        /// <param name="content">The content.</param>
        /// <returns>The IPushMessage.</returns>
        public static IPushMessage GetWindowsPushMessageForToastText01(string typeOfOperation, string content)
        {
            var payload = new StringBuilder();
            payload.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            payload.Append(@"<toast><visual><binding template=""ToastText01"">");
            payload.Append(@"<text id=""1"">");
            payload.Append(typeOfOperation);
            payload.Append(content);
            payload.Append(@"</text>");
            payload.Append(@"</binding></visual></toast>");
            return new WindowsPushMessage
            {
                XmlPayload = payload.ToString()
            };
        }

        /// <summary>
        /// The get windows push message for toast image and text 03.
        /// </summary>
        /// <param name="typeOfOperation">
        /// The type of operation.
        /// </param>
        /// <param name="title">
        /// The title.
        /// </param>
        /// <param name="subtitle">
        /// The subtitle.
        /// </param>
        /// <param name="image">
        /// The image.
        /// </param>
        /// <returns>
        /// The <see cref="IPushMessage"/>.
        /// </returns>
        public static IPushMessage GetWindowsPushMessageForToastImageAndText03(string typeOfOperation, string title, string subtitle, string image)
        {
            var payload = new StringBuilder();
            payload.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            payload.Append(@"<toast><visual><binding template=""ToastImageAndText03"">");
            payload.Append(@"<image id=""1"" src=""");
            payload.Append(image);
            payload.Append(@""" alt=""image1"" />");
            payload.Append(@"<text id=""1"">");
            payload.Append(typeOfOperation);
            payload.Append(title);
            payload.Append(@"</text>");
            payload.Append(@"<text id=""2"">");
            payload.Append(subtitle);
            payload.Append(@"</text>");
            payload.Append(@"</binding></visual></toast>");
            return new WindowsPushMessage
            {
                XmlPayload = payload.ToString()
            };
        }
    }
}