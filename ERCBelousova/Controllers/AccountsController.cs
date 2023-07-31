using ERCBelousova.Data;
using ERCBelousova.DataBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERCBelousova.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly AuthDbContext _dbContext;
        private static List<Account> _accounts = new List<Account>();

        [Route("[controller]")]
        public class ErrorController : Controller
        {
            [HttpGet("{statusCode}")]
            public IActionResult Error(int statusCode)
            {
                this.Response.StatusCode = statusCode;
                return this.View(statusCode);
            }
        }

        public AccountsController(AuthDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        // GET: api/accounts
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _dbContext.Accounts.ToListAsync();
            return Ok(_accounts);
        }

        public async Task<IActionResult> ListUsers()
        {
            return View(await _dbContext.Accounts.ToListAsync());
        }

        // GET: api/accounts/{id}
        [HttpGet("{id}")]
        public IActionResult GetAccountById(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        // POST: api/accounts
        [HttpPost]
        public IActionResult CreateAccount(Account account)
        {
            if (string.IsNullOrWhiteSpace(account.Number))
            {
                ModelState.AddModelError("Number", "Number is required.");
            }

            if (_accounts.Any(a => a.Number == account.Number))
            {
                ModelState.AddModelError("Number", "Number must be unique.");
            }

            if (ModelState.IsValid)
            {
                account.Id = _accounts.Count + 1;
                _accounts.Add(account);
                return CreatedAtAction(nameof(GetAccountById), new { id = account.Id }, account);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/accounts/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateAccount(int id, Account account)
        {
            var existingAccount = _accounts.FirstOrDefault(a => a.Id == id);
            if (existingAccount == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(account.Number))
            {
                ModelState.AddModelError("Number", "Number is required.");
            }

            if (_accounts.Any(a => a.Number == account.Number && a.Id != id))
            {
                ModelState.AddModelError("Number", "Number must be unique.");
            }

            if (ModelState.IsValid)
            {
                existingAccount.Number = account.Number;
                existingAccount.StartDate = account.StartDate;
                existingAccount.EndDate = account.EndDate;
                existingAccount.Address = account.Address;
                existingAccount.Area = account.Area;
                existingAccount.Residents = account.Residents;
                return NoContent();
            }

            return BadRequest(ModelState);
        }

        // DELETE: api/accounts/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var account = _accounts.FirstOrDefault(a => a.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            _accounts.Remove(account);
            return NoContent();
        }
    }
}
