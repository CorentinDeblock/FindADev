using FindADev.ASP.Models;
using FindADev.ASP.Models.Form;
using FindADev.DAL;
using FindADev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Services
{
    public class KnowledgeInfoService : IService<KnowledgeInfoForm, KnowledgeInfoModel>
    {
        private readonly DataContext _dc;
        public KnowledgeInfoService(DataContext dc)
        {
            _dc = dc;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public KnowledgeInfoModel Find(KnowledgeInfoForm form)
        {
            throw new NotImplementedException();
        }

        public void Insert(KnowledgeInfoForm form)
        {
            _dc
               .knowledgeInfos
               .Add(new KnowledgeInfo
               {
                   Title = form.Title,
                   Score = form.Score,
                   KnowledgeId = form.KnowledgeId
               });

            _dc.SaveChanges();
        }

        public IEnumerable<KnowledgeInfoModel> Read()
        {
            return _dc
                .knowledgeInfos
                .Select(ki => new KnowledgeInfoModel
                {
                    Id = ki.Id,
                    Title = ki.Title,
                    Score = ki.Score,
                    KnowledgeId = ki.KnowledgeId
                });
        }

        public KnowledgeInfoModel ReadFromId(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(KnowledgeInfoForm form)
        {
            throw new NotImplementedException();
        }
    }
}
