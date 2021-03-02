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
        IDataProtector _protector;
        public ProtectionService(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Nykant.Customer.Protect.v1");
        }

        public CustomerInf ProtectCustomerInf(CustomerInf customerInf)
        {
            customerInf.Email = _protector.Protect(customerInf.Email);
            customerInf.FirstName = _protector.Protect(customerInf.FirstName);
            customerInf.Address1 = _protector.Protect(customerInf.Address1);
            if (customerInf.Address2 != null)
            {
                customerInf.Address2 = _protector.Protect(customerInf.Address2);
            }
            customerInf.City = _protector.Protect(customerInf.City);
            customerInf.Country = _protector.Protect(customerInf.Country);
            customerInf.LastName = _protector.Protect(customerInf.LastName);
            customerInf.Phone = _protector.Protect(customerInf.Phone);
            customerInf.Postal = _protector.Protect(customerInf.Postal);
            return customerInf;
        }
        public CustomerInf UnProtectCustomerInf(CustomerInf customerInf)
        {
            customerInf.Email = _protector.Unprotect(customerInf.Email);
            customerInf.FirstName = _protector.Unprotect(customerInf.FirstName);
            customerInf.Address1 = _protector.Unprotect(customerInf.Address1);
            if (customerInf.Address2 != null)
            {
                customerInf.Address2 = _protector.Unprotect(customerInf.Address2);
            }
            customerInf.City = _protector.Unprotect(customerInf.City);
            customerInf.Country = _protector.Unprotect(customerInf.Country);
            customerInf.LastName = _protector.Unprotect(customerInf.LastName);
            customerInf.Phone = _protector.Unprotect(customerInf.Phone);
            customerInf.Postal = _protector.Unprotect(customerInf.Postal);
            return customerInf;
        }
    }

    public interface IProtectionService
    {
        public CustomerInf ProtectCustomerInf(CustomerInf customerInf);
        public CustomerInf UnProtectCustomerInf(CustomerInf customerInf);
    }
}
