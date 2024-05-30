using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetRegions()
        {

           var regions = mapper.Map<List<RegionDto>>(regionRepository.GetRegions());

           return Ok(regions);

        }

        [HttpGet("{id}")]
        public IActionResult GetRegionById(Guid id)
        {
            var region = mapper.Map <RegionDto> (regionRepository.GetRegionById(id));

            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }

        [HttpPost]
        public IActionResult CreateRegion([FromBody] RegionDto regionDto)
        {

            regionRepository.CreateRegion(mapper.Map<Region>(regionDto));
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRegion(Guid id, [FromBody] RegionDto regionDto)
        {
            var region = regionRepository.GetRegionById(id);

            if (region == null)
            {
                return NotFound();
            }

            regionRepository.UpdateRegion(mapper.Map<Region>(regionDto));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRegion(Guid id)
        {
            var region = regionRepository.GetRegionById(id);

            if (region == null)
            {
                return NotFound();
            }

            regionRepository.DeleteRegion(region);

            return NoContent();
        }
    }
}
