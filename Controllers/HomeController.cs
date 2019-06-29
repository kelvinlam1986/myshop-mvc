using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using shop.Common;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Home;

namespace shop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IBranchRepository _branchRepository;
        private IMapper _mapper;

        public HomeController(IHttpContextAccessor httpContextAccessor,
            IBranchRepository branchRepository, IMapper mapper)
        {
            this._branchRepository = branchRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            var branchAddress = HttpContext.Session.GetString(
                SessionConstant.BranchAddressSession
            );
            var branchContact = HttpContext.Session.GetString(
                SessionConstant.BranchContactSession
            );

            var branch = new Branch();
            if (string.IsNullOrEmpty(branchAddress) || string.IsNullOrEmpty(branchContact))
            {
                branch = this._branchRepository.GetOne();
                HttpContext.Session.SetString(
                    SessionConstant.BranchNameSession, branch.Name
                );
                HttpContext.Session.SetString(
                    SessionConstant.BranchAddressSession, branch.Address
                );
                HttpContext.Session.SetString(
                    SessionConstant.BranchContactSession, branch.Contact
                );
            }
            else
            {
                branch.Address = branchAddress;
                branch.Contact = branchContact;
            }

            var branchDTO = this._mapper.Map<IndexAboutDTO>(branch);
            var indexViewModel = new IndexViewModel
            {
                IndexAboutDTO = branchDTO
            };

            return View(indexViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult About()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["Message"] = "Your application description page.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Contact()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewData["Message"] = "Your contact page.";
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Error()
        {
            string username = this.HttpContext.Session.GetString(SessionConstant.UserNameSession);
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}