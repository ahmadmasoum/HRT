using HRT.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRT.Candidates
{
    public class CreateUpdateCandidateDto
    {
        [Required]
        [StringLength(256)]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int Experience { get; set; }

        [Required]
        public DepartmentType Department { get; set; }

        public byte[] Resume { get; set; }
    }
}
