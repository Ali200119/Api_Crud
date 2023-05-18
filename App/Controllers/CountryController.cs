﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs.Country;
using Services.DTOs.Employee;
using Services.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : Controller
    {
        private readonly ICountryService _service;

        public CountryController(ICountryService service)
        {
            _service = service;
        }


        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(CountryDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById([FromRoute][Required] int id)
        {
            try
            {
                return Ok(await _service.GetByIdAsync(id));
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);

            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CountryCreateDto country)
        {
            try
            {
                await _service.CreateAsync(country);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _service.DeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromRoute, Required] int id, [FromBody] CountryEditDto country)
        {
            try
            {
                await _service.UpdateAsync(country, id);
                return Ok();
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(CountryDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchByName([Required] string searchText)
        {
            try
            {
                return Ok(await _service.SearchByName(searchText));

            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDelete([FromRoute, Required] int id)
        {
            try
            {
                await _service.SoftDeleteAsync(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
