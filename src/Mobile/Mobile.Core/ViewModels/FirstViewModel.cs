using MvvmCross.Core.ViewModels;
using Mobile.Services;

namespace Mobile.Core.ViewModels
{
	public class FirstViewModel : MvxViewModel
	{
		private string _hello = "Hello MvvmCross";
		private readonly IMarketDataService _dataService;

		public string Hello
		{
			get { return _hello; }
			set { SetProperty(ref _hello, value); }
		}

		public FirstViewModel(IMarketDataService dataService)
		{
			_dataService = dataService;
		}

		public async override void Start()
		{
			base.Start();

			try
			{
				var data = await _dataService.GetMarkets();
			}
			catch (System.Exception e)
			{
				MvxTrace.TaggedError("SERVER_REQUEST", e.ToString());
			}
		}
	}
}
