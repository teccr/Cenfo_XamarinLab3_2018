using System;
using System.Windows.Input;

namespace Cenfo_XamarinLab3_2018.Models
{
    public class MenuItemModel
    {
        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Icon
        {
            get;
            set;
        }

        public ICommand Command
        {
            get;
            set;
        }
    }
}
