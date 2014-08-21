// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MobileServiceContext.cs" company="saramgsilva">
//   Copyright (c) 2014 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   The mobile service context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace AppStudio.Menu.BackEnd.Models
{
    /// <summary>
    /// The mobile service context.
    /// </summary>
    public class MobileServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string ConnectionStringName = "Name=MS_TableConnectionString";

        /// <summary>
        /// Initializes a new instance of the <see cref="MobileServiceContext"/> class.
        /// </summary>
        public MobileServiceContext()
            : base(ConnectionStringName)
        {
        }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

       public DbSet<Data.BeveragesSchema> BeveragesSchemas { get; set; }

        public DbSet<DataObjects.DessertsSchema> DessertsSchemas { get; set; }

        public DbSet<DataObjects.MainSchema> MainSchemas { get; set; }

        public DbSet<DataObjects.SpecialOffersSchema> SpecialOffersSchemas { get; set; }

        public DbSet<DataObjects.StartersSchema> StartersSchemas { get; set; }
    }
}
