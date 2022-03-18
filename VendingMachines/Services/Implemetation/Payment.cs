using System;
using VendingMachines.Services;

namespace VendingMachines
{

   public class Payment :IPayment
    {
        private readonly ISnackMachine _snackMachine;
        private IMoney _money;


        public Payment(ISnackMachine snackMachine,IMoney money)
        {
            _snackMachine = snackMachine;
            _money = money;
        }

        private bool PaymentByInsertingCoins()
        {
            string str = Console.ReadLine();
            double coins = Convert.ToDouble(str);
            coins = coins == 1 ? coins : coins / 100.0;
            _money = new CoinSlot(Program.LoadConfiguration());
            _money.SnackPrice = SnackMachine.ChosenItem.Price;

            while (!_money.AddMoney(coins))
            {
                
                Console.WriteLine("Please insert one of the following Coins: 10c, 20c, 50c, 1$");

                str = Console.ReadLine();
                coins = Convert.ToDouble(str);
                coins = coins == 1 ? coins : coins / 100.0;

            }

            Logger.Info($"\nReceived Money: {_money.ReceivedMoney}$ \nSnack Price: {_money.SnackPrice}$");

            while (_money.ReceivedMoney < _money.SnackPrice)
            {
                Console.WriteLine($"Still need To insert more money! \nThe Snack Price: {_money.SnackPrice}$ & You inserted only: {_money.ReceivedMoney}$");
                str = Console.ReadLine();
                coins = Convert.ToDouble(str);
                coins = coins == 1 ? coins : coins / 100.0;
                _money.AddMoney(coins);
            }

            if (_money.ReceivedMoney >= _money.SnackPrice)
            {
                if (_money.ReceivedMoney == _money.SnackPrice)
                {
                    Logger.Info("Payment DONE!");
                    return true;
                }
                else
                {
                    Console.WriteLine("GREAT!\n Please press Enter to receive your change.");
                    str = Console.ReadLine();
                    if (str == "")
                    {
                        Logger.Info($"Your Change is: {_money.GetChange()}$");
                        return true;
                    }
                }
            }

            return false;
        }


        private bool PaymentByInsertingNotes()
        {
            string str = Console.ReadLine();
            double notes = Convert.ToDouble(str);
            _money = new NotesSlot(Program.LoadConfiguration());
            _money.SnackPrice = (SnackMachine.ChosenItem.Price);

            while (!_money.AddMoney(notes))
            {

                Console.WriteLine("Please insert one of the following Coins: 10c, 20c, 50c, 1$");

                str = Console.ReadLine();
                notes = Convert.ToDouble(str);

            }

            Logger.Info($"\nReceived Money: {_money.ReceivedMoney}$ \nSnack Price: {_money.SnackPrice}$");

            while (_money.ReceivedMoney < _money.SnackPrice)
            {
                Console.WriteLine($"Still need To insert more money! \nThe Snack Price: {_money.SnackPrice}$ & You inserted only: {_money.ReceivedMoney}$");
                str = Console.ReadLine();
                notes = Convert.ToDouble(str);
                _money.AddMoney(notes);
            }

            if (_money.ReceivedMoney >= _money.SnackPrice)
            {
                if (_money.ReceivedMoney == _money.SnackPrice)
                {
                    Logger.Info("Payment DONE!");
                    return true;
                }
                Console.WriteLine("GREAT!\nPlease press Enter to receive your change.");
                str = Console.ReadLine();
                if (str == "")
                {
                    Logger.Info($"Your Change is: {_money.GetChange()}");
                    return true;
                }
            }

            return false;
        }

        private bool PaymentByCards()
        {
            _money.ReceivedMoney = 0;
            string str = Console.ReadLine();
            double notes = Convert.ToDouble(str);
            _money.SnackPrice = (SnackMachine.ChosenItem.Price);

            while (!_money.AddMoney(notes))
            {

                Console.WriteLine("Please additoal mony");

                str = Console.ReadLine();
                notes = Convert.ToDouble(str);

            }

            Logger.Info($"\nReceived Money: {_money.ReceivedMoney}$ \nSnack Price: {_money.SnackPrice}$");

            while (_money.ReceivedMoney < _money.SnackPrice)
            {
                Console.WriteLine($"Still need To insert more money! \nThe Snack Price: {_money.SnackPrice}$ & You inserted only: {_money.ReceivedMoney}$");
                str = Console.ReadLine();
                notes = Convert.ToDouble(str);
                _money.AddMoney(notes);
            }

            if (_money.ReceivedMoney >= _money.SnackPrice)
            {
                if (_money.ReceivedMoney == _money.SnackPrice)
                {
                    Logger.Info("Payment DONE!");
                    return true;
                }
                Console.WriteLine("GREAT!\nPlease press Enter to receive your change.");
                str = Console.ReadLine();
                if (str == "")
                {
                    Logger.Info($"Your Change is: {_money.GetChange()}");
                    return true;
                }
            }

            return false;
        }

        public void AskForPayingMethod()
        {
            Console.WriteLine("\nPlease choose how to pay:\n1. Coins Slot: 10c, 20c, 50c, 1$\n2. Notes Slot: 20$, 50$\n3. Cards");
            int paymentWay = Convert.ToInt16(Console.ReadLine());

            if (paymentWay == 1)
            {
                Console.WriteLine("\nPlease insert one of The following Coins: 10c, 20c, 50c, 1$");
                if (PaymentByInsertingCoins())
                    _snackMachine.UpdateSnackQuantity(_snackMachine.ChosenIndex);
                   

            }
            else if(paymentWay == 2)
            {
                Console.WriteLine("\nPlease insert one of The following Notes: 20$ OR 50$");
                if (PaymentByInsertingNotes())
                    _snackMachine.UpdateSnackQuantity(_snackMachine.ChosenIndex);
                

            }
            else
            {
                Console.WriteLine("\nPlease insert how much money do u want withdraw:");
                if (PaymentByCards())
                    _snackMachine.UpdateSnackQuantity(_snackMachine.ChosenIndex);
            }
        }
    }
}
