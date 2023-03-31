using BCProviceApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCProviceApp.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private const string StorageFile = "Product.json";

        public void DeleteProduct(int id)
        {
            var products = ReadFromFile();
            var exisiting = products.Single(p => p.ProductId == id);
            products.Remove(exisiting);
            SaveToFile(products);
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return ReadFromFile();
        }

        public IEnumerable<Product> GetScrumMasterProducts(string searchQuery)
        {
            if (!string.IsNullOrWhiteSpace(searchQuery))
                searchQuery = searchQuery.Trim();

            return ReadFromFile().Where(p => string.Equals
                (searchQuery, p.ScrumMaster, StringComparison.InvariantCultureIgnoreCase));
        }

        public Product GetProductById(int id)
        {
            var products = ReadFromFile();
            return products.Single(p => p.ProductId == id);
        }

        //public void SaveProduct(Product product)
        //{
        //    if (product.ProductId <= 0)
        //    {
        //        AddProduct(product);
        //    }
        //    else
        //    {
        //        UpdateProduct(product);
        //    }
        //}

        public void UpdateProduct(Product product)
        {
            var products = ReadFromFile();
            var exisiting = products.Single(p => p.ProductId == product.ProductId);
            var indexOfExisiting = products.IndexOf(exisiting);
            products.Insert(indexOfExisiting, product);
            products.Remove(exisiting);
            SaveToFile(products);
        }

        public void AddProduct(Product product)
        {
            var products = ReadFromFile();
            var maxProductId = products.Max(p => p.ProductId);
            product.ProductId = maxProductId + 1;
            products.Add(product);
            SaveToFile(products);
        }

        private void SaveToFile(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(StorageFile, json);
        }

        private List<Product> ReadFromFile()
        {
            if (!File.Exists(StorageFile))
            {
                return new List<Product>
                {
                    new Product { ProductId = 1, ProductName = "CRM", ProductOwner = "Thomas", ScrumMaster = "Julia", StartDate = new DateTime(2013, 1, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 2, ProductName = "Server", ProductOwner = "Huber", ScrumMaster = "Lisa", StartDate = new DateTime(2013, 2, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 3, ProductName = "Desk", ProductOwner = "Julia", ScrumMaster = "Lisa", StartDate = new DateTime(2013, 3, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 4, ProductName = "Email", ProductOwner = "Lisa", ScrumMaster = "Alan", StartDate = new DateTime(2013, 4, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 5, ProductName = "Computer", ProductOwner = "Alan", ScrumMaster = "Adam", StartDate = new DateTime(2013, 5, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 6, ProductName = "Laptop", ProductOwner = "Adam", ScrumMaster = "Kroon", StartDate = new DateTime(2013, 6, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 7, ProductName = "Cloud", ProductOwner = "Kroon", ScrumMaster = "Julia", StartDate = new DateTime(2013, 7, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 8, ProductName = "Office", ProductOwner = "Justin", ScrumMaster = "Hewitt", StartDate = new DateTime(2013, 8, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 9, ProductName = "365", ProductOwner = "Hewitt", ScrumMaster = "Foo", StartDate = new DateTime(2013, 9, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 10, ProductName = "Word", ProductOwner = "Foo", ScrumMaster = "Bar", StartDate = new DateTime(2013, 10, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 11, ProductName = "Excel", ProductOwner = "Bar", ScrumMaster = "Cace", StartDate = new DateTime(2013, 12, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 12, ProductName = "PowerPoint", ProductOwner = "Cace", ScrumMaster = "Sese", StartDate = new DateTime(2013, 1, 10), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 13, ProductName = "System", ProductOwner = "Sese", ScrumMaster = "Anna", StartDate = new DateTime(2013, 1, 11), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 14, ProductName = "Azure", ProductOwner = "Anna", ScrumMaster = "Sara", StartDate = new DateTime(2013, 1, 12), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 15, ProductName = "GCP", ProductOwner = "Sara", ScrumMaster = "Andreas", StartDate = new DateTime(2013, 1, 13), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 16, ProductName = "AWS", ProductOwner = "Andreas", ScrumMaster = "Urs", StartDate = new DateTime(2013, 1, 14), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 17, ProductName = "MSC", ProductOwner = "Urs", ScrumMaster = "Bohler", StartDate = new DateTime(2013, 1, 15), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 18, ProductName = "IBM", ProductOwner = "Bohler", ScrumMaster = "Meier", StartDate = new DateTime(2013, 1, 16), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 19, ProductName = "MCITP", ProductOwner = "Meier", ScrumMaster = "Chrissi", StartDate = new DateTime(2013, 1, 17), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 20, ProductName = "IITPSA", ProductOwner = "Chrissi", ScrumMaster = "Heuberger", StartDate = new DateTime(2013, 1, 18), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 21, ProductName = "WebApp", ProductOwner = "Heuberger", ScrumMaster = "Thomas", StartDate = new DateTime(2013, 1, 19), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 22, ProductName = "WebAPI", ProductOwner = "Thomas", ScrumMaster = "Erkan", StartDate = new DateTime(2013, 1, 20), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 23, ProductName = "Virtual", ProductOwner = "Erkan", ScrumMaster = "Egin", StartDate = new DateTime(2013, 1, 21), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 24, ProductName = "Remote", ProductOwner = "Egin", ScrumMaster = "Sing", StartDate = new DateTime(2013, 1, 22), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 25, ProductName = "Data", ProductOwner = "Sing", ScrumMaster = "Lord", StartDate = new DateTime(2013, 1, 23), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 26, ProductName = "Security", ProductOwner = "Lord", ScrumMaster = "Don", StartDate = new DateTime(2013, 1, 24), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 27, ProductName = "Printer", ProductOwner = "Don", ScrumMaster = "Ola", StartDate = new DateTime(2013, 1, 25), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 28, ProductName = "Phone", ProductOwner = "Ola", ScrumMaster = "Soro", StartDate = new DateTime(2013, 1, 2), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 29, ProductName = "Chatbot", ProductOwner = "Soro", ScrumMaster = "Peter", StartDate = new DateTime(2013, 1, 3), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 30, ProductName = "Artificial", ProductOwner = "Peter", ScrumMaster = "Okpoki", StartDate = new DateTime(2013, 1, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{"NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 31, ProductName = "Intellegence", ProductOwner = "Okpoki", ScrumMaster = "Isaac", StartDate = new DateTime(2013, 1, 4), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 32, ProductName = "Router", ProductOwner = "Isaac", ScrumMaster = "Wande", StartDate = new DateTime(2013, 1, 5), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 33, ProductName = "Switches", ProductOwner = "Wande", ScrumMaster = "Philip", StartDate = new DateTime(2013, 1, 6), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 34, ProductName = "Ports", ProductOwner = "Philip", ScrumMaster = "Boss", StartDate = new DateTime(2013, 1, 7), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 35, ProductName = "DMZ", ProductOwner = "Boss", ScrumMaster = "Christie", StartDate = new DateTime(2013, 1, 8), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 36, ProductName = "Bells", ProductOwner = "Christie", ScrumMaster = "Spiteri", StartDate = new DateTime(2013, 1, 9), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 37, ProductName = "Func", ProductOwner = "Spiteri", ScrumMaster = "Veena", StartDate = new DateTime(2013, 1, 10), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 38, ProductName = "Github", ProductOwner = "Veena", ScrumMaster = "Julia", StartDate = new DateTime(2013, 3, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 39, ProductName = "Json", ProductOwner = "Anchal", ScrumMaster = "Julia", StartDate = new DateTime(2013, 4, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                    new Product { ProductId = 40, ProductName = "Locale", ProductOwner = "Thomas", ScrumMaster = "Julia", StartDate = new DateTime(2013, 6, 1), Methodology = Methodology.Agile, DeveloperName = new List<string>{ "NAME_1, NAME_2, NAME_3, NAME_4, NAME_5" } },
                };
            }

            string json = File.ReadAllText(StorageFile);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }
    }
}
