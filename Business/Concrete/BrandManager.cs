using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int brandId)
        {
            return _brandDal.Get(b => b.BrandId == brandId);
        }
        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2 )
            {
                _brandDal.Add(brand);
                Console.WriteLine(brand.BrandName + " araba markası eklendi.");
            }
            else
                Console.WriteLine("Marka adı en az 2 harften oluşmalıdır.");
        }
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }
    }
}
