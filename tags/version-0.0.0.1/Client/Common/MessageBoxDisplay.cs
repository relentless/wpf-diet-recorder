using System.Windows;

namespace DietRecorder.Client.Common
{
    public class MessageBoxDisplay:IMessageBoxDisplay
    {
        public void ShowMessage(string Message, string Title)
        {
            MessageBox.Show(Message, Title);
        }
    }
}
