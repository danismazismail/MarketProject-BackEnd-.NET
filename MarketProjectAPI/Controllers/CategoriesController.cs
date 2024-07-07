using ApplicationCore.Dtos.Categories;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Sevices.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryRepo.GetFiltredListAsync(
                select: x => new GetCategortDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    Status = x.Status,
                    UpdatedDate = x.UpdateDate,
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(z=>z.CreatedDate)
                );
            return Ok(categories);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var category = await _categoryRepo.GetByIdAsync(Id);

            var dto = _mapper.Map<GetCategortDto>(category);

            if (dto is not null)
                return Ok(dto);

            return NotFound("Bu id yok");
        }

        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory([FromForm]CreateCategoryDto model)
        {
            if (model == null) 
                return BadRequest("Birşeyler ters gitti.");

            if (await _categoryRepo.AnyAsync(x=> x.Name == model.Name))
                return BadRequest("Bu isimde kayıt var tekrar dene");

            var category = _mapper.Map<Category>(model);

            await _categoryRepo.AddAsync(category);

            return Ok($"Kategori Eklenmiştir! \n{category.Name}\n{category.Description}");

        }

        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory([FromForm]UpdateCategoryDto model)
        {
            if (model == null)
                return BadRequest("Birşeyler ters gitti");

            if (await _categoryRepo.AnyAsync(x => x.Name == model.Name && x.Id != model.Id && x.Status!=Status.Passive))
                return BadRequest("Bu isim kullanılmaktadır.");
            if (!await _categoryRepo.AnyAsync(x => x.Id == model.Id))
                return NotFound("Bu id'ye sahip category bulunamadı");

            var entity = await _categoryRepo.GetByIdAsync(model.Id);
                        
            var category = _mapper.Map<Category>(model);
            category.CreatedDate = entity.CreatedDate;

            await _categoryRepo.UpdateAsync(category);
            return Ok($"Kategori güncecllenmiştir \nKAtegori Bilgileri: \n{category.Name}\n{category.Description}");
        }

        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int Id)
        {
            if (Id <= 0)
                return BadRequest("Ters Gitt");

            var category = await _categoryRepo.GetByIdAsync(Id);

            if (category is null)
                return BadRequest("bulunamadı");

            await _categoryRepo.DeleteAsync(category);
            return Ok($"Kategori silinmiştir. \n{category.Name}");
                       
        }
    }
}