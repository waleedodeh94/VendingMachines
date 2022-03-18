using System;
using VendingMachines.Services;

namespace VendingMachines
{
  

   public class SnackMachine : ISnackMachine
    {
		private static SnackItem[] AllSnacks;
		private static int index;
        private int chosenIndex;
        public int ChosenIndex
        {
            get
            {
                return chosenIndex;
            }

            set
            {
                chosenIndex = value;
            }
        }


        private static SnackItem chosenItem;
        public static SnackItem ChosenItem
        {
            get
            {
                return chosenItem;
            }

            set
            {
                chosenItem = value;
            }
        }

        public SnackMachine()
        {
            index = 0;
            AllSnacks = new SnackItem[25];
        }

        public bool IsSnackAvailable(int chosenIndex)
        {
            SnackItem snackItem = GetSnackItem(chosenIndex);
            if (snackItem.Status == true)
                return true;
            else 
                return false;
        }

        public int AskForSelectIndex()
        {
            Console.WriteLine("\nSelect an index of item please! ");
            string selectedIndex = Console.ReadLine();
            Console.WriteLine();
            return (Convert.ToInt16(selectedIndex));
        }

        public bool MsgAboutSnackAvailable(int selectedIndex)
        {
            if (IsSnackAvailable(selectedIndex) == true)
            {
                Logger.Info("About this snack:");
                Console.WriteLine($"Name: {ChosenItem.Name}");
                Console.WriteLine($"Status: Available");
                Console.WriteLine($"Price: {ChosenItem.Price}$");
                Console.WriteLine($"Amount: {ChosenItem.Amount}");
                return true;
            }

            else
            {
                Console.WriteLine($"Name: {ChosenItem.Name}");
                Console.WriteLine($"Price: {ChosenItem.Price}$");
                Console.WriteLine($"Status: NOT Available");
                Console.WriteLine($"Amount: {ChosenItem.Amount}");
                Logger.Info($"Sorry this snack {ChosenItem.Name} is not available!\n");
                return false;
            }
        }

  
		public void AddItem(SnackItem snackItem)
		{
			AllSnacks[index] = snackItem.CopyFromSnackItem();
			index++;
		}

		public static SnackItem[] AllSnackItems()
		{
			return AllSnacks;
		}

        public void UpdateSnackQuantity(int index)
        {
            AllSnackItems()[index].Amount = AllSnackItems()[index].Amount - 1;
            if (AllSnackItems()[index].Amount == 0)
            {
                AllSnackItems()[index].Status = false;
            }

        }

        public void DisplayItems()
        {
            try
            {
             
                AllSnacks = new SnackItem[25];

                AddItem(new SnackItem { Index = 0, Name = "Pizza", Status = true, Amount = 1, Price = 25.0 });
                AddItem(new SnackItem { Index = 1, Name = "Burger", Status = true, Amount = 3, Price = 20.0 });
                AddItem(new SnackItem { Index = 2, Name = "Steak", Status = false, Amount = 0, Price = 0.5 });
                AddItem(new SnackItem { Index = 3, Name = "Croissant", Status = true, Amount = 8, Price = 7.0 });
                AddItem(new SnackItem { Index = 4, Name = "Pancakes", Status = true, Amount = 3, Price = 5.0 });
                AddItem(new SnackItem { Index = 5, Name = "Cookies", Status = true, Amount = 10, Price = 0.2 });
                AddItem(new SnackItem { Index = 6, Name = "Donut", Status = true, Amount = 1, Price = 8.0 });
                AddItem(new SnackItem { Index = 7, Name = "Water", Status = false, Amount = 0, Price = 10.0 });
                AddItem(new SnackItem { Index = 8, Name = "IceCream", Status = true, Amount = 2, Price = 7.0 });
                AddItem(new SnackItem { Index = 9, Name = "SwissRroll", Status = true, Amount = 15, Price = 4.0 });
                AddItem(new SnackItem { Index = 10, Name = "Tuna", Status = true, Amount = 4, Price = 20.0 });
                AddItem(new SnackItem { Index = 11, Name = "Candy", Status = true, Amount = 9, Price = 1.0 });
                AddItem(new SnackItem { Index = 12, Name = "Cake", Status = false, Amount = 0, Price = 6.0 });
                AddItem(new SnackItem { Index = 13, Name = "Barbecue", Status = true, Amount = 30, Price = 3.0 });
                AddItem(new SnackItem { Index = 14, Name = "Chocolate", Status = true, Amount = 10, Price = 0.2 });
                AddItem(new SnackItem { Index = 15, Name = "Tea", Status = true, Amount = 14, Price = 0.5 });
                AddItem(new SnackItem { Index = 16, Name = "Chips", Status = true, Amount = 10, Price = 0.3 });
                AddItem(new SnackItem { Index = 17, Name = "Juise", Status = true, Amount = 6, Price = 3.0 });
                AddItem(new SnackItem { Index = 18, Name = "Lemonade", Status = false, Amount = 0, Price = 8.0 });
                AddItem(new SnackItem { Index = 19, Name = "Biscuits", Status = true, Amount = 30, Price = 0.5 });
                AddItem(new SnackItem { Index = 20, Name = "Pagel", Status = true, Amount = 12, Price = 4.0 });
                AddItem(new SnackItem { Index = 21, Name = "Toast", Status = true, Amount = 10, Price = 1.0 });
                AddItem(new SnackItem { Index = 22, Name = "Pretzel", Status = false, Amount = 0, Price = 5.0 });
                AddItem(new SnackItem { Index = 23, Name = "Popcorn", Status = true, Amount = 10, Price = 10.0 });
                AddItem(new SnackItem { Index = 24, Name = "Hot Dog", Status = true, Amount = 4, Price = 3.0 });

                for (int i = 0; i < 25; i++)
                {
                    if (i % 5 == 0)
                    {
                        Console.WriteLine("\n");
                    }

                    Console.Write($"{AllSnacks[i].Index}-{AllSnacks[i].Name}\t\t");
                }

                Console.WriteLine("\n");
            }

            catch (Exception e)
            {
                Logger.Error(e.Message);
            }


        }

        public SnackItem GetSnackItem(int index)
        {
            SnackItem[] AllSnacks;
            AllSnacks = AllSnackItems();
            for (int i = 0; i < 25; i++)
            {
                if (i == index)
                {
                    ChosenItem = AllSnacks[i].CopyFromSnackItem();
                    ChosenIndex = index;
                    return ChosenItem;

                }
            }
            return ChosenItem;
        }
    }
}
