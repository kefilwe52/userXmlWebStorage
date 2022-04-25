using AssessmentOne.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AssessmentOne.Pages.User
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new Model.User User { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _userService.Save(User);
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