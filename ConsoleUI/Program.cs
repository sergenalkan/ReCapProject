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
            //ColorGetById();

            //UserAdd();
            //UserGetAll();
            //UserDelete();
            //UserUpdate();
            //UserGetById();

            //CustomerAdd();
            //CustomerGetAll();
            //CustomerDelete();
            //CustomerUpdate();
            //CustomerGetById();

            //RentJoinDto();
            //RentalGetAll();
            //RentalAdd();
            //RentalUpdate();
            //RentalDelete(); 
        }
        #region Rental
        private static void RentalUpdate()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental() { Id = 2, CustomerId = 2,CarId=3, ReturnDate=DateTime.Now};
            rentalManager.Update(rental);
        }

        private static void RentalDelete()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Delete(rentalManager.GetByRentaId(2).Data);
        }


        private static void RentalGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine(rental.Id + " idli kiralamanın kiralanma tarihi " + rental.RentDate + "'dır");
            }
        }
        private static void RentJoinDto()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetRentCarDetails();

            if (result.Success == true)
            {
                foreach (var rent in result.Data)
                {
                    Console.WriteLine(rent.BrandName + " markalı araç" + rent.FirstName+""+rent.LastName+ " isimli müşteriye kiralandı");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void RentalGetById()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetByRentaId(1);
            Console.WriteLine(result.Data.Id + " idli kiralamanın kiralanma tarihi " + result.Data.RentDate + "'dir.");

        }
        private static void RentalAdd()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental() {CarId=4,CustomerId=2,RentDate=DateTime.Now, ReturnDate=null };
            rentalManager.Add(rental);
        }
        #endregion
        #region Customer
        private static void CustomerUpdate()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer() { CustomerId = 2, UserId=2, CompanyName="Amazon" };
            customerManager.Update(customer);
        }

        private static void CustomerDelete()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Delete(customerManager.GetByCustomerId(2).Data);
        }

        private static void CustomerGetAll()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine(customer.CustomerId + " idli müşterinin şirketi " + customer.CompanyName + "'dır");
            }
        }

        private static void CustomerGetById()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetByCustomerId(1);
            Console.WriteLine(result.Data.CustomerId + "  idli kullanıcının  şirketi" + result.Data.CompanyName + "'dir.");

        }
        private static void CustomerAdd()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            Customer customer = new Customer() { UserId=2, CompanyName="Trendyol" };
            customerManager.Add(customer);
        }
        #endregion
        #region User
        private static void UserUpdate()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User() { UserId = 2, FirstName = "Ediz", LastName="Alkan", Email="ediz@gmail.com", Password="123" };
            userManager.Update(user);
        }

        private static void UserDelete()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Delete(userManager.GetUserByUserId(2).Data);
        }

        private static void UserGetAll()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            foreach (var user in userManager.GetAll().Data)
            { 
                Console.WriteLine(user.FirstName+" isimli kullanıcının soyadı "+ user.LastName + "'dır");
            }
        }

        private static void UserGetById()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            var result = userManager.GetUserByUserId(1);
            Console.WriteLine(result.Data.FirstName + "  isimli kullanıcının maili" + result.Data.Email + "'dir.");

        }
        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            User user = new User() { FirstName = "Ediz", LastName = "Alkan", Email = "ediz@gmail.com", Password = "123" };
            userManager.Add(user);
        }
        #endregion
        #region Color
        private static void ColorUpdate()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color() { ColorId = 2, ColorName = "Fuşya" };
            colorManager.Update(color);
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

        private static void ColorGetById()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetById(1);
            Console.WriteLine(result.Data.ColorId + "  idli renk "+result.Data.ColorName+"'dir." );
            
        }
        private static void ColorAdd()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            Color color = new Color() { ColorName = "Turkuaz" };
            colorManager.Add(color);
        }
        #endregion
        #region Brand
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
        #endregion
        #region Car
        
        private static void CarDelete()        
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            var result = carManager.GetCarsByCarId(9).Data;
            carManager.Delete(result);
        }

        private static void CarUpdate()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            Car car1 = new Car() { CarId = 2, BrandId = 2, ColorId = 2, DailyPrice = 15, Description = "Renault", ModelYear = 1996 };
            carManager.Update(car1);
        }

        private static void CarAdd()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            Car car1 = new Car() { BrandId = 1, ColorId = 1, DailyPrice = 15, Description = "Opel", ModelYear = 1996 };
            var result= carManager.Add(car1);
            Console.WriteLine(result.Message);
           
        }

        private static void CarJoinDto()
        {
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));

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
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " idli aracın açıklaması:" + car.Description);
            }
        }
        #endregion
    }
}
