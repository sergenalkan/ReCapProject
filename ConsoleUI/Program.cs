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
            CarManager carManager = new CarManager(new EfCarDal());
          
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.BrandId+" markalı aracın açıklaması:"+car.Description);
            }
            foreach (var c in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(c.BrandId + " markalı aracın açıklaması:" + c.Description); ;
            }
         
            Car car1 = new Car();
            car1.BrandId = 2;
            car1.ColorId = 2;
            car1.DailyPrice = -1;
            car1.Description = "C";
            car1.ModelYear = 1996;
            carManager.Add(car1);
            
        }
    }
}
