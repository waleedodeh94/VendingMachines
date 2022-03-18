using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachines.Services
{
    public interface ISnackMachine
    {
        void DisplayItems();
        void UpdateSnackQuantity(int index);


        bool IsSnackAvailable(int chosenIndex);

        int AskForSelectIndex();
        bool MsgAboutSnackAvailable(int selectedIndex);

        int ChosenIndex
        {
            get;
            set;
        }
    }

}
