
using Domain.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Interfaces
{
    public interface IRestServices
    {
        Task<List<AccountsParams>> GetAllAccounts();
        Task<GenericResponse> CreateAccountAsync(List<AccountsParams> accountsParamsInsert);
    }
}
