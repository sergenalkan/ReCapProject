using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using DataAccess.Abstract;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Car car1 = new Car();
            car1.CarId = 4;
            car1.BrandId = 2;
            car1.ColorId = 3;
            car1.DailyPrice = 750000;
            car1.Description = "Clio Icon Paket";
            car1.ModelYear = 2023;
            carManager.Add(car1);
            Console.WriteLine(car1.Description+" açıklamalı araç eklendi\n------------------");
            
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId+" markalı aracın açıklaması:"+car.Description);
            }

            Console.WriteLine("-------------------");
            foreach (var car in carManager.GetByID(3))
            {
                Console.WriteLine(car.CarId + ":Id Numaralı Araç" + car.Description);
            }
        }
    }
}
