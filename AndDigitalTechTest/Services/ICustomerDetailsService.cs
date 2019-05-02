using Microsoft.Extensions.Caching.Memory;
using AndDigitalTechTest.Models;
using System.Collections.Generic;
using System.Linq;
namespace AndDigitalTechTest.Services
{
   public interface ICustomerDetailsService
    {
        List<CustomersDetails> ReadAll();
        void Create(CustomersDetails _customer);
        CustomersDetails Read(int id);
        void Update(CustomersDetails _modifiedCustomer);
        void Delete(int id);
    }

    public class CustomersDetailsService : ICustomerDetailsService
    {
        private readonly IMemoryCache _cache;

        public CustomersDetailsService(IMemoryCache _cache1)
        {
            _cache = _cache1;
        }

        public List<CustomersDetails> ReadAll()
        {
            if (_cache.Get("CustomersDetailsList") == null)
            {
                List<CustomersDetails> customers = new List<CustomersDetails>
                   {
                        new CustomersDetails
                        {
                            _id                  = 0,
                            _customersName         = "Ted Baker",
                            _customersPhoneNumber = 07743234671
                        },
                        new CustomersDetails
                        {
                            _id                  = 1,
                            _customersName         = "Ted Baker",
                            _customersPhoneNumber = 07743234671
                        },
                        new CustomersDetails
                        {
                            _id                  = 2,
                            _customersName         = "Ted Smith",
                            _customersPhoneNumber = 0161222333
                        },
                        new CustomersDetails
                        {
                            _id                  = 3,
                            _customersName         = "Ted Muller",
                            _customersPhoneNumber = 07743234677
                        },
                                                new CustomersDetails
                        {
                            _id                  = 4,
                            _customersName         = "Mark Baker",
                            _customersPhoneNumber = 07742234671
                        },
                   };
                _cache.Set("CustomersDetailsList", customers);
            }
            return _cache.Get<List<CustomersDetails>>("CustomersDetailsList");
        }

        public void Create(CustomersDetails _customer)
        {
            var _customers = ReadAll();
            _customer._id = _customers.Max(c => c._id) + 1;
            _customers.Add(_customer);
            _cache.Set("CustomersDetailsList", _customers);
        }

        public CustomersDetails Read(int id)
        {
            return ReadAll().Single(c => c._id == id);
        }

        public void Update(CustomersDetails _modifiedCustomer)
        {
            var _customers = ReadAll();
            var _customer = _customers.Single(c => c._id == _modifiedCustomer._id);
            _customer._customersName = _modifiedCustomer._customersName;
            _customer._customersPhoneNumber = _modifiedCustomer._customersPhoneNumber;
            _cache.Set("CustomersDetailsList", _customers);
        }

        public void Delete(int id)
        {
            var _customers = ReadAll();
            var _deletedCustomer = _customers.Single(c => c._id == id);
            _customers.Remove(_deletedCustomer);
            _cache.Set("CustomersDetailsList", _customers);
        }
    }
    }
