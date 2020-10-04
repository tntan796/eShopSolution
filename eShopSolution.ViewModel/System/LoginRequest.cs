using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.ViewModel.System
{
    public class LoginRequest
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}
