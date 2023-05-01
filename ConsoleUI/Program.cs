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

            //BrandAdd();
            //BrandGetAll();
            //BrandDelete();
            //BrandUpdate();

            //ColorAdd();
            //ColorGetAll();
            //ColorDelete();
            //ColorUpdate();

        }
        private static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color brand = new Color() { ColorId = 2, ColorName = "Fuşya" };
            colorManager.Update(brand);
        }

        private static void ColorDelete()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(colorManager.GetById(2).Data);
        }

        private static void ColorGetAll()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName + " rengi");
            }
        }

        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color() { ColorName = "Turkuaz" };
            colorManager.Add(color);
        }
        private static void BrandUpdate()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand() { BrandId = 2, BrandName = "Chevrolet" };
            brandManager.Update(brand);
        }

        private static void BrandDelete()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Delete(brandManager.GetById(2).Data);
        }

        private static void BrandGetAll()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName + " markası");
            }
        }

        private static void BrandAdd()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Brand brand = new Brand() { BrandName = "TOGG" };
            brandManager.Add(brand);
        }

        private static void CarDelete()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarsByCarId(9).Data;
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

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " markalı " + car.ColorName + " renkli aracın günlük fiyatı " + car.DailyPrice + " dir.");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarGetAll()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " idli aracın açıklaması:" + car.Description);
            }
        }
    }
}
