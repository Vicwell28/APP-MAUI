namespace CurosUdemy;

public partial class ControlsComando : ContentPage
{
	public ControlsComando()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		DisplayAlert("Title", "Message", "Cancel");
    }

	private void OnSearchButtonPressed(object sender, EventArgs e)
	{
		// Lógica para manejar el evento SearchButtonPressed
		var searchText = searchBar.Text;
		resultLabel.Text = "Buscar: " + searchText;
	}

	private void OnTextChanged(object sender, TextChangedEventArgs e)
	{
		// Lógica para manejar el evento TextChanged
		var searchText = e.NewTextValue;
		resultLabel.Text = "Texto cambiado: " + searchText;
	}
}