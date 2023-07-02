using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace CurosUdemy;

public partial class ColorMaker : ContentPage
{
	public ColorMaker()
	{
		InitializeComponent();
	}

	private void sld_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		double Red = sldRed.Value;
		double Green = sldGreen.Value;
		double Blue = sldBlue.Value;

		Color color = Color.FromRgb(Red, Green, Blue);

		SetColor(color);
	}

	private void SetColor(Color color)
	{
		Debug.WriteLine(color.ToString());
		this.randomColor.BackgroundColor = color;
		this.Container.BackgroundColor = color;
		this.hexa.Text = $"HEX Value: {color.ToHex()}";
	}

	private void randomColor_Clicked(object sender, EventArgs e)
	{
		Random random = new Random();

		Color color = Color.FromRgb
			(
			random.Next(0, 256),
			random.Next(0, 256),
			random.Next(0, 256)
			);

		this.SetColor(color);

		this.sldRed.Value = color.Red;
		this.sldGreen.Value = color.Green;
		this.sldBlue.Value = color.Blue;
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
		int idx = this.hexa.Text.IndexOf('#');

		string hexa = this.hexa.Text.Substring(idx, 7);

		await Clipboard.SetTextAsync(hexa);

		await Toast.Make
			(
				"Color copied",
				CommunityToolkit.Maui.Core.ToastDuration.Short,
				15
			)
			.Show();
	}
}