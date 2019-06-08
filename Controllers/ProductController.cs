using System;
using System.IO;
using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using shop.Models;
using shop.Repositories;
using shop.ViewModels.Product;

namespace shop.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;
        private ISupplierRepository _supplierRepository;
        private ICategoryRepository _categoryRepository;
        private IHostingEnvironment _env;

        private IMapper _mapper;

        public ProductController(
            IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            ICategoryRepository categoryRepository,
            IHostingEnvironment env,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._supplierRepository = supplierRepository;
            this._categoryRepository = categoryRepository;
            this._mapper = mapper;
            this._env = env;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var productsDTO = this._productRepository.GetProductsView();
            return View(productsDTO);
        }

        [HttpGet]
        [Authorize]
        public IActionResult AddNew()
        {
            var suppliers = this._supplierRepository.GetSuppliers();
            var categories = this._categoryRepository.GetCategories();
            ViewData["Suppliers"] = suppliers;
            ViewData["Categories"] = categories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult AddProduct(NewProductDTO newProduct)
        {
            var suppliers = this._supplierRepository.GetSuppliers();
            var categories = this._categoryRepository.GetCategories();
            ViewData["Suppliers"] = suppliers;
            ViewData["Categories"] = categories;

            if (!ModelState.IsValid)
            {
                return View("AddNew", newProduct);
            }

            bool isExisting = this._productRepository.IsExistingProductCodeOrName(
                newProduct.Serial, newProduct.Name, newProduct.Id
            );

            if (isExisting)
            {
                ModelState.AddModelError("", "Mã sản phẩm hoặc tên sản phẩm đã tồn tại.");
                return View("AddNew", newProduct);
            }

            var productInDb = this._mapper.Map<Product>(newProduct);
            bool uploadFileOk = false;
            string fileName = "";
            if (newProduct.PictureFile == null || newProduct.PictureFile.FileName == "")
            {
                productInDb.Picture = "default.gif";
                uploadFileOk = true;
            }
            else
            {
                fileName = WebUtility.HtmlEncode(
                    Path.GetFileName(newProduct.PictureFile.FileName));

                if ((newProduct.PictureFile.ContentType.ToLower() != "image/jpg") &&
                    (newProduct.PictureFile.ContentType.ToLower() != "image/jpeg") &&
                    (newProduct.PictureFile.ContentType.ToLower() != "image/pjpeg") &&
                    (newProduct.PictureFile.ContentType.ToLower() != "image/gif") &&
                    (newProduct.PictureFile.ContentType.ToLower() != "image/x-png") &&
                    (newProduct.PictureFile.ContentType.ToLower() != "image/png"))
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) không phải file ảnh,.");
                    return View("AddNew", newProduct);
                }

                if (newProduct.PictureFile.Length == 0)
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) rỗng.");
                    return View("AddNew", newProduct);
                }
                else if (newProduct.PictureFile.Length > 1048576)
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) vượt quá 1 MB.");
                    return View("AddNew", newProduct);
                }

                var filePath = Path.Combine(this._env.WebRootPath, "uploads", fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    newProduct.PictureFile.CopyTo(fs);
                }

                uploadFileOk = true;
            }

            if (uploadFileOk == false)
            {
                TempData["Fail"] = "Có lỗi trong quá trình upload file. !";
                return View("AddNew", newProduct);
            }

            if (string.IsNullOrEmpty(productInDb.Picture))
            {
                productInDb.Picture = fileName;
            }

            productInDb.CreatedBy = "admin";
            productInDb.CreatedDate = DateTime.Now;
            productInDb.UpdatedBy = "admin";
            productInDb.UpdatedDate = DateTime.Now;

            bool isSuccess = this._productRepository.AddProduct(productInDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return View("AddNew", newProduct);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var suppliers = this._supplierRepository.GetSuppliers();
            var categories = this._categoryRepository.GetCategories();
            ViewData["Suppliers"] = suppliers;
            ViewData["Categories"] = categories;
            var product = this._productRepository.GetById(id);
            var productDTO = this._mapper.Map<EditProductDTO>(product);
            return View(productDTO);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(EditProductDTO product)
        {
            var suppliers = this._supplierRepository.GetSuppliers();
            var categories = this._categoryRepository.GetCategories();
            ViewData["Suppliers"] = suppliers;
            ViewData["Categories"] = categories;

            if (!ModelState.IsValid)
            {
                return View("Edit", product);
            }

            bool isExisting = this._productRepository.IsExistingProductCodeOrName(
                product.Serial, product.Name, product.Id
            );

            if (isExisting)
            {
                ModelState.AddModelError("", "Mã sản phẩm hoặc tên sản phẩm đã tồn tại.");
                return View("Edit", product);
            }

            var productInDb = this._mapper.Map<Product>(product);
            bool uploadFileOk = false;
            string fileName = "";
            if (product.PictureFile == null || product.PictureFile.FileName == "")
            {
                productInDb.Picture = "default.gif";
                uploadFileOk = true;
            }
            else
            {
                fileName = WebUtility.HtmlEncode(
                    Path.GetFileName(product.PictureFile.FileName));

                if ((product.PictureFile.ContentType.ToLower() != "image/jpg") &&
                    (product.PictureFile.ContentType.ToLower() != "image/jpeg") &&
                    (product.PictureFile.ContentType.ToLower() != "image/pjpeg") &&
                    (product.PictureFile.ContentType.ToLower() != "image/gif") &&
                    (product.PictureFile.ContentType.ToLower() != "image/x-png") &&
                    (product.PictureFile.ContentType.ToLower() != "image/png"))
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) không phải file ảnh,.");
                    return View("Edit", product);
                }

                if (product.PictureFile.Length == 0)
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) rỗng.");
                    return View("Edit", product);
                }
                else if (product.PictureFile.Length > 1048576)
                {
                    ModelState.AddModelError("",
                        $"File upload ({fileName}) vượt quá 1 MB.");
                    return View("Edit", product);
                }

                var filePath = Path.Combine(this._env.WebRootPath, "uploads", fileName);
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    product.PictureFile.CopyTo(fs);
                }

                uploadFileOk = true;
            }

            if (uploadFileOk == false)
            {
                TempData["Fail"] = "Có lỗi trong quá trình upload file. !";
                return View("Edit", product);
            }

            if (string.IsNullOrEmpty(productInDb.Picture))
            {
                productInDb.Picture = fileName;
            }

            productInDb.UpdatedBy = "admin";
            productInDb.UpdatedDate = DateTime.Now;

            bool isSuccess = this._productRepository.UpdateProduct(productInDb);
            if (isSuccess)
            {
                TempData["Success"] = "Cập nhật dữ liệu thành công !";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Fail"] = "Cập nhật dữ liệu thất bại !";
                return View("Edit", product);
            }
        }
    }
}