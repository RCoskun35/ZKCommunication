using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;
using NLayer.Web.Services;

namespace NLayer.Web.Controllers
{
    public class EventDatasController : Controller
    {

        private readonly EventDataApiService _eventDataApiService;

        public EventDatasController(EventDataApiService eventDataApiService)
        {
            _eventDataApiService = eventDataApiService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _eventDataApiService.AllAsync());

        }

        public async Task<IActionResult> Save()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(EventDataDto eventDataDto)

        {
            if (ModelState.IsValid)
            {

                await _eventDataApiService.SaveAsync(eventDataDto);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [ServiceFilter(typeof(NotFoundFilter<EventData>))]
        public async Task<IActionResult> Update(int id)
        {
            var eventdata = await _eventDataApiService.GetByIdAsync(id);
            return View(eventdata);

        }

        [HttpPost]
        public async Task<IActionResult> Update(EventDataDto eventDataDto)
        {
            if (ModelState.IsValid)
            {

                await _eventDataApiService.UpdateAsync(eventDataDto);

                return RedirectToAction(nameof(Index));

            }

            return View(eventDataDto);

        }


        public async Task<IActionResult> Remove(int id)
        {
            await _eventDataApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
