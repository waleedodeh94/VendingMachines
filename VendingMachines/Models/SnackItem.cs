
namespace VendingMachines
{
   public class SnackItem 
    {
        private int index;
        public int Index
        {
            set
            {
                if (value >= 0 && value <= 24)      // 25 snack items
                {
                   index = value;
                }

                else
                {
                    Logger.Error("The index out of range, you should select number between 0 and 24");
                }
            }

            get
            {
                return index;
            }
        }

        public string Name { get; set; }
        private double price;
        public double Price
        {
            set
            {
                if (value >= 0)
                {
                    price = value;
                }

                else
                {
                    Logger.Error("The price should be positive value.");
                }
            }

            get
            {
                return price;
            }
        }
        public bool Status { get; set; }
        public int Amount { get; set; }

        public SnackItem CopyFromSnackItem()
        {
            SnackItem snackItem = new SnackItem();

            snackItem.Index = this.Index;
            snackItem.Price = this.Price;
            snackItem.Name = this.Name;
            snackItem.Status = this.Status;
            snackItem.Amount = this.Amount;

            return snackItem;

        }

    }
}
