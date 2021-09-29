using Microsoft.AspNetCore.DataProtection;
using NykantMVC.Models;

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

        public Customer ProtectCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Protect(customer.Email);
            customer.Phone = _customerProtector.Protect(customer.Phone);

            return customer;
        }

        public Customer UnprotectCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            return customer;
        }

        public ShippingAddress ProtectShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.FirstName = _customerProtector.Protect(shippingAddress.FirstName);
            shippingAddress.Address = _customerProtector.Protect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Protect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Protect(shippingAddress.Country);
            shippingAddress.LastName = _customerProtector.Protect(shippingAddress.LastName);
            shippingAddress.Postal = _customerProtector.Protect(shippingAddress.Postal);

            return shippingAddress;
        }

        public ShippingAddress UnprotectShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.FirstName = _customerProtector.Unprotect(shippingAddress.FirstName);
            shippingAddress.Address = _customerProtector.Unprotect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Unprotect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Unprotect(shippingAddress.Country);
            shippingAddress.LastName = _customerProtector.Unprotect(shippingAddress.LastName);
            shippingAddress.Postal = _customerProtector.Unprotect(shippingAddress.Postal);

            return shippingAddress;
        }

        public BillingAddress UnprotectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Unprotect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Unprotect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Unprotect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Unprotect(invoiceAddress.Postal);
            invoiceAddress.FirstName = _customerProtector.Unprotect(invoiceAddress.FirstName);
            invoiceAddress.LastName = _customerProtector.Unprotect(invoiceAddress.LastName);

            return invoiceAddress;
        }

        public BillingAddress ProtectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Protect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Protect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Protect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Protect(invoiceAddress.Postal);
            invoiceAddress.FirstName = _customerProtector.Protect(invoiceAddress.FirstName);
            invoiceAddress.LastName = _customerProtector.Protect(invoiceAddress.LastName);

            return invoiceAddress;
        }

        public Order UnprotectOrder(Order order)
        {
            order.Currency = _orderProtector.Unprotect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Unprotect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Unprotect(order.TotalPrice);
            return order;
        }

        public Order ProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            return order;
        }
    }

    public interface IProtectionService
    {
        public Customer ProtectCustomer(Customer customerInf);
        public Customer UnprotectCustomer(Customer customerInf);

        public ShippingAddress ProtectShippingAddress(ShippingAddress customerInf);
        public ShippingAddress UnprotectShippingAddress(ShippingAddress customerInf);

        public BillingAddress ProtectInvoiceAddress(BillingAddress customerInf);
        public BillingAddress UnprotectInvoiceAddress(BillingAddress customerInf);
        public Order ProtectOrder(Order order);
        public Order UnprotectOrder(Order order);
    }
}
