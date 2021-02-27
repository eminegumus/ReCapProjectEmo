using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Result;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage carImage);
        IResult Delete(CarImage carImage);
        IResult Update(CarImage carImage);

        IDataResult<List<CarImage>> GetCarImages();
        IDataResult<CarImage> GetCarImageById(int id);
        IDataResult<List<CarImage>> GetImagesByCarId(int carId);

    }
}
