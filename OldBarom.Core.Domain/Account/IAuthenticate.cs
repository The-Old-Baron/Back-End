﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldBarom.Core.Domain.Account
{
    public interface IAuthenticate
    {
        Task<bool> Authenticate(string username, string password);
        Task<bool> RegisterUser(string username, string password);
        Task Logout();

    }
}
