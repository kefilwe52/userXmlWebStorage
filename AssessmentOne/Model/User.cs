using System;
using System.ComponentModel.DataAnnotations;

namespace AssessmentOne.Model
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string CellNumber { get; set; }
    }
}