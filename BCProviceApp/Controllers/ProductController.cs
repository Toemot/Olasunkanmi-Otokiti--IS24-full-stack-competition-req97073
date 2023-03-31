using AutoMapper;
using BCProviceApp.DataAccess;
using BCProviceApp.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BCProviceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _dataService;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository dataService, IMapper mapper)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<IEnumerable<ProductDTO>> GetProducts()
        {
            var products = _dataService.GetAllProducts();
            Log.Information($"Products successfully returned. {DateTime.UtcNow}");
            return Ok(_mapper.Map<IEnumerable<ProductDTO>>(products));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ProductDTO>> GetScrumMasterProduct(string searchQuery)
        {
            var products = _dataService.GetScrumMasterProducts(searchQuery);
            Log.Information($"Products successfully returned. {DateTime.UtcNow}");
            return Ok(_mapper.Map<ProductDTO>(products));
        }

        [HttpGet("{productId:int}", Name = "GetProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> GetProduct(int productId)
        {
            var product = _dataService.GetProductById(productId);
            if (product == null)
            {
                Log.Warning($"Products with {productId} was not found. {DateTime.UtcNow}");
                return NotFound();
            }
            Log.Information($"Products with {productId} successfully returned. {DateTime.UtcNow}");
            return Ok(_mapper.Map<ProductDTO>(product));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDTO> AddProduct(Product product)
        {
            if (product == null)
            {
                Log.Warning($"No Product was created. {DateTime.UtcNow}");
                return NotFound();
            }
            else
            {
                _dataService.AddProduct(product);
            }
            Log.Information($"Product with {product.ProductId} successfully created. {DateTime.UtcNow}");
            return CreatedAtRoute("GetProduct", new { product.ProductId }, product);
        }

        [HttpPut("{productId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ProductDTO> UpdateProduct(Product product, int productId)
        {
            if (product == null)
            {
                Log.Information($"Product with {productId} was not successfully updated. {DateTime.UtcNow}");
                return NotFound();
            }
            else
            {
                _dataService.UpdateProduct(product);
            }
            Log.Information($"Products with {productId} successfully updated. {DateTime.UtcNow}");
            return NoContent();
        }

        [HttpDelete("{productId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<ProductDTO> DeleteProduct(int productId)
        {
            if (productId <= 0)
            {
                Log.Information($"Product with {productId} not found. {DateTime.UtcNow}");
                return BadRequest();
            }
            else
            {
                _dataService.DeleteProduct(productId);
            }
            Log.Information($"Products with {productId} successfully deleted. {DateTime.UtcNow}");
            return NoContent();
        }
    }
}
