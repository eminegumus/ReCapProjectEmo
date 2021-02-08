using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars = new List<Car>()
        {
            new Car()
            {
                Id = 1,BrandId = 1,ColorId = 1,DailyPrice = 100000,Description = "new entity",ModelYear = 2013
            },
            new Car()
            {
            Id = 2,BrandId = 1,ColorId = 5,DailyPrice = 110000,Description = "new entity",ModelYear = 2014

            },
            new Car()
            {
            Id = 3,BrandId = 2,ColorId = 2,DailyPrice = 120000,Description = "new entity",ModelYear = 2015
            },
            new Car()
            {
            Id = 4,BrandId = 3,ColorId = 4,DailyPrice = 130000,Description = "new entity",ModelYear = 2016
            },
            new Car()
            {
                Id = 5,BrandId = 4,ColorId = 3,DailyPrice = 140000,Description = "new entity",ModelYear = 2017
            }

        };
        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(p => p.Id == id);
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
           _cars.Add(car);
        }

        public void Update(Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.BrandId = car.BrandId;

        }

        public void Delete(Car entity)
        {
            var carToDelete= _cars.FirstOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carToDelete);

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
