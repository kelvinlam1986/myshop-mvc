using System;
using shop.Models;
using shop.Repositories;

namespace shop.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentRepository _paymentRepository;
        private ITermRepository _termRepository;
        private ICustomerRepository _customerRepository;
        private IUnitOfWork _unitOfWork;

        public PaymentService(
            IPaymentRepository paymentRepository,
            ITermRepository termRepository,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            this._paymentRepository = paymentRepository;
            this._termRepository = termRepository;
            this._customerRepository = customerRepository;
            this._unitOfWork = unitOfWork;
        }

        public void PerformPayment(
            int customerId,
            string userId,
            int salesId,
            string terms,
            decimal grandTotal,
            decimal down,
            int payableFor,
            decimal interest,
            out string errorMessage)
        {
            errorMessage = "";
            decimal balance = grandTotal - down;
            decimal due = 0;
            int orNo = this._paymentRepository.GetOrNoCredit();
            DateTime dueDueTerm = DateTime.Now.AddMonths(payableFor);
            if (orNo == 0)
            {
                orNo = 3151;
            }
            else
            {
                orNo = orNo + 1;
            }

            if (terms == "monthly")
            {
                due = balance / payableFor;
                for (int i = 1; i <= payableFor; i++)
                {
                    DateTime dueDate = DateTime.Now.AddMonths(i);
                    this._paymentRepository.AddPaymentTransaction(new Payment
                    {
                        CustomerId = customerId,
                        PaymentFor = dueDate,
                        Due = due,
                        Interest = 0,
                        PaymentAmount = 0,
                        UserId = userId,
                        Remaining = due,
                        SalesId = salesId,
                        Status = "unpaid",
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "admin",
                        UpdatedDate = DateTime.Now,
                    });
                }
            }
            else if (terms == "daily")
            {
                due = balance / payableFor / 30;
                int spanDays = payableFor * 30;
                for (int i = 1; i <= spanDays; i++)
                {
                    DateTime dueDate = DateTime.Now.AddDays(i);
                    this._paymentRepository.AddPaymentTransaction(new Payment
                    {
                        CustomerId = customerId,
                        PaymentFor = dueDate,
                        Due = due,
                        Interest = 0,
                        PaymentAmount = 0,
                        UserId = userId,
                        Remaining = due,
                        SalesId = salesId,
                        Status = "unpaid",
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "admin",
                        UpdatedDate = DateTime.Now,
                    });
                }
            }
            else
            {
                due = balance / payableFor / 4;
                int spanWeek = payableFor * 4;
                for (int i = 1; i <= spanWeek; i++)
                {
                    DateTime dueDate = DateTime.Now.AddDays(spanWeek * 7);
                    this._paymentRepository.AddPaymentTransaction(new Payment
                    {
                        CustomerId = customerId,
                        PaymentFor = dueDate,
                        Due = due,
                        Interest = 0,
                        PaymentAmount = 0,
                        UserId = userId,
                        Remaining = due,
                        SalesId = salesId,
                        Status = "unpaid",
                        CreatedBy = "admin",
                        CreatedDate = DateTime.Now,
                        UpdatedBy = "admin",
                        UpdatedDate = DateTime.Now,
                    });
                }
            }

            this._termRepository.AddTermTransaction(new Term
            {
                PayableFor = payableFor.ToString(),
                TermName = terms,
                Due = due,
                PaymentStart = DateTime.Now,
                Down = down,
                DueDate = dueDueTerm,
                Interest = interest,
                SalesId = salesId,
                Status = "unpaid",
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now,
            });

            this._customerRepository.UpdateBalanceTransaction(customerId, balance, false);
            this._paymentRepository.AddPaymentTransaction(new Payment
            {
                CustomerId = customerId,
                PaymentAmount = down,
                PaymentDate = DateTime.Now,
                UserId = userId,
                PaymentFor = DateTime.Now,
                Due = down,
                Status = "paid",
                SalesId = salesId,
                OrNo = orNo,
                CreatedBy = "admin",
                CreatedDate = DateTime.Now,
                UpdatedBy = "admin",
                UpdatedDate = DateTime.Now,
            });

            bool isSuccess = this._unitOfWork.SaveChanges();
            if (isSuccess == false)
            {
                errorMessage = "Có lỗi trong quá trình cập nhật dữ liệu.";
                return;
            }
        }
    }
}