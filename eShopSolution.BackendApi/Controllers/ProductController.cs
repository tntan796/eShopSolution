using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModel.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        private readonly IPublicProductService _publicProductService;
        public ProductController(IPublicProductService publicProductService,
                                 IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // Https://localhost:port/api/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var product = await _publicProductService.GetAll();
            return Ok(product);
        }

        // Https://localhost:port/api/product/public-paging
        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryById(request);
            return Ok(products);
        }

        // Https://localhost:port/api/product/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int productId, string languageId)
        {
            var product = await _manageProductService.GetProductById(productId, languageId);
            if (product == null)
            {
                return BadRequest("Can not found product");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
            {
                return BadRequest();
            }
            var product = await _manageProductService.GetProductById(productId, request.LanguageId);
            return CreatedAtAction(nameof(GetById), new { id = productId}, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var effected = await _manageProductService.Update(request);
            if (effected == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int productId)
        {
            var effected = await _manageProductService.Delete(productId);
            if (effected == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        

        [HttpPut("price/{id}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int productId, [FromQuery] decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(productId, newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
