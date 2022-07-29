using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentsApi.Dtos
{
    public class IdentificationDto
    {
        public int Id { get; set; }
        public DateTime IssueDatate { get; set; }
        public int StudentId { get; set; }
    }
}