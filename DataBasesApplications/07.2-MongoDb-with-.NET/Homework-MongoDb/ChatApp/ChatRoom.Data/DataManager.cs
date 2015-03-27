using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoom.Context;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;
using System.Collections.ObjectModel;

namespace ChatRoom.Data
{
    public class DataManager 
    {
        // in order to work you have to put valid connection string
        private const string connectionString = "";
        private static MongoClient client = new MongoClient(connectionString);
        private static MongoServer server = client.GetServer();
        private static MongoDatabase database = server.GetDatabase("chat_room");
        private static MongoCollection mongoMessages = database.GetCollection<MongoMessage>("messages");
        private User user;
        private List<Message> localMessages = new List<Message>();

        public User User
        {
            get { return this.user; }
        }

        public DataManager(User user)
        {
            this.user = user;
            
        }

        public List<string> GetNewMessages(DateTime loginDate)
        {
            List<string> result = new List<string>();
            Message lastMessage = localMessages.OrderByDescending(m => m.Date).FirstOrDefault();

            if (lastMessage != null)
            {
                return SinhronizeMessages(lastMessage.Date);
            }

            return SinhronizeMessages(loginDate); ;
        }

        private List<string> SinhronizeMessages(DateTime lastDate)
        {
            List<string> result = new List<string>();
            List<Message> newMessages = new List<Message>();

            mongoMessages.FindAllAs<MongoMessage>().ToList().ForEach(m => newMessages.Add(MongoToMessage(m)));

            List<Message> newest = newMessages.Where(m => m.Date > lastDate).ToList();

            localMessages.AddRange(newest);
            newest.ForEach(m => result.Add(StringFormatMessage(m)));

            return result;
        }

        public string SaveMessage(string text)
        {            
            Message message = new Message()
            {
                User = this.user,
                Text = text,
                Date = DateTime.Now
            };
            localMessages.Add(message);
            mongoMessages.Insert(MessageToMongo(message));

            return StringFormatMessage(message);
        }

        public List<string> GetAllMessages()
        {
            List<string> result = new List<string>();
            List<Message> dbMessages = new List<Message>();

            mongoMessages.FindAllAs<MongoMessage>()
                .ToList().ForEach(m => dbMessages.Add(MongoToMessage(m)));

            this.localMessages.Clear();
            dbMessages.ForEach(m => localMessages.Add(m));
            dbMessages.ForEach(ms => result.Add(StringFormatMessage(ms)));

            return  result;
        }

        private string StringFormatMessage(Message message)
        {
            return String.Format("{0} - {1}\n{2}\n", message.Date, message.User.Username, message.Text);
        }

        private Message MongoToMessage(MongoMessage message)
        {
            Message result = new Message()
            {
                Id = message.Id,
                Text = message.Text,
                User = message.User,
                Date = DateTime.Parse(message.Date)
            };

            return result;
        }

        private MongoMessage MessageToMongo(Message mesage)
        {
            MongoMessage result = new MongoMessage()
            {
                Id = mesage.Id,
                Text = mesage.Text,
                User = mesage.User,
                Date = mesage.Date.ToString()
            };

            return result;
        }
    }
}
