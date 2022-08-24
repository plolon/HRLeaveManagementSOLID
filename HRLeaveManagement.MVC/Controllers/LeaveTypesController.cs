using HRLeaveManagement.MVC.Contracts;
using HRLeaveManagement.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRLeaveManagement.MVC.Controllers
{
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeService leaveTypeService;

        public LeaveTypesController(ILeaveTypeService leaveTypeService)
        {
            this.leaveTypeService = leaveTypeService;
        }
        // GET: LeaveTypesController
        public async Task<ActionResult> Index()
        {
            var model = await leaveTypeService.GetLeaveTypes();
            return View(model);
        }

        // GET: LeaveTypesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: LeaveTypesController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: LeaveTypesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateLeaveTypeVM leaveType)
        {
            try
            {
                var response = await leaveTypeService.CreateLeaveType(leaveType);
                if (response.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(leaveType);
        }

        // GET: LeaveTypesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }

        // POST: LeaveTypesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, LeaveTypeVM leaveType)
        {
            try
            {
                var response = await leaveTypeService.UpdateLeaveType(id, leaveType);
                if (response.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(leaveType);
        }

        // GET: LeaveTypesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var model = await leaveTypeService.GetLeaveTypeDetails(id);
            return View(model);
        }

        // POST: LeaveTypesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                var response = await leaveTypeService.DeleteLeaveType(id);
                if (response.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ModelState.AddModelError("", response.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return BadRequest();
        }
    }
}
