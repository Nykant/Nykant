using Microsoft.AspNetCore.DataProtection;
using NykantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Services
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

        public Customer ProtectCustomerInf(Customer customer)
        {
            customer.Email = _customerProtector.Protect(customer.Email);
            customer.Phone = _customerProtector.Protect(customer.Phone);

            customer.InvoiceAddress.FirstName = _customerProtector.Protect(customer.InvoiceAddress.FirstName);
            customer.InvoiceAddress.Address = _customerProtector.Protect(customer.InvoiceAddress.Address);
            customer.InvoiceAddress.City = _customerProtector.Protect(customer.InvoiceAddress.City);
            customer.InvoiceAddress.Country = _customerProtector.Protect(customer.InvoiceAddress.Country);
            customer.InvoiceAddress.LastName = _customerProtector.Protect(customer.InvoiceAddress.LastName);
            customer.InvoiceAddress.Postal = _customerProtector.Protect(customer.InvoiceAddress.Postal);

            customer.ShippingAddress.FirstName = _customerProtector.Protect(customer.ShippingAddress.FirstName);
            customer.ShippingAddress.Address = _customerProtector.Protect(customer.ShippingAddress.Address);
            customer.ShippingAddress.City = _customerProtector.Protect(customer.ShippingAddress.City);
            customer.ShippingAddress.Country = _customerProtector.Protect(customer.ShippingAddress.Country);
            customer.ShippingAddress.LastName = _customerProtector.Protect(customer.ShippingAddress.LastName);
            customer.ShippingAddress.Postal = _customerProtector.Protect(customer.ShippingAddress.Postal);
            return customer;
        }

        public Order ProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            return order;
        }

        public Customer UnProtectCustomerInf(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            customer.InvoiceAddress.FirstName = _customerProtector.Unprotect(customer.InvoiceAddress.FirstName);
            customer.InvoiceAddress.Address = _customerProtector.Unprotect(customer.InvoiceAddress.Address);
            customer.InvoiceAddress.City = _customerProtector.Unprotect(customer.InvoiceAddress.City);
            customer.InvoiceAddress.Country = _customerProtector.Unprotect(customer.InvoiceAddress.Country);
            customer.InvoiceAddress.LastName = _customerProtector.Unprotect(customer.InvoiceAddress.LastName);
            customer.InvoiceAddress.Postal = _customerProtector.Unprotect(customer.InvoiceAddress.Postal);

            customer.ShippingAddress.FirstName = _customerProtector.Unprotect(customer.ShippingAddress.FirstName);
            customer.ShippingAddress.Address = _customerProtector.Unprotect(customer.ShippingAddress.Address);
            customer.ShippingAddress.City = _customerProtector.Unprotect(customer.ShippingAddress.City);
            customer.ShippingAddress.Country = _customerProtector.Unprotect(customer.ShippingAddress.Country);
            customer.ShippingAddress.LastName = _customerProtector.Unprotect(customer.ShippingAddress.LastName);
            customer.ShippingAddress.Postal = _customerProtector.Unprotect(customer.ShippingAddress.Postal);
            return customer;
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
        public Customer ProtectCustomerInf(Customer customerInf);
        public Customer UnProtectCustomerInf(Customer customerInf);
        public Order ProtectOrder(Order order);
        public Order UnProtectOrder(Order order);
    }
}
