using Microsoft.AspNetCore.DataProtection;
using NykantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantMVC.Services
{
    public class ProtectionService : IProtectionService
    {
        IDataProtector _customerProtector;
        IDataProtector _orderProtector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _customerProtector = provider.CreateProtector("Nykant.Customer.Protect.v1");
            _orderProtector = provider.CreateProtector("Nykant.Order.Protect.v1");
        }

        public CustomerInf ProtectCustomerInf(CustomerInf customerInf)
        {
            customerInf.Email = _customerProtector.Protect(customerInf.Email);
            customerInf.FirstName = _customerProtector.Protect(customerInf.FirstName);
            customerInf.Address1 = _customerProtector.Protect(customerInf.Address1);
            if (customerInf.Address2 != null)
            {
                customerInf.Address2 = _customerProtector.Protect(customerInf.Address2);
            }
            customerInf.City = _customerProtector.Protect(customerInf.City);
            customerInf.Country = _customerProtector.Protect(customerInf.Country);
            customerInf.LastName = _customerProtector.Protect(customerInf.LastName);
            customerInf.Phone = _customerProtector.Protect(customerInf.Phone);
            customerInf.Postal = _customerProtector.Protect(customerInf.Postal);
            return customerInf;
        }

        public Order ProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            return order;
        }

        public CustomerInf UnProtectCustomerInf(CustomerInf customerInf)
        {
            customerInf.Email = _customerProtector.Unprotect(customerInf.Email);
            customerInf.FirstName = _customerProtector.Unprotect(customerInf.FirstName);
            customerInf.Address1 = _customerProtector.Unprotect(customerInf.Address1);
            if (customerInf.Address2 != null)
            {
                customerInf.Address2 = _customerProtector.Unprotect(customerInf.Address2);
            }
            customerInf.City = _customerProtector.Unprotect(customerInf.City);
            customerInf.Country = _customerProtector.Unprotect(customerInf.Country);
            customerInf.LastName = _customerProtector.Unprotect(customerInf.LastName);
            customerInf.Phone = _customerProtector.Unprotect(customerInf.Phone);
            customerInf.Postal = _customerProtector.Unprotect(customerInf.Postal);
            return customerInf;
        }

        public Order UnProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Unprotect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Unprotect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Unprotect(order.TotalPrice);
            return order;
        }
    }

    public interface IProtectionService
    {
        public CustomerInf ProtectCustomerInf(CustomerInf customerInf);
        public CustomerInf UnProtectCustomerInf(CustomerInf customerInf);
        public Order ProtectOrder(Order order);
        public Order UnProtectOrder(Order order);
    }
}
