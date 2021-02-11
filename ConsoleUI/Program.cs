﻿using System;
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

        private static void UpdatedColor(ColorManager colorManager)
        {
            var updatedColor = colorManager.Get(5);
            updatedColor.Name = "Kırmızı";
            colorManager.Update(updatedColor);
        }

        private static void GetAllBrand(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("{0} / {1}", brand.Id, brand.Name);
            }
        }

        private static void UpdatedBrand(BrandManager brandManager)
        {
            var updatedBrand = brandManager.GetById(8);
            updatedBrand.Name = "Skoda";
            brandManager.Update(updatedBrand);
        }

        private static void DeletedBrand(BrandManager brandManager)
        {
            brandManager.Delete(brandManager.GetById(6));
        }

        private static void AddedBrand(BrandManager brandManager)
        {
            brandManager.Add(new Brand() { Name = "Fiat" });
            brandManager.Add(new Brand() { Name = "Mazda" });
        }

        private static void carUpdated(CarManager carManager)
        {
            var updatedCar = carManager.Get(1004);
            updatedCar.Description = "BMW";
            updatedCar.BrandId = 1;
            updatedCar.ColorId = 1;
            updatedCar.ModelYear = 2021;
            updatedCar.DailyPrice = 2000;
            carManager.Update(updatedCar);
            Console.WriteLine("Güncelleme işlemi tamamlandı.");
        }

        private static void GetCarsByColorId(CarManager carManager)
        {
            var GetCarsByColorId = carManager.GetCarsByColorId(1);
            foreach (var car in GetCarsByColorId)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void GetCarsByBrandId(CarManager carManager)
        {
            var carGetCarsByBrandId = carManager.GetCarsByBrandId(1);
            foreach (var car in carGetCarsByBrandId)
            {
                Console.WriteLine(car.Id + '/' + car.Description);
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
