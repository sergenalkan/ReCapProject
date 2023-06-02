using Business.Abstract;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            //if (color.ColorName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ColorNameInvalid);
            //}
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }
        public IResult Update(Color color)
        {
            if (color.ColorId < 0)
            {
                return new ErrorResult(Messages.ColorIdNull);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
        public IResult Delete(Color color)
        {
            if (color.ColorId < 0)
            {
                return new ErrorResult(Messages.ColorIdNull);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }
    }
}
