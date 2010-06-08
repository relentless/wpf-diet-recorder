using System.Windows;
using BlogsPrajeesh.BlogSpot.WPFControls;

namespace DietRecorder.Client.Common
{
    public class MessageDisplay:IMessageDisplay
    {
        /// <summary>
        /// Shows message in WPFMessageBox from:
        /// http://prajeeshprathap.codeplex.com/SourceControl/PatchList.aspx
        /// </summary>
        public void ShowMessage(string Title, string Message)
        {
            WPFMessageBox.Show(Title, Message);
        }
    }
}
