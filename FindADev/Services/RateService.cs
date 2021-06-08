using FindADev.ASP.Models;
using FindADev.ASP.Models.Convertor;
using FindADev.ASP.Models.Form;
using FindADev.DAL;
using FindADev.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Services
{
    public class RateService : IService<RateForm, RateModel>
    {
        private DataContext _dc;
        public RateService(DataContext dc)
        {
            _dc = dc;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RateModel Find(RateForm form)
        {
            throw new NotImplementedException();
        }

        public void Insert(RateForm form)
        {
            _dc.Rates.Add(new Rate
            {
                Id = form.Id,
                WorkDate = form.WorkDate,
                WorkTime = form.WorkTime,
                Prices = form.Prices,
                ProfileId = form.ProfileId
            });

            _dc.SaveChanges();
        }

        public IEnumerable<RateModel> Read()
        {
            return _dc
                .Rates
                .Select(ModelConvertor.FormatRate);
        }

        public RateModel ReadFromId(int id)
        {
            return _dc
                .Rates
                .Where(r => r.Id == id)
                .Select(ModelConvertor.FormatRate)
                .FirstOrDefault();
        }

        public void Update(RateForm form)
        {
            throw new NotImplementedException();
        }
    }
}
