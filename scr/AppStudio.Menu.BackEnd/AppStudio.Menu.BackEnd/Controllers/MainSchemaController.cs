﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainSchemaController.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainSchemaController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using AppStudio.Menu.BackEnd.DataObjects;
using AppStudio.Menu.BackEnd.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AppStudio.Menu.BackEnd.Controllers
{
    /// <summary>
    /// The main schema controller.
    /// </summary>
    public class MainSchemaController : TableController<MainSchema>
    {
        /// <summary>
        /// The initialize.
        /// </summary>
        /// <param name="controllerContext">
        /// The controller context.
        /// </param>
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            var context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<MainSchema>(context, Request, Services);
        }

        /// <summary>
        /// The get all main schema.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<MainSchema> GetAllMainSchema()
        {
            return Query(); 
        }

        /// <summary>
        /// The get main schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public SingleResult<MainSchema> GetMainSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return Lookup(id);
        }

        /// <summary>
        /// The patch main schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="patch">
        /// The patch.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<MainSchema> PatchMainSchema(string id, Delta<MainSchema> patch)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            if (patch == null)
            {
                throw new ArgumentNullException("patch");
            }
            var dto = await UpdateAsync(id, patch);
            await Services.Push.SendAsync(PushHelper.GetWindowsPushMessageForToastImageAndText03("Update:", dto.Title, dto.Subtitle, dto.Image));
            return dto;
        }

        /// <summary>
        /// The post main schema.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IHttpActionResult> PostMainSchema(MainSchema item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(item.Title)
                || string.IsNullOrEmpty(item.Subtitle)
                || string.IsNullOrEmpty(item.Image)
                || string.IsNullOrEmpty(item.Description))
            {
                return BadRequest("There are properties that are not defined.");
            }
            var current = await InsertAsync(item);
            await Services.Push.SendAsync(PushHelper.GetWindowsPushMessageForToastImageAndText03("Insert:", current.Title, current.Subtitle, current.Image));
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        /// <summary>
        /// The delete main schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteMainSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
             return DeleteAsync(id);
        }
    }
}