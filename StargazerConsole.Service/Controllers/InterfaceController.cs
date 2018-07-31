using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using StargazerConsole.DataServices;
using StargazerConsole.Models.Web;

namespace StargazerConsole.Controllers
{
    public class InterfaceController : Controller
    {
        private IShowInterfaceDataService _dataService;

        public InterfaceController(IShowInterfaceDataService dataService)
        {
            _dataService = dataService;
        }

        public IActionResult ShowInterface()
        {
            InterfaceViewModel viewModel =
                new InterfaceViewModel
                {
                    AllowedParities = _dataService.GetPossibleParities(),
                    AllowedStopBits = _dataService.GetPossibleStopBits(),
                    FocuserSerialSettings = _dataService.GetDefaultFocuserSerialSettings(),
                    TelescopeSerialSettings = _dataService.GetDefaultTelescopeSerialSettings(),
                    CurrentNexStarPorts = _dataService.GetCurrentNexStarPorts()
                };
            
            return View(viewModel);
        }
    }
}
