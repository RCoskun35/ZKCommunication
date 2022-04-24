using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class TerminalController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ITerminalService _service;

        public TerminalController(IMapper mapper, ITerminalService terminalService)
        {
          
            _mapper = mapper;
            _service = terminalService;
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var terminal = await _service.GetAllAsync();
            var terminalsDtos = _mapper.Map<List<TerminalDto>>(terminal.ToList());
            return CreateActionResult(CustomResponseDto<List<TerminalDto>>.Success(200, terminalsDtos));
        }

       
    [ServiceFilter(typeof(NotFoundFilter<Terminal>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            
            var terminal = await _service.GetByIdAsync(id);
            var terminalsDtos = _mapper.Map<TerminalDto>(terminal);
            return CreateActionResult(CustomResponseDto<TerminalDto>.Success(200, terminalsDtos));
        }



        [HttpPost]
        public async Task<IActionResult> Save(TerminalDto terminalDto)
        {
            var terminal = await _service.AddAsync(_mapper.Map<Terminal>(terminalDto));
            var terminalsDto = _mapper.Map<TerminalDto>(terminal);
            return CreateActionResult(CustomResponseDto<TerminalDto>.Success(201, terminalsDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(TerminalDto terminalDto)
        {
             await _service.UpdateAsync(_mapper.Map<Terminal>(terminalDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
      
        // DELETE api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var terminal = await _service.GetByIdAsync(id);


         

            await _service.RemoveAsync(terminal);
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
