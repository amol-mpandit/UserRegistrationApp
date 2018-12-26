using System.Net;
using System.Web.Mvc;
using Core;
using Persistance;
using UserRegistrationApp.Models;
using System.Collections.Generic;
using AutoMapper;
using UserRegistrationApp.Validators;
using System.ComponentModel.DataAnnotations;

namespace UserRegistrationApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly UserViewModelValidator _userViewModelValidator;

        public UsersController(UserRepository userRepository, 
                               UserViewModelValidator userViewModelValidator)
        {
            _userRepository = userRepository;
            _userViewModelValidator = userViewModelValidator;
        }

        // GET: Users
        public ActionResult Index()
        {
            var users = _userRepository.GetAllUser();
            var userViewModelList = new List<UserViewModel>();
            foreach (var user in users)
            {
                var userViewModel = Mapper.Map<UserViewModel>(user);
                userViewModelList.Add(userViewModel);
            }
            return View(userViewModelList);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userViewModel = Mapper.Map<UserViewModel>(user);
            return View(userViewModel);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,userName,FirstName,MiddleName,LastName,Email,Phone,Address,Password")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToAdd = Mapper.Map<User>(user);
                _userRepository.Add(userToAdd);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = _userRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userToView = Mapper.Map<UserViewModel>(user);

            return View(userToView);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,userName,FirstName,MiddleName,LastName,Email,Phone,Address,Password")] UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var userToEdit = Mapper.Map<User>(user);
                _userRepository.Update(userToEdit);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _userRepository.Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            var userToDeleteViewModel = Mapper.Map<UserViewModel>(user);
            return View(userToDeleteViewModel);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _userRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
