using Microsoft.Extensions.Configuration;
using System;

namespace VendingMachines
{
    class NotesSlot : Money
    {
		private readonly IConfiguration _config;

		public NotesSlot(IConfiguration config)
		{
			_config = config;
		}

		public override bool AddMoney(double amount)
		{
			IConfigurationSection Slot_20 = _config.GetSection("ValidSlot:Category1");
			IConfigurationSection Slot_50 = _config.GetSection("ValidSlot:Category2");

			if (amount == Convert.ToDouble(Slot_20.Value) || amount == Convert.ToDouble(Slot_50.Value))
			{
				return base.AddMoney(amount);
			}
			else
			{
				Logger.Error($"There is no {amount} as Notes try again please!\n");
				return false;
			}
		}


		public override double GetChange()
		{
			return base.GetChange();

		}
	}
}
