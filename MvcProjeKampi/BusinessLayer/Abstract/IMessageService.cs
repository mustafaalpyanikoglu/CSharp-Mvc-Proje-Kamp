using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAllInBox();
        List<Message> GetAllSendBox();
        List<Message> GetMessagesInbox(string receiver);
        List<Message> GetMessageSendBox(string sender);
        Message GetById(int id);
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        List<Message> GetAllRead();
        List<Message> IsDraft();
    }
}
