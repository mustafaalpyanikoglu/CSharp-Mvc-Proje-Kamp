using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        private IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void Add(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void Delete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public List<Writer> GetAll()
        {
            return _writerDal.GetAll();
        }

        public Writer GetByEmail(string email)
        {
            return _writerDal.Get(w => w.WriterMail == email);
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(w => w.WriterId == id);
        }

        public void Update(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
