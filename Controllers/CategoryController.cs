using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Category;

namespace shop.Controllers
{

    [Authorize]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryController(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var categoriesDTO = GetCategories();
            var indexViewModel = new IndexViewModel
            {
                CategoriesGrid = categoriesDTO,
            };
            return View(indexViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var category = this._categoryRepository.GetCategoryById(id);
            var categoryDTO = this._mapper.Map<CategoryDTO>(category);
            return View(categoryDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]

        public IActionResult UpdateCategory(CategoryDTO category)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", category);
            }

            bool isExisting = this._categoryRepository.IsExistingByName(category.Name, category.Id);
            if (isExisting)
            {
                ModelState.AddModelError("", "Tên danh mục này đã tồn tại.");
                return View("Edit", category);
            }

            var categoryDb = this._mapper.Map<Category>(category);
            bool isSuccess = this._categoryRepository.UpdateCategory(categoryDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return RedirectToAction("Index");
            }
        }

        public IEnumerable<CategoryDTO> GetCategories()
        {
            var categories = this._categoryRepository.GetCategories();
            var categoriesDTO = this._mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return categoriesDTO;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                var categoryDb = this._mapper.Map<Category>(category);
                bool isSuccess = this._categoryRepository.DeleteCategory(categoryDb);
                if (isSuccess)
                {
                    TempData["Success"] = "Xoá dữ liệu thành công !";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Fail"] = "Xoá dữ liệu thất bại !";
                    return RedirectToAction("Index");
                }

            }

            TempData["Fail"] = "Xoá dữ liệu thất bại !";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Index(CategoryDTO category)
        {
            var categoriesDTO = GetCategories();
            var indexViewModel = new IndexViewModel
            {
                CategoriesGrid = categoriesDTO,
                InputCategory = category
            };

            if (!ModelState.IsValid)
            {
                return View(indexViewModel);
            }

            bool isExisting = this._categoryRepository.IsExistingByName(category.Name);
            if (isExisting)
            {
                ModelState.AddModelError("", "Tên danh mục này đã tồn tại.");
                return View(indexViewModel);
            }

            var categoryForSave = this._mapper.Map<Category>(category);
            categoryForSave.CreatedBy = "admin";
            categoryForSave.CreatedDate = DateTime.Now;
            categoryForSave.UpdatedBy = "admin";
            categoryForSave.UpdatedDate = DateTime.Now;
            bool isSuccess = this._categoryRepository.InsertCategory(categoryForSave);
            if (isSuccess)
            {
                TempData["Success"] = "Thêm dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Fail";
                return RedirectToAction("Index");
            }
        }
    }
}