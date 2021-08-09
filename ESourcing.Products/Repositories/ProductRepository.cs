using System.Collections.Generic;
using System.Threading.Tasks;
using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Entities;
using ESourcing.Products.Repositories.Interfaces;
using MongoDB.Driver;

namespace ESourcing.Products.Repositories
{
    public class ProductRepository: IProductRepository
    {
        private readonly IProductContext _productContext;
        public ProductRepository(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _productContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            var filter = Builders<Product>.Filter.ElemMatch(p => p.Name, name);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
            return await _productContext.Products.Find(filter).ToListAsync();
        }

        public async Task Create(Product product)
        {
            await _productContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> Update(Product product)
        {
            var updatedResult =
                await _productContext.Products.ReplaceOneAsync(filter: g => g.Id == product.Id, replacement: product);

            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(m => m.Id, id);
            DeleteResult deleteResult = await _productContext.Products.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}