using AssessmentOne.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AssessmentOne.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public new IList<Model.User> User { get; set; }

        public void OnGet()
        {
            User = _userService.GetAll().ToList();
        }
    }
}