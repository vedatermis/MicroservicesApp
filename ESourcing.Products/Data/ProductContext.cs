using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Entities;
using ESourcing.Products.Settings;
using MongoDB.Driver;

namespace ESourcing.Products.Data
{
    public class ProductContext: IProductContext
    {
        public ProductContext(IProductDatabaseSettings productDatabaseSettings)
        {
            var client = new MongoClient(productDatabaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(productDatabaseSettings.DatabaseName);

            Products = database.GetCollection<Product>(productDatabaseSettings.CollectionName);
            ProductContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}