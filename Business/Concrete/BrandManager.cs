﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId));
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            //if (brand.BrandName.Length < 2 )
            //{
            //    return new ErrorResult(Messages.BrandNameInvalid);
            //}
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }
        public IResult Update(Brand brand)
        {
            if (brand.BrandId < 0)
            {
                return new ErrorResult(Messages.BrandIdNull);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
        public IResult Delete(Brand brand)
        {
            if (brand.BrandId < 0)
            {
                return new ErrorResult(Messages.BrandIdNull);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }
    }
}
