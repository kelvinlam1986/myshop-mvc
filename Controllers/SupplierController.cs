using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Supplier;

namespace shop.Controllers
{
    public class SupplierController : Controller
    {
        private ISupplierRepository _supplierRepository;
        private IMapper _mapper;

        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this._supplierRepository = supplierRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var suppliers = this._supplierRepository.GetSuppliers();
            var suppliersDTO =
                this._mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierDTO>>(suppliers);
            return View(suppliersDTO);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult AddSupplier(SupplierDTO supplier)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNew", supplier);
            }

            bool isExisting = this._supplierRepository.IsExistingSupplier(supplier.Name, supplier.Id);
            if (isExisting)
            {
                ModelState.AddModelError("", "Tên nhà cung cấp đã tồn tại.");
                return View("AddNew", supplier);
            }

            var supplierInDb = this._mapper.Map<Supplier>(supplier);
            supplierInDb.CreatedBy = "admin";
            supplierInDb.CreatedDate = DateTime.Now;
            supplierInDb.UpdatedBy = "admin";
            supplierInDb.UpdatedDate = DateTime.Now;

            bool isSuccess = this._supplierRepository.AddSupplier(supplierInDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return View("AddNew", supplier);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var supplier = this._supplierRepository.GetById(id);
            var supplierDTO = this._mapper.Map<SupplierDTO>(supplier);
            return View(supplierDTO);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateSupplier(SupplierDTO supplier)
        {
            if (!ModelState.IsValid)
            {
                return View("AddNew", supplier);
            }

            bool isExisting = this._supplierRepository.IsExistingSupplier(supplier.Name, supplier.Id);
            if (isExisting)
            {
                ModelState.AddModelError("", "Tên nhà cung cấp đã tồn tại.");
                return View("AddNew", supplier);
            }

            var supplierInDb = this._mapper.Map<Supplier>(supplier);
            supplierInDb.UpdatedBy = "admin";
            supplierInDb.UpdatedDate = DateTime.Now;

            bool isSuccess = this._supplierRepository.UpdateSupplier(supplierInDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return View("AddNew", supplier);
            }

        }
    }
}