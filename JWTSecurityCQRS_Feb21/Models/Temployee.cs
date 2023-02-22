using System;
using System.Collections.Generic;

namespace JWTSecurityCQRS_Feb21.Models
{
    public partial class Temployee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public int? EmployeeSalary { get; set; }
    }
}
