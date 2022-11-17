using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperShop.Business.Suggestions.Services;
using Microsoft.AspNetCore.Authorization;

namespace SuperShop.Business.Suggestions
{
    public class SuggestionsController : ControllerBase
    {
        private readonly SuggestionsService _sugenstionService;

        public SuggestionsController(SuggestionsService sugenstionService)
        {
            _sugenstionService = sugenstionService;
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> AddSuggestion([FromBody] SuggestionsRequestDto shippingRequestDto)
        {
            return Ok(await _sugenstionService.AddSuggestions(shippingRequestDto));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public async Task<IActionResult> GetSugestion()
        {
            return Ok(await _sugenstionService.GetSuggestions());
        }
    }
}