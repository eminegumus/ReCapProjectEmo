using System;
using System.Threading.Channels;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            CustomerManager customerManager=new CustomerManager(new EfCustomerDal(),new EfUserDal());
            UserManager userManager=new UserManager(new EfUserDal());
            RentalManager rentalManager=new RentalManager(new EfRentalDal());
            //CustomerEkleme
           // UserCustomerAddedTest(userManager, customerManager);

           // RentalAddedTest(rentalManager);
            //Car CRUD Test
            //carManager.Add(new Car(){BrandId = 1,ColorId = 1,DailyPrice =1000,Description = "Mercedes",ModelYear = 2015});
            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);
            //carManager.Delete(carManager.Get(1005));
            //carUpdated(carManager);
            //GetCars(carManager);

            //Brand CRUD Test
            //AddedBrand(brandManager);
            //DeletedBrand(brandManager);
            //UpdatedBrand(brandManager);
            //GetAllBrand(brandManager);

            //Color CRUD Test
            //colorManager.Add(new Color(){Name = "Sarı"});
            //colorManager.Delete(colorManager.Get(4));
            //UpdatedColor(colorManager);
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}


            //var carDetails = carManager.GetCarDetails();
            //foreach (var car in carDetails)
            //{
            //    Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            //}
        }

        private static void RentalAddedTest(RentalManager rentalManager)
        {
            rentalManager.Add(new Rental()
            {
                CarId = 1004, CustomerId = 3, ReturnDate = new DateTime(2021, 02, 10),
                RentDate = new DateTime(2021, 02, 09)
            });

            foreach (var rental in rentalManager.GetRentals().Data)
            {
                Console.WriteLine(rental.ReturnDate);
            }
        }

        private static void UserCustomerAddedTest(UserManager userManager, CustomerManager customerManager)
        {
            userManager.Add(new User()
                {Email = "abc@gmail.com", FirstName = "Emine", LastName = "Gümüş"});
            customerManager.Add(new Customer() {CompanyName = "Kodlama.io", UserId = 1});
            customerManager.GetCustomers();
            foreach (var customer in customerManager.GetCustomers().Data)
            {
                Console.WriteLine(customer.CompanyName);
            }
        }

        private static void UpdatedColor(ColorManager colorManager)
        {
            var updatedColor = colorManager.Get(5);
            updatedColor.Data.Name = "Kırmızı";
            colorManager.Update(updatedColor.Data);
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("{0} / {1}", brand.Id, brand.Name);
            }
        }

        private static void UpdatedBrand(BrandManager brandManager)
        {
            var updatedBrand = brandManager.GetById(8);
            updatedBrand.Data.Name = "Skoda";
            brandManager.Update(updatedBrand.Data);
        }

        private static void DeletedBrand(BrandManager brandManager)
        {
            brandManager.Delete(brandManager.GetById(6).Data);
        }

        private static void AddedBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand() { Name = "Fiat" });
            brandManager.Add(new Brand() { Name = "Mazda" });
        }

        private static void carUpdated(CarManager carManager)
        {
            var updatedCar = carManager.Get(1004);
            updatedCar.Data.Description = "BMW";
            updatedCar.Data.BrandId = 1;
            updatedCar.Data.ColorId = 1;
            updatedCar.Data.ModelYear = 2021;
            updatedCar.Data.DailyPrice = 2000;
            carManager.Update(updatedCar.Data);
            Console.WriteLine("Güncelleme işlemi tamamlandı.");
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            var GetCarsByColorId = carManager.GetCarsByColorId(1);
            foreach (var car in GetCarsByColorId.Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            var carGetCarsByBrandId = carManager.GetCarsByBrandId(1);
            foreach (var car in carGetCarsByBrandId.Data)
            {
                Console.WriteLine(car.Id + '/' + car.Description);
            }
        }

        private static void GetCars(CarManager carManager)
        {
            var cars = carManager.GetCars();
            foreach (var car in cars.Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
