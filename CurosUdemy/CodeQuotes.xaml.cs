using System.Diagnostics;

namespace CurosUdemy;



public partial class CodeQuotes : ContentPage
{
	private Random random = new Random();
	List<string> quotes = new List<string>();

	public CodeQuotes()
	{
		InitializeComponent();
	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await this.LoadMauiAsset();
	}

	protected override void OnDisappearing()
	{
		base.OnDisappearing();
	}

	async Task LoadMauiAsset()
	{
		Debug.WriteLine("Se cargo archivo");
		using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
		using var reader = new StreamReader(stream);

		while (reader.Peek() != -1)
		{
			quotes.Add(reader.ReadLine());
		}
	}

	private void Button_Clicked(object sender, EventArgs e)
	{

		System.Drawing.Color StartColor = this.GenerateColor();
		System.Drawing.Color EndColor = this.GenerateColor();

		List<System.Drawing.Color> colors = ColorUtility.ColorControls.GetColorGradient(StartColor, EndColor, 6);



		float stopOffset = .0f;
		GradientStopCollection stops = new GradientStopCollection();

		foreach (System.Drawing.Color c in colors)
		{
			stops.Add(new GradientStop(Color.FromArgb(c.Name),
				 stopOffset));
			stopOffset += .2f;
		}

		var gradient =
			 new LinearGradientBrush(stops,
				  new Point(0, 0),
				  new Point(1, 1));

		this.gridBack.Background = gradient;

		int index = random.Next(this.quotes.Count);
		this.lblQuote.Text = this.quotes[index];
	}


	private System.Drawing.Color GenerateColor()
	{
		return System.Drawing.Color.FromArgb
			(
				this.random.Next(0, 256),
				this.random.Next(0, 256),
				this.random.Next(0, 256)
			);
	}
}