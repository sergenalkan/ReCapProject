using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length < 2||user.LastName.Length<2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            if (user.UserId< 0)
            {
                return new ErrorResult(Messages.UserIdNull);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetUserByUserId(int UserId)
        {
            return new SuccessDataResult<User>(_userDal.Get(b => b.UserId == UserId));
        }

        public IResult Update(User user)
        {
            if (user.UserId < 0)
            {
                return new ErrorResult(Messages.UserIdNull);
            }
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
