using System;
using VendingMachines.Services;

namespace VendingMachines
{


    public class BasicFlow : IBasicFlow
    {
        private readonly ISnackMachine _snackMachine;
        private readonly IPayment _payment;

        public BasicFlow( ISnackMachine snackMachine, IPayment payment)
        {
      
            _snackMachine = snackMachine;
            _payment = payment;
        }

        public void GetBasicFlow()
        {
            Logger.GetLogger(typeof(BasicFlow));
            Logger.Info("Welcome to Vending Machines");

            _snackMachine.DisplayItems();

            while (true)
            {
                try
                {
                
                    int selectedIndex = _snackMachine.AskForSelectIndex();

                    if (!(selectedIndex < 0 || selectedIndex > 24))
                    {
                        if (_snackMachine.MsgAboutSnackAvailable(selectedIndex))
                        {
                            _payment.AskForPayingMethod();
                        }
                    }

                    else
                    {
                        Logger.Error("The index out of range, you should select number between 0 and 24");
                    }

                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                }
            }
        }

    }
}
