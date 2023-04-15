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
            //CarTest();
            //CarJoinDto();
            //CarAdd();
            CarManager carManager = new CarManager(new EfCarDal());
            Car car1 = new Car() { BrandId = 2, ColorId = 2, DailyPrice = 15, Description = "Opel", ModelYear = 1996 };
            carManager.Update(car1);



            //CarManager carManager = new CarManager(new EfCarDal());
            //Console.WriteLine(carManager.GetCarsByCarId(1).BrandId.ToString());




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

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " idli aracın açıklaması:" + car.Description);
            }
        }
    }
}
