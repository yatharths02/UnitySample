using Entities;
using Repository;
using SampleService.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleService.ServiceClasses
{
    public class SampleService : ISampleService
    {
        //private AccountsRepository _accountsRepository;
        //public SampleService(AccountsRepository accountsRepository)
        //{
        //    _accountsRepository = accountsRepository;
        //}


        public UserInfo Login(string username, string password)
        {
            AccountsRepository _accountsRepository = new AccountsRepository();
            return _accountsRepository.Login(username, password);
        }
    }
}
