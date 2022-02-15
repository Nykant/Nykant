using Microsoft.AspNetCore.DataProtection;
using NykantMVC.Models;

namespace NykantMVC.Services
{
    public class ProtectionService : IProtectionService
    {
        IDataProtector _customerProtector;
        IDataProtector _orderProtector;
        IDataProtector _newsSubProtector;
        IDataProtector _consentProtector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _newsSubProtector = provider.CreateProtector("Nykant.NewsSub.Protect.v1");
            _customerProtector = provider.CreateProtector("Nykant.Customer.Protect.v1");
            _orderProtector = provider.CreateProtector("Nykant.Order.Protect.v1");
            _consentProtector = provider.CreateProtector("Nykant.Consent.Protect.v1");
        }

        public Consent ProtectConsent(Consent consent)
        {
            if(consent.Email != null)
            {
                consent.Email = _consentProtector.Protect(consent.Email);
            }
            if (consent.IPAddress != null)
            {
                consent.IPAddress = _consentProtector.Protect(consent.IPAddress);
            }
            if (consent.Name != null)
            {
                consent.Name = _consentProtector.Protect(consent.Name);
            }
            if (consent.UserId != null)
            {
                consent.UserId = _consentProtector.Protect(consent.UserId);
            }

            return consent;
        }

        public Consent UnprotectConsent(Consent consent)
        {
            if (consent.Email != null)
            {
                consent.Email = _consentProtector.Unprotect(consent.Email);
            }
            if (consent.IPAddress != null)
            {
                consent.IPAddress = _consentProtector.Unprotect(consent.IPAddress);
            }
            if (consent.Name != null)
            {
                consent.Name = _consentProtector.Unprotect(consent.Name);
            }
            if (consent.UserId != null)
            {
                consent.UserId = _consentProtector.Unprotect(consent.UserId);
            }

            return consent;
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

        public Customer UnprotectWholeCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            if (customer.ShippingAddress != null)
            {
                customer.ShippingAddress.Name = _customerProtector.Unprotect(customer.ShippingAddress.Name);
                customer.ShippingAddress.Address = _customerProtector.Unprotect(customer.ShippingAddress.Address);
                customer.ShippingAddress.City = _customerProtector.Unprotect(customer.ShippingAddress.City);
                customer.ShippingAddress.Country = _customerProtector.Unprotect(customer.ShippingAddress.Country);
                customer.ShippingAddress.Postal = _customerProtector.Unprotect(customer.ShippingAddress.Postal);
            }


            if (customer.BillingAddress != null)
            {
                customer.BillingAddress.Address = _customerProtector.Unprotect(customer.BillingAddress.Address);
                customer.BillingAddress.City = _customerProtector.Unprotect(customer.BillingAddress.City);
                customer.BillingAddress.Country = _customerProtector.Unprotect(customer.BillingAddress.Country);
                customer.BillingAddress.Postal = _customerProtector.Unprotect(customer.BillingAddress.Postal);
                customer.BillingAddress.Name = _customerProtector.Unprotect(customer.BillingAddress.Name);
            }


            return customer;
        }

        public Customer ProtectWholeCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Protect(customer.Email);
            customer.Phone = _customerProtector.Protect(customer.Phone);

            if (customer.ShippingAddress != null)
            {
                customer.ShippingAddress.Name = _customerProtector.Protect(customer.ShippingAddress.Name);
                customer.ShippingAddress.Address = _customerProtector.Protect(customer.ShippingAddress.Address);
                customer.ShippingAddress.City = _customerProtector.Protect(customer.ShippingAddress.City);
                customer.ShippingAddress.Country = _customerProtector.Protect(customer.ShippingAddress.Country);
                customer.ShippingAddress.Postal = _customerProtector.Protect(customer.ShippingAddress.Postal);
            }


            if(customer.BillingAddress != null)
            {
                customer.BillingAddress.Address = _customerProtector.Protect(customer.BillingAddress.Address);
                customer.BillingAddress.City = _customerProtector.Protect(customer.BillingAddress.City);
                customer.BillingAddress.Country = _customerProtector.Protect(customer.BillingAddress.Country);
                customer.BillingAddress.Postal = _customerProtector.Protect(customer.BillingAddress.Postal);
                customer.BillingAddress.Name = _customerProtector.Protect(customer.BillingAddress.Name);
            }


