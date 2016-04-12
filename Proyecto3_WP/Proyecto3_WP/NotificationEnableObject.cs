using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Proyecto3_WP
{
    public class NotificationEnableObject : INotifyPropertyChanged       
    {
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName=null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
