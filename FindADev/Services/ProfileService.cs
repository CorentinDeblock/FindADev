using FindADev.ASP.Models;
using FindADev.ASP.Models.Form;
using FindADev.DAL;
using FindADev.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Services
{
    public class ProfileService : IService<ProfileForm, ProfileModel>
    {
        private DataContext _dc;
        public ProfileService(DataContext dc)
        {
            _dc = dc;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ProfileForm form)
        {
            _dc.Profiles.Add(new Profile
            {
                Image = Upload(form.ImageFile),
                ImageMimeType = form.ImageFile.ContentType,
                UserId = form.UserId
            });

            _dc.SaveChanges();
        }

        public IEnumerable<ProfileModel> Read()
        {
            return _dc.Profiles
                .Include(p => p.Rate)
                .Select(FromProfile);
        }

        public ProfileModel ReadFromId(int id)
        {
            return _dc.Profiles
                .Include(p => p.Rate)
                .Where(p => p.Id == id)
                .Select(FromProfile)
                .FirstOrDefault();
        }

        public void Update(ProfileForm form)
        {
            throw new NotImplementedException();
        }

        private byte[] Upload(IFormFile image)
        {
            if (image == null) return null;
            using (var memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        private ProfileModel FromProfile(Profile p)
        {
            return new ProfileModel
            {
                Id = p.Id,
                Image = p.Image,
                ImageMimeType = p.ImageMimeType,
                UserId = p.UserId,
                Rate = FormatRate(p)
            };
        }

        private RateModel FormatRate(Profile p)
        {
            if (p.Rate == null) return null;

            return new RateModel
            {
                Id = p.Rate.Id,
                WorkDate = p.Rate.WorkDate,
                WorkTime = p.Rate.WorkTime,
                Prices = p.Rate.Prices,
                ProfileId = p.Rate.ProfileId
            };
        }

        public ProfileModel Find(ProfileForm form)
        {
            throw new NotImplementedException();
        }
    }
}
