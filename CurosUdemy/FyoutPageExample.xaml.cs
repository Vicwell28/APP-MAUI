namespace CurosUdemy;

public partial class FyoutPageExample : FlyoutPage
{
	public FyoutPageExample()
	{
		InitializeComponent();
	}

	void OnPage1ButtonClicked(object sender, EventArgs e)
	{
		Detail = new NavigationPage(new MainPage());
		IsPresented = false; // Esto cierra el panel Flyout
	}

	void OnPage2ButtonClicked(object sender, EventArgs e)
	{
		Detail = new NavigationPage(new ContentPageExample());
		IsPresented = false; // Esto cierra el panel Flyout
	}
}