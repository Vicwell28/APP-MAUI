namespace CurosUdemy;
using CurosUdemy.Pages;
using CurosUdemy.Pages.Handgman;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new NavigationPage(new MainPage());

		//MainPage = new FyoutPageExample();

		//MainPage = new TabbedPageExample();

		MainPage = new MainHangMan();
	}
}
