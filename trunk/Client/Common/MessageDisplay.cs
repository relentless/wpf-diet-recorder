using System.Windows;

namespace DietRecorder.Client.Common
{
    public class MessageDisplay:IMessageDisplay
    {
        public void ShowMessage(string Title, string Message)
        {
            MessageBox.Show(Message, Title);
        }
    }
}
