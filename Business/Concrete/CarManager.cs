using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public List<Car> GetAll()
        {
            //iş kodları
            return _carDal.GetAll();
        }
        
        public void Add(Car car)
        {
            if (car.Description.Length >= 2 || car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(car.Description + " açıklamalı araç eklendi.");
            }
            else
                Console.WriteLine("Araba açıklaması 2 harften büyük olmalı ve günlük fiyat 0'dan büyük olmalı.");
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }
    }
}
