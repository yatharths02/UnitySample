using Entities;
using Entities.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

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

        public LoginViewModel CheckLogin(LoginViewModel login)
        {
            var userInfo = _accountsRepository.Login(login.Username, login.Password) ;

            // Login Successfull
            if (userInfo.Result == 1)
            {
                DataPersister.Current.userModel = userInfo;
                FormsAuthentication.SetAuthCookie(login.Username, login.RememberMe);
            }
            //Setting Status 
            login.Result = userInfo.Result;
            login.ErrorMessage = userInfo.ErrorMessage;
            login.Message = userInfo.Message;

            return login;
        }
    }
}