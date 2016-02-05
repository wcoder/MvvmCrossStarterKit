using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using Mobile.Services;

namespace Mobile.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			Mvx.ConstructAndRegisterSingleton<IMarketDataService, MarketDataService>();
				
			RegisterAppStart<ViewModels.FirstViewModel>();
		}
	}
}