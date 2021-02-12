using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetUsers()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetUser(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==id));
        }
    }
}
