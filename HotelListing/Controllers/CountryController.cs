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
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWork _unitOfWork, ILogger<CountryController> _logger, IMapper mapper)
        {
            this._unitOfWork = _unitOfWork;
            this._logger = _logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<CountryDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _unitOfWork.Countries.GetAll();
                var result = _mapper.Map<IList<CountryDto>>(countries);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountries)}.");
                return BadRequest(ex);
            }
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(CountryDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var country = await _unitOfWork.Countries.Get(c => c.Id == id, new List<string> { "Hotels" });
                var result = _mapper.Map<CountryDto>(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in {nameof(GetCountry)}.");
                return BadRequest(ex);
            }
        }
    }
}
