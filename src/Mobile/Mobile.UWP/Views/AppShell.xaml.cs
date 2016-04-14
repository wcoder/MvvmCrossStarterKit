using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Mobile.Core.ViewModels;
using Mobile.UWP.Controls;

namespace Mobile.UWP.Views
{
	// Based on:
	// https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlNavigation/cs/AppShell.xaml.cs

	/// <summary>
	/// The "chrome" layer of the app that provides top-level navigation with
	/// proper keyboarding navigation.
	/// </summary>
	public sealed partial class AppShell
	{
		private bool isPaddingAdded;

		public new AppShellViewModel ViewModel
		{
			get { return (AppShellViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public AppShellViewModel Vm { get; set; }


		/// <summary>
		/// Initializes a new instance of the AppShell, sets the static 'Current' reference,
		/// adds callbacks for Back requests and changes in the SplitView's DisplayMode, and
		/// provide the nav menu list with the data to display.
		/// </summary>
		public AppShell()
		{
			InitializeComponent();
			

			Loaded += (sender, args) =>
			{
				CheckTogglePaneButtonSizeChanged();

				var titleBar = Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar;
				titleBar.IsVisibleChanged += TitleBar_IsVisibleChanged;
			};

			RootSplitView.RegisterPropertyChangedCallback(
				SplitView.DisplayModeProperty,
				(s, a) =>
				{
					// Ensure that we update the reported size of the TogglePaneButton when the SplitView's
					// DisplayMode changes.
					CheckTogglePaneButtonSizeChanged();
				});

			// TODO:
			//SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManager_BackRequested;
			//SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;


			NavMenuList.ItemsSource = new List<NavMenuItem>();
		}


		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			// http://stackoverflow.com/questions/35802164/uwp10-viewmodel-property-is-null
			Vm = ViewModel;


			NavMenuList.ItemsSource = new List<NavMenuItem>(
				new[]
				{
					new NavMenuItem
					{
						Symbol = Symbol.Home,
						Label = "Home",
						Command = ViewModel.GoToFirstCommand
					},
					new NavMenuItem
					{
						Symbol = Symbol.Setting,
						Label = "Second",
						Command = ViewModel.GoToSecondCommand
					}
				});
		}


		#region Window & Titlebar

		/// <summary>
		/// Invoked when window title bar visibility changes, such as after loading or in tablet mode
		/// Ensures correct padding at window top, between title bar and app content
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void TitleBar_IsVisibleChanged(Windows.ApplicationModel.Core.CoreApplicationViewTitleBar sender, object args)
		{
			if (!isPaddingAdded && sender.IsVisible)
			{
				//add extra padding between window title bar and app content
				double extraPadding = (Double)App.Current.Resources["DesktopWindowTopPadding"];
				isPaddingAdded = true;

				Thickness margin = NavMenuList.Margin;
				NavMenuList.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
				margin = MainContent.Margin;
				MainContent.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
				margin = TogglePaneButton.Margin;
				TogglePaneButton.Margin = new Thickness(margin.Left, margin.Top + extraPadding, margin.Right, margin.Bottom);
			}
			
		}

		/// <summary>
		/// Default keyboard focus movement for any unhandled keyboarding
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AppShell_KeyDown(object sender, KeyRoutedEventArgs e)
		{
			FocusNavigationDirection direction = FocusNavigationDirection.None;
			switch (e.Key)
			{
				case Windows.System.VirtualKey.Left:
				case Windows.System.VirtualKey.GamepadDPadLeft:
				case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
				case Windows.System.VirtualKey.NavigationLeft:
					direction = FocusNavigationDirection.Left;
					break;
				case Windows.System.VirtualKey.Right:
				case Windows.System.VirtualKey.GamepadDPadRight:
				case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
				case Windows.System.VirtualKey.NavigationRight:
					direction = FocusNavigationDirection.Right;
					break;

				case Windows.System.VirtualKey.Up:
				case Windows.System.VirtualKey.GamepadDPadUp:
				case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
				case Windows.System.VirtualKey.NavigationUp:
					direction = FocusNavigationDirection.Up;
					break;

				case Windows.System.VirtualKey.Down:
				case Windows.System.VirtualKey.GamepadDPadDown:
				case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
				case Windows.System.VirtualKey.NavigationDown:
					direction = FocusNavigationDirection.Down;
					break;
			}

			if (direction != FocusNavigationDirection.None)
			{
				var control = FocusManager.FindNextFocusableElement(direction) as Control;
				if (control != null)
				{
					control.Focus(FocusState.Programmatic);
					e.Handled = true;
				}
			}
		}

		#endregion

		#region BackRequested Handlers

		//private void SystemNavigationManager_BackRequested(object sender, BackRequestedEventArgs e)
		//{
		//	bool handled = e.Handled;
		//	BackRequested(ref handled);
		//	e.Handled = handled;
		//}

		//private void BackRequested(ref bool handled)
		//{
		//	// Get a hold of the current frame so that we can inspect the app back stack.
			
		//	if (AppFrame == null)
		//		return;

		//	// Check to see if this is the top-most page on the app back stack.
		//	if (AppFrame.CanGoBack && !handled)
		//	{
		//		// If not, set the event to handled and go back to the previous page in the app.
		//		handled = true;
		//		AppFrame.GoBack();
		//	}
		//}

		#endregion

		#region Navigation

		/// <summary>
		/// Navigate to the Page for the selected <paramref name="listViewItem"/>.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="listViewItem"></param>
		private void NavMenuList_ItemInvoked(object sender, ListViewItem listViewItem)
		{
			var item = (NavMenuItem)((NavMenuListView)sender).ItemFromContainer(listViewItem);
			item?.Command?.Execute(item.Parameters);
		}

		#endregion

		#region SplitView

		public Rect TogglePaneButtonRect
		{
			get;
			private set;
		}

		/// <summary>
		/// An event to notify listeners when the hamburger button may occlude other content in the app.
		/// The custom "PageHeader" user control is using this.
		/// </summary>
		public event TypedEventHandler<AppShell, Rect> TogglePaneButtonRectChanged;

		/// <summary>
		/// Public method to allow pages to open SplitView's pane.
		/// Used for custom app shortcuts like navigating left from page's left-most item
		/// </summary>
		public void OpenNavePane()
		{
			TogglePaneButton.IsChecked = true;
			NavPaneDivider.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Hides divider when nav pane is closed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void RootSplitView_PaneClosed(SplitView sender, object args)
		{
			NavPaneDivider.Visibility = Visibility.Collapsed;
		}

		/// <summary>
		/// Callback when the SplitView's Pane is toggled closed.  When the Pane is not visible
		/// then the floating hamburger may be occluding other content in the app unless it is aware.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TogglePaneButton_Unchecked(object sender, RoutedEventArgs e)
		{
			CheckTogglePaneButtonSizeChanged();
		}

		/// <summary>
		/// Callback when the SplitView's Pane is toggled opened.
		/// Restores divider's visibility and ensures that margins around the floating hamburger are correctly set.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TogglePaneButton_Checked(object sender, RoutedEventArgs e)
		{
			NavPaneDivider.Visibility = Visibility.Visible;
			CheckTogglePaneButtonSizeChanged();
		}

		/// <summary>
		/// Check for the conditions where the navigation pane does not occupy the space under the floating
		/// hamburger button and trigger the event.
		/// </summary>
		private void CheckTogglePaneButtonSizeChanged()
		{
			if (RootSplitView.DisplayMode == SplitViewDisplayMode.Inline ||
				RootSplitView.DisplayMode == SplitViewDisplayMode.Overlay)
			{
				var transform = TogglePaneButton.TransformToVisual(this);
				var rect = transform.TransformBounds(new Rect(0, 0, TogglePaneButton.ActualWidth, TogglePaneButton.ActualHeight));
				TogglePaneButtonRect = rect;
			}
			else
			{
				TogglePaneButtonRect = new Rect();
			}

			var handler = TogglePaneButtonRectChanged;
			if (handler != null)
			{
				// handler(this, this.TogglePaneButtonRect);
				handler.DynamicInvoke(this, TogglePaneButtonRect);
			}
		}

		/// <summary>
		/// Enable accessibility on each nav menu item by setting the AutomationProperties.Name on each container
		/// using the associated Label of each item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void NavMenuItemContainerContentChanging(ListViewBase sender, ContainerContentChangingEventArgs args)
		{
			if (!args.InRecycleQueue && args.Item != null && args.Item is NavMenuItem)
			{
				args.ItemContainer.SetValue(AutomationProperties.NameProperty, ((NavMenuItem)args.Item).Label);
			}
			else
			{
				args.ItemContainer.ClearValue(AutomationProperties.NameProperty);
			}
		}

		#endregion
	}
}
