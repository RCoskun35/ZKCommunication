using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class EventDataController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IEventDataService _service;

        public EventDataController(IMapper mapper, IEventDataService eventDataService)
        {
          
            _mapper = mapper;
            _service = eventDataService;
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var eventdata = await _service.GetAllAsync();
            var eventdatasDtos = _mapper.Map<List<EventData>>(eventdata.ToList());
            return CreateActionResult(CustomResponseDto<List<EventData>>.Success(200, eventdatasDtos));
        }

       
    [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            
            var eventdata = await _service.GetByIdAsync(id);
            var eventdatasDtos = _mapper.Map<EventDataDto>(eventdata);
            return CreateActionResult(CustomResponseDto<EventDataDto>.Success(200, eventdatasDtos));
        }



        [HttpPost]
        public async Task<IActionResult> Save(EventDataDto eventdataDto)
        {
            var eventdata = await _service.AddAsync(_mapper.Map<EventData>(eventdataDto));
            var eventdatasDto = _mapper.Map<EventDataDto>(eventdata);
            return CreateActionResult(CustomResponseDto<EventDataDto>.Success(201, eventdatasDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(EventDataDto eventdataDto)
        {
             await _service.UpdateAsync(_mapper.Map<EventData>(eventdataDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
      
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var eventdata = await _service.GetByIdAsync(id);


         

            await _service.RemoveAsync(eventdata);
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
