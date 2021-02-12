using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private IUserDal _userDal;
        public CustomerManager(ICustomerDal customerDal, IUserDal userDal)
        {
            _customerDal = customerDal;
            _userDal = userDal;
        }

        public IResult Add(Customer customer)
        {
            var InvalidCustomer = _userDal.Get(u => u.Id == customer.UserId);
            if (InvalidCustomer != null)
            {
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            }
            else
            {
                return new ErrorResult(Messages.InvalidUser);
            }
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult();
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult();
        }

        public IDataResult<List<Customer>> GetCustomers()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetCustomer(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.Id == id));
        }
    }
}
