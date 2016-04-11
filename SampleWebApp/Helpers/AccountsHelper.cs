using Entities.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApp.Helpers
{
    public class AccountsHelper
    {
        IAccountsRepository _accountsRepository;

        public AccountsHelper(AccountsRepository accountsRepository)
        {
            //UserManager = userManager;
            //SignInManager = signInManager;
            _accountsRepository = accountsRepository;
        }


    }
}