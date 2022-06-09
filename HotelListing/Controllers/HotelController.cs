using AutoMapper;
using HotelListing.IRepository;
using HotelListing.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelListing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork _unitOfWork, ILogger<CountryController> _logger, IMapper mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._logger = _logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<HotelDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var countries = await _unitOfWork.Hotels.GetAll();
                var result = _mapper.Map<IList<HotelDto>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetHotels)}.");
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(HotelDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var country = await _unitOfWork.Hotels.Get(c => c.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDto>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetHotel)}.");
                return BadRequest(ex);
            }
        }
    }
}
