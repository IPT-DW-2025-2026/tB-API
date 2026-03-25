using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tB_Fotografias.Data;
using tB_Fotografias.Models;
using tB_Fotografias.Models.Api;

namespace tB_Fotografias.Controllers.ApiOperations
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }


        /// <summary>/// Alterar para não retornar diretamente o que está na base de dados, mas sim uma lista de DTOs/// </summary>/// <returns></returns>// GET: api/ApiCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var listCategories = await _context.Categories

                .Include(c => c.ListOfPhotos).ToListAsync();


            // lista de categories DTO que vai ser retornada pela API
            var listCategoriesDto = new List<CategoryDto>();


            // converter cada categories da BD para um photo DTO e adicionar à lista de categories DTO
            foreach (var category in listCategories)
            {
                var categoryDto = new CategoryDto()
                {
                    Name = category.Name,

                };



                foreach (var photo in category.ListOfPhotos)
                {
                    var photoDto = new PhotosDto()
                    {
                        Title = photo.Title,

                        File = photo.File,

                    };

                    categoryDto.Photos.Add(photoDto);

                }
                listCategoriesDto.Add(categoryDto);

            }
            return listCategoriesDto;

        }
        [Route("test")]
        [HttpGet]
        public async Task<ActionResult> TestRoute([FromQuery] int id)
        {
            return Ok("Rota de teste a funcionar com id: " + id);

        }

        // GET: api/ApiCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }


        /// <summary>
        /// Alterar para não receber diretamente o objeto Category, que é guardado diretamente na base de dados
        /// </summary>
        /// <returns></returns>
        // PUT: api/ApiCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDto category)
        {
            // validar se a categoria já existe
            var categoriaExists = _context.Categories.FirstOrDefault(c => c.Name.Equals(category.Name));
            if (categoriaExists != null)
            {
                return BadRequest("Categoria com este Name já existe");
            }

            var categoryEntry = new Category() { Name = category.Name };
            _context.Categories.Add(categoryEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = categoryEntry.Id }, categoryEntry);
        }

        // DELETE: api/ApiCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
