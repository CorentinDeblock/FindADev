using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FindADev.ASP.Services
{
    public interface IService<Form,Model>
    {
        public void Insert(Form form);
        public IEnumerable<Model> Read();
        public Model ReadFromId(int id);
        public void Update(Form form);
        public Model Find(Form form);
        public void Delete(int id);
    }
}
