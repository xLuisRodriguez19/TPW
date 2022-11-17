using System;
using System.Collections.Generic;

namespace SuperShop.Models.Data
{
    public partial class User
    {

        public string Email { get; set; } = null!;
        public bool IsAdmin { get; set; }
    }
}
