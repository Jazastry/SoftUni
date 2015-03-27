using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatRoom.Context;
using ChatRoom.Data;
using System.Collections.ObjectModel;
using System.Threading;

namespace ChatRoom.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DataManager dManager;
        public User user;
        private DateTime lpoginTime;
        public volatile ObservableCollection<string> Messages;

        public MainWindow(string userName)
        {
            InitializeComponent();
            Messages = new ObservableCollection<string>();
            MessagesBox.ItemsSource = Messages;
            this.user = new User() { Username = userName };
            this.dManager = new DataManager(this.user);
            UserNameLabel.Text = userName;
            this.lpoginTime = DateTime.Now;
            UpdateMessages();
        }

        private void UpdateMessages()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                while (true)
                {
                    this.Dispatcher.BeginInvoke((Action)delegate
                    {
                        dManager.GetNewMessages(this.lpoginTime).ForEach(m => this.Messages.Add(m));
                    }); 
                    Thread.Sleep(3000);
                }
            }).Start();
        }

        private void LoadAllMessagesBtn_Click(object sender, EventArgs e)
        {
            this.Messages.Clear();
            this.dManager.GetAllMessages().ForEach(m => this.Messages.Add(m));
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string messageText = InputMessage.Text;
            string  messageStr = dManager.SaveMessage(messageText);
            this.Messages.Add(messageStr);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserNameBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
