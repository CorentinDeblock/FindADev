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
    public class KnowledgeService : IService<KnowledgeForm, KnowledgeModel>
    {
        private readonly DataContext _dc;
        public KnowledgeService(DataContext dc)
        {
            _dc = dc;
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(KnowledgeForm form)
        {
            _dc.Knowledges.Add(new Knowledge
            {
                Type = form.Type,
                ProfileId = form.ProfileId
            });

            _dc.SaveChanges();
        }

        public IEnumerable<KnowledgeModel> Read()
        {
            return _dc.Knowledges
                    .Include(k => k.Titles)
                    .Include(k => k.Profile)
                    .Select(ModelConvertor.FormatKnowledge);
        }

        public KnowledgeModel ReadFromId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(KnowledgeForm form)
        {
            throw new NotImplementedException();
        }
        
        private static IEnumerable<KnowledgeInfoModel> FormatInfo(Knowledge info)
        {
            return info.Titles
                .Select(ki => new KnowledgeInfoModel
                {
                    Id = ki.Id,
                    Title = ki.Title,
                    Score = ki.Score,
                    KnowledgeId = ki.KnowledgeId
                });
        }

        public KnowledgeModel Find(KnowledgeForm form)
        {
            throw new NotImplementedException();
        }
    }
}
