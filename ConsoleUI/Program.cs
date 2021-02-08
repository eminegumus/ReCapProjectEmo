using System;
using System.Threading.Channels;
using Business.Concrete;
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

            // carManager.Add(new Car(){BrandId = 1,ColorId = 1,DailyPrice =1000,Description = "M",ModelYear = 2013});

            // GetCars(carManager);

            var carDetails = carManager.GetCarDetails();
            foreach (var car in carDetails)
            {
                //Console.WriteLine(car.CarName + '/' + car.BrandName + '/' + car.ColorName + '/' + car.DailyPrice);
                Console.WriteLine("{0} / {1} / {2} / {3}", car.CarName, car.BrandName, car.ColorName, car.DailyPrice);
            }
        }

        private static void GetCars(CarManager carManager)
        {
            var cars = carManager.GetCars();
            foreach (var car in cars)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
