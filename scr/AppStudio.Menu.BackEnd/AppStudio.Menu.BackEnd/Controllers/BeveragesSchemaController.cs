// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BeveragesSchemaController.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the BeveragesSchemaController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using AppStudio.Data;
using AppStudio.Menu.BackEnd.Models;
using Microsoft.WindowsAzure.Mobile.Service;

namespace AppStudio.Menu.BackEnd.Controllers
{
    /// <summary>
    /// The beverages schema controller.
    /// </summary>
    public class BeveragesSchemaController : TableController<BeveragesSchema>
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
            DomainManager = new EntityDomainManager<BeveragesSchema>(context, Request, Services);
        }

        /// <summary>
        /// The get all beverages schema.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/> of beverages schema.
        /// </returns>
        public IQueryable<BeveragesSchema> GetAllBeveragesSchema()
        {
            return Query(); 
        }

        /// <summary>
        /// The get beverages schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/> of beverages schema.
        /// </returns>
        public SingleResult<BeveragesSchema> GetBeveragesSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return Lookup(id);
        }

        /// <summary>
        /// The patch beverages schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="patch">
        /// The patch.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> of beverages schema.
        /// </returns>
        public async Task<BeveragesSchema> PatchBeveragesSchema(string id, Delta<BeveragesSchema> patch)
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
        /// The post beverages schema.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> of IHttpActionResult.
        /// </returns>
        public async Task<IHttpActionResult> PostBeveragesSchema(BeveragesSchema item)
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
        /// The delete beverages schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteBeveragesSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
             return DeleteAsync(id);
        }
    }
}