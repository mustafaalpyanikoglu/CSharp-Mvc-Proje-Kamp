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
    public class MessageManager : IMessageService
    {
        private IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAllInBox()
        {
            return _messageDal.GetAll(m=>m.ReceiverMail == "aliyildiz@gmail.com");
        }

        public List<Message> GetAllRead()
        {
            return _messageDal.GetAll(m => m.ReceiverMail == "aliyildiz@gmail.com").Where(m => m.IsRead == false).ToList();
        }

        public List<Message> GetAllSendBox()
        {
            return _messageDal.GetAll(m => m.SenderMail == "aliyildiz@gmail.com");
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(m=>m.MessageId == id);
        }

        public List<Message> GetMessageSendBox(string sender)
        {
            return _messageDal.GetAll(m => m.SenderMail == sender);
        }

        public List<Message> GetMessagesInbox(string receiver)
        {
            return _messageDal.GetAll(m => m.ReceiverMail == receiver); 

        }

        public List<Message> IsDraft()
        {
            return _messageDal.GetAll(m => m.IsDraft == true);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
