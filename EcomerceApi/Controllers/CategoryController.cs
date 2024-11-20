using AutoMapper;
using Business.Logic.CategoryLogic;
using Core.Dtos.Category;
using Core.Entities;
using Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcomerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        private readonly IGenericRepository<Category> _categoryRepository;
        private readonly CategoryResponse _response;
        private IMapper _mapper;
        public CategoryController(IGenericRepository<Category> categoryRepository
            , CategoryResponse response
            , IMapper mapper
            )
        {
            _categoryRepository = categoryRepository;
            _response = response;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<CategoryResponse>> GetAll()
        {
            try
            {

                var category = await _categoryRepository.GetAllAsync();
                _response.ListDataObject = _mapper.Map<IReadOnlyList<CategoryDto>>(category);

            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }
      
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<CategoryResponse> GetById(Guid id)
        {
            try
            {
                var category = await _categoryRepository.GetByGuidAsync(id);

                if (category == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "La categoria no se encontró.";
                    return _response;
                }
                _response.DataObject = _mapper.Map<CategoryDto>(category);
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }

        [HttpPost]
        public async Task<CategoryResponse> Post(CategoryCreateDto company)
        {
            try
            {
                var _company = _mapper.Map<Category>(company);
                var result = await _categoryRepository.Insert(_company);
                _response.DataObject = _mapper.Map<CategoryDto>(result);
            }
            catch (Exception ex)
            {

                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }
            return _response;
        }

        [HttpPut]
        public async Task<CategoryResponse> Update(CategoryUpdateDto category)
        {
            try
            {
                var existingCategory = await _categoryRepository.GetByGuidAsync(category.Id);
                if (existingCategory == null)
                {
                    _response.statusCode = 404;
                    _response.Message = "La categoria no se encontró.";
                    return _response;
                }
                //var originalCreatedDate = existingCompany.CreatedDate;

                var _company = _mapper.Map(category, existingCategory);
                //_company.CreatedDate = originalCreatedDate;
                _categoryRepository.Update(_company);
                var result = await _categoryRepository.SaveAsync();
                _response.Message = "El cambio se realizó con éxito.";
            }
            catch (Exception ex)
            {
                _response.statusCode = 500;
                _response.Message = string.Concat(ex.Message, ex.InnerException, ex.StackTrace);
            }

            return _response;
        }


        [HttpDelete("{id}")]
        public async Task<CategoryResponse> SoftDeleteCategory(Guid id)
        {
            try
            {
                await _categoryRepository.Delete(id);
                _response.Message = "La categoria se eliminó.";
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
