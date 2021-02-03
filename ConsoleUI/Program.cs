using System;
using System.Threading.Channels;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
           CarManager carManager=new CarManager(new InMemoryCarDal());
           var cars=carManager.GetCars();
           foreach (var car in cars)
           {
               Console.WriteLine(car.ModelYear);
           }
        }
    }
}