            return customer;
        }

        public Order ProtectWholeOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            order.Taxes = _orderProtector.Protect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Protect(order.TaxLessPrice);

            order.Customer.Email = _customerProtector.Protect(order.Customer.Email);
            order.Customer.Phone = _customerProtector.Protect(order.Customer.Phone);

            if(order.Customer.ShippingAddress != null)
            {
                order.Customer.ShippingAddress.Name = _customerProtector.Protect(order.Customer.ShippingAddress.Name);
                order.Customer.ShippingAddress.Address = _customerProtector.Protect(order.Customer.ShippingAddress.Address);
                order.Customer.ShippingAddress.City = _customerProtector.Protect(order.Customer.ShippingAddress.City);
                order.Customer.ShippingAddress.Country = _customerProtector.Protect(order.Customer.ShippingAddress.Country);
                order.Customer.ShippingAddress.Postal = _customerProtector.Protect(order.Customer.ShippingAddress.Postal);
            } 

            if(order.Customer.BillingAddress != null)
            {
                order.Customer.BillingAddress.Address = _customerProtector.Protect(order.Customer.BillingAddress.Address);
                order.Customer.BillingAddress.City = _customerProtector.Protect(order.Customer.BillingAddress.City);
                order.Customer.BillingAddress.Country = _customerProtector.Protect(order.Customer.BillingAddress.Country);
                order.Customer.BillingAddress.Postal = _customerProtector.Protect(order.Customer.BillingAddress.Postal);
                order.Customer.BillingAddress.Name = _customerProtector.Protect(order.Customer.BillingAddress.Name);
            }

            return order;
        }

        public Order UnprotectWholeOrder(Order order)
        {
            order.Currency = _orderProtector.Unprotect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Unprotect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Unprotect(order.TotalPrice);
            order.Taxes = _orderProtector.Unprotect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Unprotect(order.TaxLessPrice);

            order.Customer.Email = _customerProtector.Unprotect(order.Customer.Email);
            order.Customer.Phone = _customerProtector.Unprotect(order.Customer.Phone);

            if (order.Customer.ShippingAddress != null)
            {
                order.Customer.ShippingAddress.Name = _customerProtector.Unprotect(order.Customer.ShippingAddress.Name);
                order.Customer.ShippingAddress.Address = _customerProtector.Unprotect(order.Customer.ShippingAddress.Address);
                order.Customer.ShippingAddress.City = _customerProtector.Unprotect(order.Customer.ShippingAddress.City);
                order.Customer.ShippingAddress.Country = _customerProtector.Unprotect(order.Customer.ShippingAddress.Country);
                order.Customer.ShippingAddress.Postal = _customerProtector.Unprotect(order.Customer.ShippingAddress.Postal);
            }


            if(order.Customer.BillingAddress != null)
            {
                order.Customer.BillingAddress.Address = _customerProtector.Unprotect(order.Customer.BillingAddress.Address);
                order.Customer.BillingAddress.City = _customerProtector.Unprotect(order.Customer.BillingAddress.City);
                order.Customer.BillingAddress.Country = _customerProtector.Unprotect(order.Customer.BillingAddress.Country);
                order.Customer.BillingAddress.Postal = _customerProtector.Unprotect(order.Customer.BillingAddress.Postal);
                order.Customer.BillingAddress.Name = _customerProtector.Unprotect(order.Customer.BillingAddress.Name);
            }


            return order;
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
            order.Taxes = _orderProtector.Protect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Protect(order.TaxLessPrice);
            return order;
        }

        public Order ProtectOrder(Order order)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.PaymentIntent_Id = _orderProtector.Protect(order.PaymentIntent_Id);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            order.Taxes = _orderProtector.Protect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Protect(order.TaxLessPrice);
            return order;
        }
    }

    public interface IProtectionService
    {
        public Consent ProtectConsent(Consent consent);
        public Consent UnprotectConsent(Consent consent);
        public NewsSub ProtectNewsSub(NewsSub newsSub);
        public NewsSub UnprotectNewsSub(NewsSub newsSub);
        public Customer ProtectCustomer(Customer customer);
        public Customer UnprotectCustomer(Customer customer);
        public Customer UnprotectWholeCustomer(Customer customer);
            public Customer ProtectWholeCustomer(Customer customer);
        public Order UnprotectWholeOrder(Order order);
        public Order ProtectWholeOrder(Order order);

        public ShippingAddress ProtectShippingAddress(ShippingAddress shippingAddress);
        public ShippingAddress UnprotectShippingAddress(ShippingAddress shippingAddress);

        public BillingAddress ProtectBillingAddress(BillingAddress billingAddress);
        public BillingAddress UnprotectBillingAddress(BillingAddress billingAddress);
        public Order ProtectOrder(Order order);
        public Order UnprotectOrder(Order order);
    }
}
