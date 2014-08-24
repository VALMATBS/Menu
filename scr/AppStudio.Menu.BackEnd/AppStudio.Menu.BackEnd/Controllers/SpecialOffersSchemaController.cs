// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpecialOffersSchemaController.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the SpecialOffersSchemaController type.
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
    /// The special offers schema controller.
    /// </summary>
    public class SpecialOffersSchemaController : TableController<SpecialOffersSchema>
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
            DomainManager = new EntityDomainManager<SpecialOffersSchema>(context, Request, Services);
        }

        /// <summary>
        /// The get all special offers schema.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<SpecialOffersSchema> GetAllSpecialOffersSchema()
        {
            return Query(); 
        }

        /// <summary>
        /// The get special offers schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public SingleResult<SpecialOffersSchema> GetSpecialOffersSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return Lookup(id);
        }

        /// <summary>
        /// The patch special offers schema.
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
        public async Task<SpecialOffersSchema> PatchSpecialOffersSchema(string id, Delta<SpecialOffersSchema> patch)
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
            await Services.Push.SendAsync(PushHelper.GetWindowsPushMessageForToastText01("Update:", dto.Title));
            return dto;
        }

        /// <summary>
        /// The post special offers schema.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IHttpActionResult> PostSpecialOffersSchema(SpecialOffersSchema item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (string.IsNullOrEmpty(item.Title)
                || string.IsNullOrEmpty(item.Subtitle)
                || string.IsNullOrEmpty(item.Starter1)
                || string.IsNullOrEmpty(item.Main1)
                || string.IsNullOrEmpty(item.Dessert1))
            {
                return BadRequest("There are properties that are not defined.");
            }
            var current = await InsertAsync(item);
                await Services.Push.SendAsync(PushHelper.GetWindowsPushMessageForToastText01("Insert:", current.Title));
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        /// <summary>
        /// The delete special offers schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteSpecialOffersSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DeleteAsync(id);
        }
    }
}