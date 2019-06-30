using System;
using System.Collections.Generic;
using shop.Models;
using shop.Repositories;

namespace shop.Services
{
    public class SalesTranService : ISalesTranService
    {
        private IProductRepository _productRepository;
        private ITempTransRepository _tempTransRepository;
        private ISalesRepository _salesRepository;
        private IPaymentRepository _paymentRepository;
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public SalesTranService(
            IProductRepository productRepository,
            ITempTransRepository tempTransRepository,
            ISalesRepository salesRepository,
            IPaymentRepository paymentRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            this._productRepository = productRepository;
            this._tempTransRepository = tempTransRepository;
            this._salesRepository = salesRepository;
            this._paymentRepository = paymentRepository;
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void AddTransaction(int customerId, int productId, int quantity, out string errorMessage)
        {
            var product = this._productRepository.GetById(productId);
            errorMessage = "";
            if (product == null)
            {
                errorMessage = $"Không tìm thấy sản phẩm nào với Id {productId}";
                return;
            }

            decimal price = product.Price;
            decimal total = quantity * price;
            int numOfAlreadyTrans = this._tempTransRepository
                                        .CountTempTransByProductId(productId, customerId);
            if (numOfAlreadyTrans > 0)
            {
                bool isSuccess = this._tempTransRepository
                                     .UpdateIncreaseQuantiyAndPrice(productId, customerId, quantity, total);
                if (!isSuccess)
                {
                    errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                    return;
                }
            }
            else
            {
                var tempTrans = new TempTrans
                {
                    ProductId = productId,
                    Price = total,
                    Quantity = quantity,
                    CustomerId = customerId
                };

                bool isSuccess = this._tempTransRepository.AddTempTran(tempTrans);
                if (!isSuccess)
                {
                    errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                    return;
                }
            }
        }

        public void UpdateLine(int transTempId, int quantity, out string errorMessage)
        {
            errorMessage = "";
            bool isSuccess = this._tempTransRepository.UpdateQuantity(transTempId, quantity);
            if (!isSuccess)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }
        }

        public void DeleteLine(int transTempId, out string errorMessage)
        {
            errorMessage = "";
            bool isSuccess = this._tempTransRepository.DeleteLine(transTempId);
            if (!isSuccess)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }
        }

        public void AddSalesOrder(int customerId, string userId, decimal total,
            decimal discount, decimal payment, decimal amountdue,
            decimal tendered, decimal change, out string errorMessage)
        {

            errorMessage = "";

            var salesTransaction = new Sales
            {
                CustomerId = customerId,
                UserId = userId,
                Discount = discount,
                AmountDue = amountdue,
                Total = total,
                DateAdded = DateTime.Now,
                ModeOfPayment = "cash",
                CashTendered = tendered,
                CashChange = change,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            var tempTrans = this._tempTransRepository.GetAddedSalesLines(customerId);
            foreach (var tempTran in tempTrans)
            {
                salesTransaction.SalesDetails.Add(
                    new SalesDetail
                    {
                        ProductId = tempTran.ProductId,
                        Quantity = tempTran.Quantity,
                        Price = tempTran.Price,
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "admin",
                        UpdatedDate = DateTime.Now
                    }
                );

                this._productRepository.UpdateQuantityAfterSalesTransaction(
                        tempTran.ProductId, tempTran.Quantity);
            }

            this._salesRepository.AddSalesTransaction(salesTransaction);
            int orNo = this._paymentRepository.GetOrNo();
            if (orNo == 0)
            {
                orNo = 1901;
            }
            else
            {
                orNo = orNo + 1;
            }

            var paymentEntity = new Payment
            {
                CustomerId = customerId,
                UserId = userId,
                PaymentAmount = payment,
                PaymentDate = DateTime.Now,
                PaymentFor = DateTime.Now,
                Due = amountdue,
                Status = "paid",
                Sales = salesTransaction,
                OrNo = orNo,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            this._paymentRepository.AddPaymentTransaction(paymentEntity);
            this._tempTransRepository.DeleteAllTransByCustomerTransaction(customerId);
            bool isSuccess = this._unitOfWork.SaveChanges();
            if (isSuccess == false)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }
        }


        public void AddSalesOrderCredit(int customerId, string userId,
            decimal total, out string errorMessage, out int salesId)
        {
            errorMessage = "";
            salesId = 0;
            var salesTransaction = new Sales
            {
                CustomerId = customerId,
                UserId = userId,
                Discount = 0,
                AmountDue = total,
                Total = total,
                DateAdded = DateTime.Now,
                ModeOfPayment = "credit",
                CashTendered = 0,
                CashChange = 0,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now
            };

            var tempTrans = this._tempTransRepository.GetAddedSalesLines(customerId);
            foreach (var tempTran in tempTrans)
            {
                salesTransaction.SalesDetails.Add(
                    new SalesDetail
                    {
                        ProductId = tempTran.ProductId,
                        Quantity = tempTran.Quantity,
                        Price = tempTran.Price,
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "admin",
                        UpdatedDate = DateTime.Now
                    }
                );

                this._productRepository.UpdateQuantityAfterSalesTransaction(
                        tempTran.ProductId, tempTran.Quantity);
            }

            this._salesRepository.AddSalesTransaction(salesTransaction);
            this._customerRepository.UpdateBalanceTransaction(customerId, total, true);
            this._tempTransRepository.DeleteAllTransByCustomerTransaction(customerId);
            bool isSuccess = this._unitOfWork.SaveChanges();
            if (isSuccess == false)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }

            if (salesTransaction.Id != 0)
            {
                salesId = salesTransaction.Id;
            }

        }
        public void CancelOrder(int customerId, out string errorMessage)
        {
            errorMessage = "";
            this._tempTransRepository.DeleteAllTransByCustomerTransaction(customerId);
            bool isSuccess = this._unitOfWork.SaveChanges();
            if (isSuccess == false)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }
        }
    }
}