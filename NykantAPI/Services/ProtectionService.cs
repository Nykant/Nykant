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
        IDataProtector _newsSubProtector;
        IDataProtector _consentProtector;
        IDataProtector _paymentCaptureProtector;
        IDataProtector _invoiceProtector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _newsSubProtector = provider.CreateProtector("Nykant.NewsSub.Protect.ASDdgfasd2343ø4v1");
            _customerProtector = provider.CreateProtector("Nykant.Customer.Protect.ASDfzsæef23ø4234v1");
            _orderProtector = provider.CreateProtector("Nykant.Order.Protect.asASæDdfa2342ø34v1");
            _consentProtector = provider.CreateProtector("Nykant.Consent.Protect.ASDsadfaøs234æ25v1");
            _paymentCaptureProtector = provider.CreateProtector("Nykant.PaymentCapture.Protect.dsaføæsASD2æ34235v1");
            _invoiceProtector = provider.CreateProtector("Nykant.Invoice.Protect.dsafs2342SDFGø4235v123423æADSAFGH");
        }

        public Consent ProtectConsent(Consent consent)
        {
            if (consent.Email != null)
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

        public PaymentCapture ProtectPaymentCapture(PaymentCapture paymentCapture, bool doOrder = true)
        {
            paymentCapture.PaymentIntent_Id = _paymentCaptureProtector.Protect(paymentCapture.PaymentIntent_Id);
            if (paymentCapture.Customer != null)
            {
                paymentCapture.Customer = ProtectCustomer(paymentCapture.Customer);
            }
            if (paymentCapture.Invoice != null)
            {
                paymentCapture.Invoice = ProtectInvoice(paymentCapture.Invoice);
            }
            if (doOrder)
            {
                if (paymentCapture.Orders != null)
                {
                    for (int i = 0; i < paymentCapture.Orders.Count(); i++)
                    {
                        paymentCapture.Orders[i] = ProtectOrder(paymentCapture.Orders[i], false);
                    }
                }
            }


            return paymentCapture;
        }

        public PaymentCapture UnprotectPaymentCapture(PaymentCapture paymentCapture, bool doOrder = true)
        {
            paymentCapture.PaymentIntent_Id = _paymentCaptureProtector.Unprotect(paymentCapture.PaymentIntent_Id);
            if (paymentCapture.Customer != null)
            {
                paymentCapture.Customer = UnprotectCustomer(paymentCapture.Customer);
            }
            if(paymentCapture.Invoice != null)
            {
                paymentCapture.Invoice = UnprotectInvoice(paymentCapture.Invoice);
            }
            if (doOrder)
            {
                if (paymentCapture.Orders != null)
                {
                    for (int i = 0; i < paymentCapture.Orders.Count(); i++)
                    {
                        paymentCapture.Orders[i] = UnprotectOrder(paymentCapture.Orders[i], false);
                    }
                }
            }


            return paymentCapture;
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

            if (customer.ShippingAddress != null)
            {
                customer.ShippingAddress = ProtectShippingAddress(customer.ShippingAddress);
            }

            if (customer.BillingAddress != null)
            {
                customer.BillingAddress = ProtectInvoiceAddress(customer.BillingAddress);
            }

            return customer;
        }



        public Customer UnprotectCustomer(Customer customer)
        {
            customer.Email = _customerProtector.Unprotect(customer.Email);
            customer.Phone = _customerProtector.Unprotect(customer.Phone);

            if (customer.ShippingAddress != null)
            {
                customer.ShippingAddress = UnprotectShippingAddress(customer.ShippingAddress);
            }

            if (customer.BillingAddress != null)
            {
                customer.BillingAddress = UnprotectInvoiceAddress(customer.BillingAddress);
            }

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

        public BillingAddress UnprotectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Unprotect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Unprotect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Unprotect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Unprotect(invoiceAddress.Postal);
            invoiceAddress.Name = _customerProtector.Unprotect(invoiceAddress.Name);

            return invoiceAddress;
        }

        public BillingAddress ProtectInvoiceAddress(BillingAddress invoiceAddress)
        {
            invoiceAddress.Address = _customerProtector.Protect(invoiceAddress.Address);
            invoiceAddress.City = _customerProtector.Protect(invoiceAddress.City);
            invoiceAddress.Country = _customerProtector.Protect(invoiceAddress.Country);
            invoiceAddress.Postal = _customerProtector.Protect(invoiceAddress.Postal);
            invoiceAddress.Name = _customerProtector.Protect(invoiceAddress.Name);

            return invoiceAddress;
        }

        public Order UnprotectOrder(Order order, bool dopaymentCapture = true)
        {
            order.Currency = _orderProtector.Unprotect(order.Currency);
            order.TotalPrice = _orderProtector.Unprotect(order.TotalPrice);
            order.Taxes = _orderProtector.Unprotect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Unprotect(order.TaxLessPrice);

            if (dopaymentCapture)
            {
                if (order.PaymentCapture != null)
                {
                    order.PaymentCapture = UnprotectPaymentCapture(order.PaymentCapture, false);
                }
            }

            return order;
        }

        public Order ProtectOrder(Order order, bool dopaymentCapture = true)
        {
            order.Currency = _orderProtector.Protect(order.Currency);
            order.TotalPrice = _orderProtector.Protect(order.TotalPrice);
            order.Taxes = _orderProtector.Protect(order.Taxes);
            order.TaxLessPrice = _orderProtector.Protect(order.TaxLessPrice);

            if (dopaymentCapture)
            {
                if (order.PaymentCapture != null)
                {
                    order.PaymentCapture = ProtectPaymentCapture(order.PaymentCapture, false);
                }
            }

            return order;
        }

        public Invoice UnprotectInvoice(Invoice invoice)
        {
            invoice.TotalPrice = _invoiceProtector.Unprotect(invoice.TotalPrice);
            invoice.Taxes = _invoiceProtector.Unprotect(invoice.Taxes);
            invoice.TaxLessPrice = _invoiceProtector.Unprotect(invoice.TaxLessPrice);

            return invoice;
        }

        public Invoice ProtectInvoice(Invoice invoice)
        {
            invoice.TotalPrice = _invoiceProtector.Protect(invoice.TotalPrice);
            invoice.Taxes = _invoiceProtector.Protect(invoice.Taxes);
            invoice.TaxLessPrice = _invoiceProtector.Protect(invoice.TaxLessPrice);

            return invoice;
        }
    }

    public interface IProtectionService
    {
        Invoice ProtectInvoice(Invoice invoice);
        Invoice UnprotectInvoice(Invoice invoice);
        PaymentCapture UnprotectPaymentCapture(PaymentCapture paymentCapture, bool doOrder = true);
        PaymentCapture ProtectPaymentCapture(PaymentCapture paymentCapture, bool doOrder = true);
        public Consent ProtectConsent(Consent consent);
        public Consent UnprotectConsent(Consent consent);
        public NewsSub ProtectNewsSub(NewsSub newsSub);
        public NewsSub UnprotectNewsSub(NewsSub newsSub);
        public Customer ProtectCustomer(Customer customerInf);
        public Customer UnprotectCustomer(Customer customerInf);

        public ShippingAddress ProtectShippingAddress(ShippingAddress customerInf);
        public ShippingAddress UnprotectShippingAddress(ShippingAddress customerInf);

        public BillingAddress ProtectInvoiceAddress(BillingAddress customerInf);
        public BillingAddress UnprotectInvoiceAddress(BillingAddress customerInf);
        public Order ProtectOrder(Order order, bool dopaymentCapture = true);
        public Order UnprotectOrder(Order order, bool dopaymentCapture = true);
    }
}
