using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            //if (rental.Id < 0)
            //{
            //    return new ErrorResult(Messages.RentalIdNull);
            //}
            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.Id < 0)
            {
                return new ErrorResult(Messages.RentalIdNull);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetByRentaId(int RentId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == RentId));
        }

        public IDataResult<List<RentCarDto>> GetRentCarDetails()
        {
            return new SuccessDataResult<List<RentCarDto>>(_rentalDal.GetRentCarDetails());
        }

        public IResult Update(Rental rental)
        {
            if (rental.Id < 0)
            {
                return new ErrorResult(Messages.RentalIdNull);
            }
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
