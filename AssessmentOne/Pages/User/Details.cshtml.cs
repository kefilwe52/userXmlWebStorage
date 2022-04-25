using AssessmentOne.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AssessmentOne.Pages.User
{
    public class DetailsModel : PageModel
    {
        private readonly IUserService _userService;

        public DetailsModel(IUserService userService)
        {
            _userService = userService;
        }

        public new Model.User User { get; set; }

        public IActionResult OnGet(Guid id)
        {
            User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}