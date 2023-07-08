using System.Diagnostics;

namespace CurosUdemy;

public partial class PerfectPay : ContentPage
{
	decimal bill;
	int tip = 0;
	public PerfectPay()
	{
		InitializeComponent();
	}

	private void entryBill_TextChanged(object sender, TextChangedEventArgs e)
	{
		if (!(sender is Entry))
			return;

		Entry entry = sender as Entry;

		if (entry == null || entry.Text.Equals(null) || entry.Text.Equals(""))
			return;

		this.bill = decimal.Parse(entry.Text);

		this.CalculateTotal();
	}

	private void CalculateTotal()
	{
		//Total tip
		decimal totalTip = (this.bill * this.tip) / 100;

		Debug.WriteLine(this.bill.ToString());
		Debug.WriteLine(this.tip.ToString());
		Debug.WriteLine(totalTip.ToString());


		//TIP X PERSON
		decimal tipByPerson = totalTip / int.Parse(this.lblSplitPersons.Text);
		this.lblTipByPerson.Text = $"{tipByPerson:C}";

		//Subtotal 
		decimal subtotal = (this.bill / int.Parse(this.lblSplitPersons.Text));
		this.lblSubtotalByPerson.Text = $"{subtotal:C}";

		//Total
		decimal totalByiPerson = (this.bill + totalTip) / int.Parse(this.lblSplitPersons.Text);
		this.lblTotalbyPerson.Text =  $"{totalByiPerson:C}";
	}

	private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		if (!(sender is Slider)) 
			return;
		
		Slider slider = (Slider)sender;

		this.tip = (int)slider.Value;

		Debug.WriteLine($"Slider Value: {this.tip}");


		this.lblTip.Text = $"Tip: {this.tip}%";

		this.CalculateTotal();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{

		if (!(sender is Button))
			return;

		Button button = (Button)sender;

		this.sldTip.Value = double.Parse(button.BindingContext as string);

		this.tip = (int)this.sldTip.Value;

		this.lblTip.Text = $"Tip: {this.tip}%";
	}

	private void btnSplitTotal_Clicked(object sender, EventArgs e)
	{
		if (!(sender is Button))
			return;

		Button button = (Button)sender;
		int splitPersons = int.Parse(this.lblSplitPersons.Text);

		if (button.Text.Equals("-"))
		{
			if (splitPersons > 1)
			{
				splitPersons--;
			}
		} 
		else
		{
			splitPersons++;
		}

		this.lblSplitPersons.Text = $"{splitPersons}";
		this.CalculateTotal();

	}
}