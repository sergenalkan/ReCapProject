﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }
        public void Add(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Add(color);
                Console.WriteLine(color.ColorName + " araba rengi eklendi.");
            }
            else
                Console.WriteLine("Marka adı en az 2 harften oluşmalıdır.");
        }
        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }
    }
}