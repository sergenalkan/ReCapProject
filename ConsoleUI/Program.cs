using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using DataAccess.Abstract;
using System;
using DataAccess.Concrete.EntityFramework;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarJoinDto();
            //CarGetAll();
            //CarAdd();
            //CarUpdate();
            //CarDelete();
            //CarManager carManager = new CarManager(new EfCarDal());
            //Console.WriteLine(carManager.GetCarsByCarId(1).BrandId.ToString());            
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByCarId(9);
            carManager.Delete(result);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 15, Description = "Opel", ModelYear = 1996 };
            carManager.Update(car1);
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { BrandId = 2, ColorId = 2, DailyPrice = 15, Description = "Opel", ModelYear = 1996 };
            carManager.Add(car1);
        }

        private static void CarJoinDto()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.BrandName + " markalı " + car.ColorName + " renkli aracın günlük fiyatı " + car.DailyPrice + " dir.");
            }
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " idli aracın açıklaması:" + car.Description);
            }
        }
    }
}
