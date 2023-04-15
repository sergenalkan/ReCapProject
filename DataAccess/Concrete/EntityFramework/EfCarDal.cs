using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from x in context.Car
                             join c in context.Color
                             on x.ColorId equals c.ColorId
                             join b in context.Brand
                             on x.BrandId equals b.BrandId
                             select new CarDetailDto
                             {
                                 CarId = x.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice =x.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
