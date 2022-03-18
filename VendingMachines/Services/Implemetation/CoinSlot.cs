using Microsoft.Extensions.Configuration;
using System;


namespace VendingMachines
{
    class CoinSlot : Money
    {
		private readonly IConfiguration _config;

		public CoinSlot(IConfiguration config)
		{
			_config = config;
		}

		public override bool AddMoney(double amount)
		{

			IConfigurationSection Coins_10c = _config.GetSection("ValidCoin:Class1");
			IConfigurationSection Coins_20c = _config.GetSection("ValidCoin:Class2");
			IConfigurationSection Coins_50c = _config.GetSection("ValidCoin:Class3");
			IConfigurationSection Coins_1 = _config.GetSection("ValidCoin:Class4");


			if (amount == Convert.ToDouble(Coins_10c.Value) || amount == Convert.ToDouble(Coins_20c.Value) || amount == Convert.ToDouble(Coins_50c.Value) || amount == Convert.ToDouble(Coins_1.Value))
			{
				return base.AddMoney(amount);
			}
			else
			{
				Logger.Error($"There is no {amount * 100} as Coins try again please!\n");
				return false;
			}
		}

		
	    public override double GetChange()
		{
			return base.GetChange();
		}

	}
}
