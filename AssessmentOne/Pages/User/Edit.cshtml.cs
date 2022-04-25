using AssessmentOne.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AssessmentOne.Pages.User
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty] public new Model.User User { get; set; }

        [BindProperty] public string ErrorMessage { get; set; }

        public IActionResult OnGet(Guid id)
        {
            User = _userService.Get(id);

            if (User == null) return NotFound();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            try
            {
                _userService.Update(User);
            }
            catch (ArgumentException e)
            {
                ErrorMessage = e.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}