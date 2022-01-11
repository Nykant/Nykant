using Microsoft.AspNetCore.DataProtection;
using NykantMVC.Models;

namespace NykantMVC.Services
{
    public class ProtectionService : IProtectionService
    {
        IDataProtector _customerProtector;
        IDataProtector _orderProtector;
        IDataProtector _newsSubProtector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _newsSubProtector = provider.CreateProtector("Nykant.NewsSub.Protect.v1");
            _customerProtector = provider.CreateProtector("Nykant.Customer.Protect.v1");
            _orderProtector = provider.CreateProtector("Nykant.Order.Protect.v1");
        }

        public NewsSub ProtectNewsSub(NewsSub newsSub)
        {
            newsSub.Email = _newsSubProtector.Protect(newsSub.Email);

            return newsSub;
        }

        public NewsSub UnprotectNewsSub(NewsSub newsSub)
        {
            newsSub.Email = _newsSubProtector.Unprotect(newsSub.Email);

            return newsSub;
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
            shippingAddress.Name = _customerProtector.Protect(shippingAddress.Name);
            shippingAddress.Address = _customerProtector.Protect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Protect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Protect(shippingAddress.Country);
            shippingAddress.Postal = _customerProtector.Protect(shippingAddress.Postal);

            return shippingAddress;
        }

        public ShippingAddress UnprotectShippingAddress(ShippingAddress shippingAddress)
        {
            shippingAddress.Name = _customerProtector.Unprotect(shippingAddress.Name);
            shippingAddress.Address = _customerProtector.Unprotect(shippingAddress.Address);
            shippingAddress.City = _customerProtector.Unprotect(shippingAddress.City);
            shippingAddress.Country = _customerProtector.Unprotect(shippingAddress.Country);
            shippingAddress.Postal = _customerProtector.Unprotect(shippingAddress.Postal);

            return shippingAddress;
        }

        public BillingAddress UnprotectBillingAddress(BillingAddress billingAddress)
        {
            billingAddress.Address = _customerProtector.Unprotect(billingAddress.Address);
            billingAddress.City = _customerProtector.Unprotect(billingAddress.City);
            billingAddress.Country = _customerProtector.Unprotect(billingAddress.Country);
            billingAddress.Postal = _customerProtector.Unprotect(billingAddress.Postal);
            billingAddress.Name = _customerProtector.Unprotect(billingAddress.Name);

            return billingAddress;
        }

        public BillingAddress ProtectBillingAddress(BillingAddress billingAddress)
        {
            billingAddress.Address = _customerProtector.Protect(billingAddress.Address);
            billingAddress.City = _customerProtector.Protect(billingAddress.City);
            billingAddress.Country = _customerProtector.Protect(billingAddress.Country);
            billingAddress.Postal = _customerProtector.Protect(billingAddress.Postal);
            billingAddress.Name = _customerProtector.Protect(billingAddress.Name);

            return billingAddress;
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
        public NewsSub ProtectNewsSub(NewsSub newsSub);
        public NewsSub UnprotectNewsSub(NewsSub newsSub);
        public Customer ProtectCustomer(Customer customer);
        public Customer UnprotectCustomer(Customer customer);

        public ShippingAddress ProtectShippingAddress(ShippingAddress shippingAddress);
        public ShippingAddress UnprotectShippingAddress(ShippingAddress shippingAddress);

        public BillingAddress ProtectBillingAddress(BillingAddress billingAddress);
        public BillingAddress UnprotectBillingAddress(BillingAddress billingAddress);
        public Order ProtectOrder(Order order);
        public Order UnprotectOrder(Order order);
    }
}
