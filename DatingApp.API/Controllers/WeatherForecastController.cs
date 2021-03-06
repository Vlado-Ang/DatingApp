﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    //
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context = context;

        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetWeatherValues()
        {
            var wval = await _context.WeatherValues.ToListAsync();
            return Ok(wval);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWeatherValue(int id)
        {
            var wval = await _context.WeatherValues.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(wval);
        }
    }
}
