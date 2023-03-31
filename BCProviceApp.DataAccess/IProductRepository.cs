using BCProviceApp.Model;

namespace BCProviceApp.DataAccess
{
    public interface IProductRepository : IDisposable
    {
        Product GetProductById(int id);
        //void SaveProduct(Product product);
        void DeleteProduct(int id);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product product);
        void AddProduct(Product product);
        IEnumerable<Product> GetScrumMasterProducts(string name);
    }
}
