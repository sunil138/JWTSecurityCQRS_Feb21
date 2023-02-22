using System;
using System.Collections.Generic;

namespace JWTSecurityCQRS_Feb21.Models
{
    public partial class Tuser
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
    }
}
