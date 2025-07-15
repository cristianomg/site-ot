using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtServer.Api.ViewModels;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;
using OtServer.Domain.Services;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(IAccountRepository accountRepository, ITokenService tokenService, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginViewModel login)
        {
            if (login == null || login.Account == null || login.Password == null)

            {
                return BadRequest();
            }


            var account = _accountRepository.GetAccountByAccountNumber(login.Account.Value);

            if (account == null)
            {
                return Unauthorized();
            }

            if (login.Password != account.Password)
            {
                return Unauthorized();
            }

            var role = account.Players.Any(x => x.Access > 0) ? "STAFF" : "PLAYER";


            var token = _tokenService.GenerateToken(account.AccountNumber.ToString(), account.RealName, role);

            return Ok(new LoginResponseViewModel
            {
                Account = account.AccountNumber,
                Token = token
            });
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateAccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var accountExists = _accountRepository.HasAccountByNumber(viewModel.Account);

            if (accountExists)
            {
                return BadRequest("Já existe uma conta com essa account.");
            }

            var accountEmailExists = _accountRepository.HasAccountByEmail(viewModel.Email);

            if (accountEmailExists)
            {
                return BadRequest("Já existe uma conta com esse email.");
            }

            var account = new Account(viewModel.Account, viewModel.Password, viewModel.Email, viewModel.RealName, viewModel.Location);

            _accountRepository.Add(account);

            var result = _accountRepository.SaveChanges();

            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest("Erro ao criar conta.");
            }
        }
        [HttpGet("{accountNumber}")]
        [Authorize]
        public IActionResult GetByAccount(int accountNumber)
        {
            var currentAccount = HttpContext.User.Claims.FirstOrDefault(x=>x.Type == "Account")?.Value;

            if(accountNumber.ToString() != currentAccount)
            {
                return Forbid();
            }
            
            var account = _accountRepository.GetAccountByAccountNumber(accountNumber);

            var accountMapped = _mapper.Map<AccountInfoViewModel>(account);

            return Ok(accountMapped);
        }
    }
}
