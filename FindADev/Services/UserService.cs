using FindADev.ASP.Models;
using FindADev.ASP.Models.Convertor;
using FindADev.ASP.Models.Form;
using FindADev.DAL;
using FindADev.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FindADev.ASP.Services
{
    public class UserService : IService<UserForm, UserModel>
    {
        private readonly DataContext _dc;
        public UserService(DataContext dc)
        {
            _dc = dc;
        }

        public void Delete(int id)
        {
            _dc.Users.Remove(new User { Id = id });
            _dc.SaveChanges();
        }

        public void Insert(UserForm form)
        {
            _dc.Users.Add(new User
            {
                Email = form.Email,
                Password = HashMe(form.Password),
            });

            _dc.SaveChanges();
        }

        public IEnumerable<UserModel> Read()
        {
            return _dc.Users
                .Include(u => u.Profile)
                .Select(ModelConvertor.FormatUser);
        }

        public UserModel ReadFromId(int id)
        {
            return _dc.Users
                .Where(p => p.Id == id)
                .Select(ModelConvertor.FormatUser)
                .FirstOrDefault();
        }

        public void Update(UserForm form)
        {
            _dc.Update(new User
            {
                Id = form.Id,
                Email = form.Email,
                Password = HashMe(form.Password)
            });

            _dc.SaveChanges();
        }

        public UserModel Find(UserForm model)
        {
            User user = _dc
                .Users
                .Where(t => t.Email == model.Email && t.Password == HashMe(model.Password))
                .Include(p => p.Profile)
                    .ThenInclude(p => p.Knowledges)
                        .ThenInclude(k => k.Titles)
                .Include(p => p.Profile)
                    .ThenInclude(p => p.Rate)
                .SingleOrDefault();

            return user != null ? ModelConvertor.FormatUser(user) : null;
        }

        private byte[] HashMe(string input)
        {
            return SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(input));
        }
    }
}
