﻿using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetUserByUserId(int UserId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
