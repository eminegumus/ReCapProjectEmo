using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CarImagesController : ControllerBase
    {
        private ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetCarImages();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetCarImageById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbycarid")]
        public IActionResult GetImagesByCarId([FromForm]int carId)
        {
            var result = _carImageService.GetImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(List<IFormFile> files, [FromForm] CarImage carImage)
        {
            var imagePath = Guid.NewGuid().ToString() + ".jpeg";
            imagePath = @"C:\Users\igmo\source\repos\ReCapProjectEmo\WebAPI\Images\CarImages\" + imagePath;

            IResult result = null;

            foreach (var formFile in files)
            {
                carImage.Id = 0;
                carImage.Date = DateTime.Now;
                carImage.ImagePath = imagePath;

                result = _carImageService.Add(carImage);

                if (result.Success)
                {
                    if (formFile.Length > 0)
                    {
                        using (var stream = new FileStream(imagePath, FileMode.Create))
                        {
                            await formFile.CopyToAsync(stream);
                        }
                    }
                }
                else
                {
                    return BadRequest(result);
                }
            }

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(IFormFile file, [FromForm] CarImage carImage)
        {
            var imagePath = Guid.NewGuid().ToString() + ".jpeg";
            imagePath = @"C:\Users\igmo\source\repos\ReCapProjectEmo\WebAPI\Images\CarImages\" + imagePath;
            if (file.Length > 0)
            {
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            var deletePath = _carImageService.GetCarImageById(carImage.Id).Data.ImagePath;
            System.IO.File.Delete(deletePath);

            carImage.ImagePath = imagePath;
            carImage.Date = DateTime.Now;
            var carId = _carImageService.GetCarImageById(carImage.Id).Data.CarId;
            carImage.CarId = carId;

            IResult result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete(IFormFile file, [FromForm] CarImage carImage)
        {
            var deletePath = _carImageService.GetCarImageById(carImage.Id).Data.ImagePath;
            System.IO.File.Delete(deletePath);

            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
