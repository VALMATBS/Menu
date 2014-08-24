// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StartersSchemaController.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the StartersSchemaController type.
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
    /// The starters schema controller.
    /// </summary>
    public class StartersSchemaController : TableController<StartersSchema>
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
            DomainManager = new EntityDomainManager<StartersSchema>(context, Request, Services);
        }

        /// <summary>
        /// The get all starters schema.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<StartersSchema> GetAllStartersSchema()
        {
            return Query(); 
        }

        /// <summary>
        /// The get starters schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public SingleResult<StartersSchema> GetStartersSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return Lookup(id);
        }

        /// <summary>
        /// The patch starters schema.
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
        public async Task<StartersSchema> PatchStartersSchema(string id, Delta<StartersSchema> patch)
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
        /// The post starters schema.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IHttpActionResult> PostStartersSchema(StartersSchema item)
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
        /// The delete starters schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteStartersSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DeleteAsync(id);
        }
    }
}