using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachines.Services
{
    public interface IMoney
    {
        bool AddMoney(double amount);
        double GetChange();

        double ReceivedMoney
        {
            set;
            get;
        }

        double SnackPrice
        {
            set;
            get;
        }

    }
}
