using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authorization;
using WebAPI.Models;
using WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;
using AutoMapper;

namespace OnlineShopWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewStorage _reviewStorage;
        private readonly IMapper _mapper;

        public ReviewController(ILogger<ReviewController> logger, IReviewStorage reviewStorage, IMapper mapper)
        {
            _logger = logger;
            _reviewStorage = reviewStorage;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение всех отзывов
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ReviewViewModel>>> GetAllAsync()
        {
            try
            {
                var result = await _reviewStorage.GetAllAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Получение отзыва по id
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllByProductId")]
        public async Task<ActionResult<List<ReviewViewModel>>> GetAllByProductIdAPIAsync(Guid productId)
        {
            try
            {
                var result = await _reviewStorage.GetAllByProductIdAsync(productId);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Удаление отзыва по id
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("DeleteById")]
        public async Task<ActionResult> DeleteByIdAsync(Guid id)
        {
            try
            {
                var result = await _reviewStorage.TryToDeleteByIdAsync(id);
                if (result)
                    return NoContent();
                return BadRequest(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }

        /// <summary>
        /// Добавление отзыва на продукт
        /// </summary>
        /// <param name="reviewViewModel"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        public async Task<ActionResult<ReviewDB>> AddAsync(ReviewViewModel reviewViewModel)
        {
            try
            {
                var review = _mapper.Map<ReviewDB>(reviewViewModel);
                var result = await _reviewStorage.AddAsync(review);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                return BadRequest(new { Error = e.Message });
            }
        }
    }


}
