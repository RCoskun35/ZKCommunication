using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserApiService _userApiService;

        public UsersController(UserApiService userApiService)
        {
            _userApiService = userApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _userApiService.AllAsync());

        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(UserDto userDto)

        {
            if (ModelState.IsValid)
            {

                await _userApiService.SaveAsync(userDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [ServiceFilter(typeof(NotFoundFilter<User>))]
        public async Task<IActionResult> Update(int id)
        {
            var user = await _userApiService.GetByIdAsync(id);
            return View(user);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UserDto userDto)
        {
            if (ModelState.IsValid)
            {

                await _userApiService.UpdateAsync(userDto);

                return RedirectToAction(nameof(Index));

            }

            return View(userDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _userApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
