namespace CurosUdemy.Pages;
using Models;

public partial class INotifyPageDemo : ContentPage
{
	private Person person; 
	public INotifyPageDemo()
	{
		InitializeComponent();

		this.person = new Person
		{
			Name = "Test Name",
			Address = "X Address",
			Phone = "+52 8712655150"
		};

		this.BindingContext = this.person;
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		this.person.Name = "New Test Name"; 
		this.person.Address = "New X Address"; 
		this.person.Phone = "+52 8712655151";
	}
}