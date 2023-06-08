using Common.Utils.Constant;
using Common.Utils.Resources;
using Domain.DTO.Account;
using Domain.DTO;
using Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class AccountController : Controller
    {

        #region Attributes
        private readonly IRestServices _restServices;
        #endregion
        #region Builder
        public AccountController(IRestServices restServices)
        {
            _restServices = restServices;
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public async Task<IActionResult> CreatePost(AccountsParams accountsParamsInsert)
        {
            List<AccountsParams> accountsParams = new List<AccountsParams>();
            accountsParams.Add(accountsParamsInsert);
            ResponseDto reponse = new ResponseDto();
            if (ModelState.IsValid)
            {
                var result = await _restServices.CreateAccountAsync(accountsParams);
                if (result.Status == 200)
                {
                    TempData[Const.EXITOSO] = result.Title;
                    return RedirectToAction(nameof(Index));
                }
            }
            TempData[Const.ERROR] = GeneralMessages.ErrorCreateAccount;
            return View(accountsParamsInsert);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var listAccounts = await _restServices.GetAllAccounts();
            ResponseDto result = new ResponseDto()
            {
                IsSuccess = true,
                Result = listAccounts,
                Message = string.Empty
            };
            return Ok(result);
        }
    }
}
