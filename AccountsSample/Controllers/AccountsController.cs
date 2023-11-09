using AccountsSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccountsSample.Controllers;

public class AccountsController : Controller
{
    private readonly AccountRepo _repo;

    public AccountsController(AccountRepo repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        return View(_repo.GetAccounts());
    }

    public IActionResult GetEditForm(int id)
    {
        var account = _repo.GetAccount(id);
        return PartialView("_EditAccountPartial", account);
    }

    [HttpPost]
    public IActionResult SaveEdit(AccountModel account)
    {
        _repo.UpdateAccount(account.Id, account.Name);
        return PartialView("_AccountPartial", account);
    }
}