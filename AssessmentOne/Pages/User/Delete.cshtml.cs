using AssessmentOne.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace AssessmentOne.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
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

        public IActionResult OnPost(Guid id)
        {
            User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Delete(User.Id);

            return RedirectToPage("./Index");
        }
    }
}