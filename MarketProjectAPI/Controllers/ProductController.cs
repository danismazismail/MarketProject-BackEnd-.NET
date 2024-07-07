using ApplicationCore.Dtos.Products;
using ApplicationCore.Entities.Abstract;
using ApplicationCore.Entities.Concrete;
using AutoMapper;
using DataAccess.Sevices.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarketProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        [HttpGet("GetProductAsync")]
        public async Task<IActionResult> GetProductAsync()
        {
            var products = await _productRepo.GetFiltredListAsync(
                select: x => new GetProductDto()
                {
                    Name = x.Name,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    CreatedDate = x.CreatedDate,
                    Id = x.Id,
                    Status = x.Status,
                    UpdatedDate = x.UpdateDate,
                    CategoryName = x.Category.Name,
                    CategoryId = x.Category.Id,
                },
                where: x => x.Status != Status.Passive,
                orderBy: x => x.OrderBy(x => x.CreatedDate)
                );
            return Ok(products);
        }

        [HttpGet("GetProductByIdAsync")]
        public async Task<IActionResult> GetProductByIdAsync([FromQuery] int Id)
        {
            //return await _context.Products
            //.Include(p => p.Category) // Include Category
            //.FirstOrDefaultAsync(p => p.Id == id);

            var products =  await _productRepo.GetFiltredListAsync(
                            select: product => _mapper.Map<GetProductDto>(product),
                            where: product => product.Status != Status.Passive && product.Id == Id,
                            join: query => query.Include(p => p.Category));

            var dto = _mapper.Map<GetProductDto>(products[0]);

            if (dto is not null)
                return Ok(dto);

            return NotFound("Bu Id Kayıtlı Degil.");
        }

        [HttpPost("CreateProductAsync")]
        public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Birşeyler Ters Gitti Tekrar Deneyiniz.");
            if (await _productRepo.AnyAsync(x => x.Name == productDto.Name))
                return BadRequest("Bu isimde bir kayıt bulunmaktadır.");

            var product = _mapper.Map<Product>(productDto);

            await _productRepo.AddAsync(product);
            return Ok($"Ürün Eklenmiştir.\nEklenen Ürün Bilgileri:\nName: {product.Name}\nPrice: {product.Price}\nQuantity: {product.Quantity}");
        }

        [HttpPut("UpdateProductAsync")]
        public async Task<IActionResult> UpdateProductAsync([FromForm]UpdateProductDto productDto)
        {
            if (productDto == null)
                return BadRequest("Birşeyler ters gitti");

            if (await _productRepo.AnyAsync(x => x.Name == productDto.Name && x.Id != productDto.Id && x.Status != Status.Passive))
                return BadRequest("Bu isim kullanılmaktadır.");
            if (!await _productRepo.AnyAsync(x => x.Id == productDto.Id))
                return NotFound("Bu id'ye sahip category bulunamadı");

            var entity = await _productRepo.GetByIdAsync(productDto.Id);

            var product = _mapper.Map<Product>(productDto);
            product.CreatedDate = entity.CreatedDate;

            await _productRepo.UpdateAsync(product);
            return Ok($"Kategori güncecllenmiştir \nKAtegori Bilgileri: \n{product.Name}\n{product.UpdateDate}");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            if (Id <= 0)
                return BadRequest("Ters Gitt");

            var product = await _productRepo.GetByIdAsync(Id);

            if (product is null)
                return BadRequest("bulunamadı");

            await _productRepo.DeleteAsync(product);
            return Ok($"Kategori silinmiştir. \n{product.Name}");
        }
    }
}