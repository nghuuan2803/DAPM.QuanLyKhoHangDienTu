using Microsoft.AspNetCore.Mvc;
using WMS.Application.Interfaces;
using WMS.Domain.Entities.ProductInfo;

namespace WMS.API.Controllers.ProductGroup
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] string name)
        {
            var model = new Category { Name = name };
            var result = await service.AddAsync(model);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Category model)
        {
            var result = await service.UpdateAsync(model);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] int id)
        {
            var result = await service.DeleteAsync(id);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.FindAsync(id);
            return Ok(result);
        }
    }
}
