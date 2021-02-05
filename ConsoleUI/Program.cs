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
           CarManager carManager=new CarManager(new EfCarDal());
           BrandManager brandManager=new BrandManager(new EfBrandDal());
           ColorManager colorManager=new ColorManager(new EfColorDal());
           
           carManager.Add(new Car(){BrandId = 1,ColorId = 1,DailyPrice =1000,Description = "M",ModelYear = 2013});

           var cars = carManager.GetCars();
           foreach (var car in cars)
           {
               Console.WriteLine(car.Description);
           }

        }
    }
}
