using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result.Success)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult();
            }

            return new ErrorResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetCarImages()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetCarImageById(int id)
        {

            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfImageAny(carId));
            if (result==null)
            {    
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
               
            }
            return new SuccessDataResult<List<CarImage>>(new List<CarImage> { ShowDefaultImage(carId) });

        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count < 5)
            {
                return new SuccessResult();
            }

            return new ErrorResult(Messages.CarImageLimitExceeded);
        }

        private IResult CheckIfImageAny(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count == 0)
            {
                return new ErrorResult();

            }

            return new SuccessResult();
        }

        private CarImage ShowDefaultImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            var Path = @"C:\Users\igmo\source\repos\ReCapProjectEmo\WebAPI\Images\CarImages\default.jpg";
            return new CarImage(){CarId = carId,Date =DateTime.Now,ImagePath =Path};
        }
    }
}
