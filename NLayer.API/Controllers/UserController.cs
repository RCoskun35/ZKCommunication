using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{


    public class UserController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _service;

        public UserController(IMapper mapper, IUserService userService)
        {
          
            _mapper = mapper;
            _service = userService;
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var user = await _service.GetAllAsync();
            var usersDtos = _mapper.Map<List<UserDto>>(user.ToList());
            return CreateActionResult(CustomResponseDto<List<UserDto>>.Success(200, usersDtos));
        }

       
    [ServiceFilter(typeof(NotFoundFilter<User>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            
            var user = await _service.GetByIdAsync(id);
            var usersDtos = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(200, usersDtos));
        }



        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)
        {
            var user = await _service.AddAsync(_mapper.Map<User>(userDto));
            var usersDto = _mapper.Map<UserDto>(user);
            return CreateActionResult(CustomResponseDto<UserDto>.Success(201, usersDto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UserDto userDto)
        {
             await _service.UpdateAsync(_mapper.Map<User>(userDto));
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
      
      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _service.GetByIdAsync(id);


         

            await _service.RemoveAsync(user);
          
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
