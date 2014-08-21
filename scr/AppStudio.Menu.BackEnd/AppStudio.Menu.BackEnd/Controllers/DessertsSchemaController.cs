// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DessertsSchemaController.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   Defines the DessertsSchemaController type.
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
    /// The desserts schema controller.
    /// </summary>
    public class DessertsSchemaController : TableController<DessertsSchema>
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
            DomainManager = new EntityDomainManager<DessertsSchema>(context, Request, Services);
        }

        /// <summary>
        /// The get all desserts schema.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        public IQueryable<DessertsSchema> GetAllDessertsSchema()
        {
            return Query();
        }

        /// <summary>
        /// The get desserts schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="SingleResult"/>.
        /// </returns>
        public SingleResult<DessertsSchema> GetDessertsSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return Lookup(id);
        }

        /// <summary>
        /// The patch desserts schema.
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
        public Task<DessertsSchema> PatchDessertsSchema(string id, Delta<DessertsSchema> patch)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            if (patch == null)
            {
                throw new ArgumentNullException("patch");
            }
            return UpdateAsync(id, patch);
        }

        /// <summary>
        /// The post desserts schema.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IHttpActionResult> PostDessertsSchema(DessertsSchema item)
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
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        /// <summary>
        /// The delete desserts schema.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task DeleteDessertsSchema(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException("id");
            }
            return DeleteAsync(id);
        }
    }
}