using FindADev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Models.Convertor
{
    public static class ModelConvertor
    {
        public static UserModel FormatUser(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Profile = FormatProfile(user)
            };
        }

        public static ProfileModel FormatProfile(User user)
        {
            if (user.Profile == null) return null;

            return new ProfileModel
            {
                Id = user.Profile.Id,
                Image = user.Profile.Image,
                ImageMimeType = user.Profile.ImageMimeType,
                Knowledges = FormatKnowledges(user.Profile.Knowledges),
                Rate = FormatRate(user.Profile.Rate),
                UserId = user.Profile.UserId
            };
        }

        public static KnowledgeModel FormatKnowledge(Knowledge k)
        {
            return new KnowledgeModel
            {
                Id = k.Id,
                Type = k.Type,
                ProfileId = k.ProfileId,
                Profile = FormatKnowledgeProfile(k),
                Titles = FormatInfos(k)
            };
        }

        public static IEnumerable<KnowledgeModel> FormatKnowledges(IEnumerable<Knowledge> knowledges)
        {
            List<KnowledgeModel> kmie = new List<KnowledgeModel>();

            foreach (var k in knowledges)
                kmie.Add(FormatKnowledge(k));

            return kmie;
        }

        public static KnowledgeInfoModel FormatInfo(KnowledgeInfo info)
        {
            return new KnowledgeInfoModel
            {
                Id = info.Id,
                Title = info.Title,
                Score = info.Score,
                KnowledgeId = info.KnowledgeId
            };
        }

        public static IEnumerable<KnowledgeInfoModel> FormatInfos(Knowledge info)
        {
            List<KnowledgeInfoModel> kime = new List<KnowledgeInfoModel>();
            foreach (var titles in info.Titles)
                kime.Add(FormatInfo(titles));
            return kime;
        }

        public static RateModel FormatRate(Rate rt)
        {
            return new RateModel
            {
                Id = rt.Id,
                WorkDate = rt.WorkDate,
                WorkTime = rt.WorkTime,
                Prices = rt.Prices,
                ProfileId = rt.ProfileId
            };
        }

        public static ProfileModel FormatKnowledgeProfile(Knowledge knowledge)
        {
            if (knowledge.Profile == null) return null;

            return new ProfileModel
            {
                Id = knowledge.Profile.Id,
                Image = knowledge.Profile.Image,
                ImageMimeType = knowledge.Profile.ImageMimeType,
                UserId = knowledge.Profile.UserId
            };
        }
    }
}
