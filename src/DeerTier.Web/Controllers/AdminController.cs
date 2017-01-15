﻿using DeerTier.Web.Services;
using DeerTier.Web.Utils;
using System.Web.Mvc;

namespace DeerTier.Web.Controllers
{
    public class AdminController : BaseController
    {
        private readonly LeaderboardService _leaderboardService;

        public AdminController(AccountService accountService, CategoryService categoryService, LeaderboardService leaderboardService)
            : base(accountService, categoryService)
        {
            _leaderboardService = leaderboardService;
        }

        [HttpGet]
        public ActionResult Moderators(string adminKey)
        {
            if (adminKey != ConfigHelper.AdminKey)
            {
                return Content("unauthorized access");
            }
            
            var usernames = AccountService.GetUsernames();
            
            return View(usernames);
        }

        [HttpPost]
        public ActionResult Moderators(string modOrDemod, string username)
        {
            var content = "no action taken";
            
            if (modOrDemod == "mod")
            {
                content = (AccountService.ModUser(username) ? (username + " successfully modded") : ("error modding " + username));
            }
            else if (modOrDemod == "de-mod")
            {
                content = (AccountService.DeModUser(username) ? (username + " successfully de-modded") : ("error de-modding " + username));
            }
            
            return Content(content);
        }

        [HttpGet]
        public ActionResult ScoreDeletionLog(string adminKey)
        {
            if (adminKey != ConfigHelper.AdminKey)
            {
                return Content("unauthorized access");
            }
            
            var deletedRecords = _leaderboardService.GetAllDeletedRecords();
            
            return View(deletedRecords);
        }
    }
}