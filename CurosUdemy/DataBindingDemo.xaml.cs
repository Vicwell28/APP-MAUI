using CurosUdemy.Models;

namespace CurosUdemy;

public partial class DataBindingDemo : ContentPage
{
	public DataBindingDemo()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		Person person = new Person
		{
			Name = "Test Name",
			Address = "X Address",
			Phone = "+52 8712655150"
		};

		this.BindingContext = person;


		//txtName.BindingContext = person;
		//txtName.SetBinding(Label.TextProperty, "Name");

		//Binding personBinding = new Binding();

		//personBinding.Source = person;
		//personBinding.Path = "Name"; 

		//this.txtName.SetBinding(Label.TextProperty, personBinding);
	}
}