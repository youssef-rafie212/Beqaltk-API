﻿using Core.DTO.ReviewsDtos;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewServices _services;

        public ReviewsController(IReviewServices services)
        {
            _services = services;
        }

        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetAllForProduct(Guid id)
        {
            try
            {
                return Ok(await _services.GetAllReviewsForProduct(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                return Ok(await _services.GetReviewById(id));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateReviewDto createReview)
        {
            try
            {
                return Ok(await _services.CreateReview(createReview));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateReviewDto updateReview)
        {
            try
            {
                updateReview.Id = id;
                return Ok(await _services.UpdateReview(updateReview));
            }
            catch (Exception ex)
            {
                return Problem(ex.Message, statusCode: 400);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool isDeleted = await _services.DeleteReviewById(id);
            if (!isDeleted) return Problem("ID not found or invalid", statusCode: 400);
            return NoContent();
        }
    }
}
