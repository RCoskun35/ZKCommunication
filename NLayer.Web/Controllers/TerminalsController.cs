using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class TerminalsController : Controller
    {

        private readonly TerminalApiService _terminalApiService;

        public TerminalsController(TerminalApiService terminalApiService)
        {
            _terminalApiService = terminalApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _terminalApiService.AllAsync());

        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(TerminalDto terminalDto)

        {


            if (ModelState.IsValid)
            {

                await _terminalApiService.SaveAsync(terminalDto);


                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [ServiceFilter(typeof(NotFoundFilter<Terminal>))]
        public async Task<IActionResult> Update(int id)
        {
            var terminal = await _terminalApiService.GetByIdAsync(id);


            



            

            return View(terminal);

        }

        [HttpPost]
        public async Task<IActionResult> Update(TerminalDto terminalDto)
        {
            if (ModelState.IsValid)
            {

                await _terminalApiService.UpdateAsync(terminalDto);

                return RedirectToAction(nameof(Index));

            }

       

            return View(terminalDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _terminalApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
