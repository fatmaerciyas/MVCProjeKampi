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
        List<Message> GetListInbox(string mail); // gelen mesajlar
        List<Message> GetListSendbox(string mail); // gonderilen mesajlar
        void MessageAdd(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        List<Message> GetListByUnreadMessages2(); //okunmamis mesajlar
    }
}
