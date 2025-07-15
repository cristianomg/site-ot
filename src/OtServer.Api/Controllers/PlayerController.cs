using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OtServer.Api.ViewModels;
using OtServer.Domain.Entities;
using OtServer.Domain.Repositories;

namespace OtServer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public PlayerController(IPlayerRepository playerRepository, IMapper mapper, IAccountRepository accountRepository)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
            _accountRepository = accountRepository;
        }
        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var player = _playerRepository.GetByName(name);

            return Ok(_mapper.Map<PlayerInfoViewModel>(player));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var player = _playerRepository.GetById(id);
            return Ok(_mapper.Map<PlayerInfoViewModel>(player));
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] CreatePlayerViewModel viewModel)
        {
            var accountNumber = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Account")?.Value; 

            if (accountNumber == null)
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = _accountRepository.GetAccountByAccountNumber(int.Parse(accountNumber));

            if (account == null)
            {
                return BadRequest("Conta não existe.");
            }

            if (!ValidName(viewModel.Name))
            {
                return BadRequest("O nome contém palavras que não podem ser usadas.");
            }

            var playerExists = _playerRepository.IsPlayer(viewModel.Name);

            if (playerExists)
            {
                return BadRequest("Já existe um personagem com esse nome.");
            }

            var player = new Player(viewModel.Name, viewModel.Sex, (int)viewModel.Vocation);

            account.Players.Add(player);

            _accountRepository.Update(account);
            _accountRepository.SaveChanges();

            return Ok();
        }

        private bool ValidName(string name) 
        {
            var nameLower = name.ToLower();
            var FORBIDEN_NAMES = new List<string>()
            {
                "gm", "god", "guild master", "guildmaster", "game master", "guild house", "guildhouse", "cm", "tutor"
            };

            foreach (var FORBIDEN_NAME in FORBIDEN_NAMES)
            {
                if (nameLower.Contains(FORBIDEN_NAME))
                    return false;
            }

            return true;
        }
    }
}
