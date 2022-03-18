using System;
using System.Collections.Generic;
using VendingMachines.Services;

namespace VendingMachines
{


   public class Money : IMoney
    {
        private double RemainingMoney;
        protected List<double> RemainingMoneyList;

        private double receivedMoney;
        public double ReceivedMoney
        {
            set
            {
                receivedMoney = value;
            }

            get
            {
                return receivedMoney;
            }

        }

        private double snackPrice;
        public  double SnackPrice
        {
            set
            {
                snackPrice = value;
            }

            get
            {
                return snackPrice;
            }
        }

        public virtual bool AddMoney(double amount)
        {
            ReceivedMoney += amount;
            return true;
        }

         private double CalculationMod(double num1, double num2)
        {
            if (num1 < 0)
                num1 = -num1;
            if (num2 < 0)
                num2 = -num2;

            // Find mod 
            double mod = num1;
            while (mod >= num2)
                mod = mod - num2;

            // Sign of result depends on sign of num1.
            if (num1 < 0)
                return -mod;

            return mod;
        }

        public virtual double GetChange()
        {
            RemainingMoneyList = new List<double>();
            RemainingMoney = (ReceivedMoney - SnackPrice);
            if (RemainingMoney == 0)
            {
                return 0;
            }
            else if (RemainingMoney < 0)
            {
                return -1;
            }
            else
            {
                double remaining = RemainingMoney;
                int notes50, notes20;
                notes50 = (int)RemainingMoney / 50;
                remaining = CalculationMod(RemainingMoney, 50.0);
                notes20 = (int)remaining / 20;

                for (int i = 0; i < notes50; i++)
                {
                    RemainingMoneyList.Add(50.0);
                }
                for (int i = 0; i < notes20; i++)
                {
                    RemainingMoneyList.Add(20.0);
                }

                remaining = CalculationMod(remaining, 20.0);
                for (int i = 0; i < (int)remaining; i++)
                {
                    RemainingMoneyList.Add(1.0);
                }

                remaining = remaining - (int)remaining;
                for (int i = 0; i < (int)(remaining * 10); i++)
                {
                    RemainingMoneyList.Add(0.1);
                }

                Console.WriteLine("All returned money:");
                foreach(double ReturnedMoney in RemainingMoneyList)
                {
                    Console.WriteLine(ReturnedMoney);
                }

                return RemainingMoney;

            }
        }

    }
}
