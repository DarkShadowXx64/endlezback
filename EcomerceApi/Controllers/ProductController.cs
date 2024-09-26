using AutoMapper;
using Business.Logic.ProductLogic;
using Core.Dtos.Product;
using Core.Entities;
using Core.Interface;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;


namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly ProductResponse _response;
        private IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository
           , ProductResponse response
            , IMapper mapper
            )
        {
            _productRepository = productRepository;
            _response = response;
            _mapper = mapper;
        }


        [HttpGet("{ProductId}")]
        public async Task<ActionResult<ProductResponse>> GetByGuidId(Guid ProductId)
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                var product = products.Where(c => !c.IsDeleted && c.Id == ProductId).FirstOrDefault();
                _response.DataObject = _mapper.Map<ProductDto>(product);

            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }

        [HttpPost]
        public async Task<ProductResponse> Post(ProductCreateDto product)
        {
            try
            {
                
                var _product = _mapper.Map<Product>(product);
                var result = await _productRepository.Insert(_product);
                _response.DataObject = _mapper.Map<ProductDto>(result);
            }
            catch (Exception ex)
            {

                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }

        [HttpPut]
        public async Task<ProductResponse> Update(ProductUpdateDto product)
        {
            try
            {
                var existingProduct = await _productRepository.GetByGuidAsync(product.Id);
                if (existingProduct == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "El Producto no se encontró.";
                    return _response;
                }
                var originalCreatedDate = existingProduct.CreatedDate;

                var _product = _mapper.Map(product, existingProduct);
                _product.CreatedDate = originalCreatedDate;
                _productRepository.Update(_product);
                var result = await _productRepository.SaveAsync();
                _response.Message = "El cambio se realizó con éxito.";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return _response;
        }


        [HttpDelete("softdelete/{id}")]
        public async Task<ProductResponse> SoftDelete(Guid id)
        {
            try
            {
                await _productRepository.SoftDeleteByGuid(id);
                _response.Message = "El Producto se eliminó.";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }
    }
}
