using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.Application.Catalog.Products;
using eShopSolution.ViewModel.Catalog.ProductImage;
using eShopSolution.ViewModel.Catalog.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IManageProductService _manageProductService;
        private readonly IPublicProductService _publicProductService;
        public ProductsController(IPublicProductService publicProductService,
                                 IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        // Https://localhost:port/api/product
        [HttpGet]
        public async Task<IActionResult> Get(string languageId)
        {
            var product = await _publicProductService.GetAll(languageId);
            return Ok(product);
        }

        // Https://localhost:port/api/product/public-paging?pageIndex=0&pageSize=10
        [HttpGet("{languageId}")]
        public async Task<IActionResult> GetAllPublicPaging(string languageId, [FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryById(languageId, request);
            return Ok(products);
        }

        // Https://localhost:port/api/product/1
        [HttpGet("{productId}/{languageId}")]
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var effected = await _manageProductService.Update(request);
            if (effected == 0)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete([FromQuery] int productId)
        {
            var effected = await _manageProductService.Delete(productId);
            if (effected == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
        

        [HttpPatch("{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery] int productId, [FromQuery] decimal newPrice)
        {
            var result = await _manageProductService.UpdatePrice(productId, newPrice);
            if (!result)
            {
                return BadRequest();
            }
            return Ok();
        }

        // Https://localhost:port/api/product/1
        [HttpGet("{productId}/images/{imageId}", Name = "GetProductImageById")]
        public async Task<IActionResult> GetProductImageById(int productId, int imageId)
        {
            var product = await _manageProductService.GetProductImageById(productId, imageId);
            if (product == null)
            {
                return BadRequest("Can not found product");
            }
            return Ok(product);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var imageId = await _manageProductService.AddImage(productId, request);
            if (imageId == 0)
            {
                return BadRequest();
            }
            var image = await _manageProductService.GetProductImageById(productId, imageId);
            return CreatedAtAction(nameof(GetProductImageById), new { productId = productId, imageId = imageId }, image);
        }

        [HttpPut("/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
