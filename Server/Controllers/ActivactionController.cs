using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{

    [ApiController]
    [Route("activaction")]
    public class ActivactionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivactionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(ActivateViewModel model)
        {
            var validSerials = await System.IO.File.ReadAllLinesAsync(Constants.ValidSerialsFilePath);
            if (validSerials.Contains(model.SerialNumber))
            {
                _context.ActivationHistoryCredentials.Add(ActivationHistoryCredential.FromActivateViewModel(model));
                await _context.SaveChangesAsync();

                return Ok("Validate operation completed successfully!");
            }

            return Unauthorized("Serial number not found!");
        }
    }
}
