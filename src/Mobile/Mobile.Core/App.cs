using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;
using Mobile.Services;

namespace Mobile.Core
{
	public class App : MvxApplication
	{
		public override void Initialize()
		{
			Mvx.RegisterSingleton<IMarketDataService>(new MarketDataService());
				
			RegisterAppStart<ViewModels.FirstViewModel>();
		}
	}
}