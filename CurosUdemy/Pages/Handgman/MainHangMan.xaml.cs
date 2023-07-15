using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace CurosUdemy.Pages.Handgman;

public partial class MainHangMan : ContentPage, INotifyPropertyChanged
{
	#region UI Properties
	public string SpotLight
	{
		get => spotLight; set
		{
			spotLight = value;
			OnPropertyChanged();
		}
	}

	public List<char> Letters
	{
		get => letters; set
		{
			letters = value;
			OnPropertyChanged();
		}
	}

	public string Message
	{
		get => message; set
		{
			message = value;
			OnPropertyChanged();
		}
	}

	public string GameStatus
	{
		get => gameStatus; set
		{
			gameStatus = value;
			OnPropertyChanged();
		}
	}
	public string CurrentImage
	{
		get => currentImage; set
		{
			currentImage = value;
			OnPropertyChanged();
		}
	}
	#endregion


	#region fields
	List<string> words = new List<string>()
	 {
		"python",
		"javascript",
		"maui",
		"csharp",
		"mongodb",
		"sql",
		"xaml",
		"word",
		"excel",
		"powerpoint",
		"code",
		"hotreload",
		"snippets"
	 };
	string answer = "";
	private string spotLight;
	List<char> guessed = new List<char>();
	private List<char> letters = new List<char>();
	private string message = "";
	private string gameStatus = "Errors: 0 of 6";
	private string currentImage = "Hangman/hangman0.jpg";
	public int mistakes = 0;
	public int maxWrong = 6;

	#endregion

	public MainHangMan()
	{
		InitializeComponent();
		Letters.AddRange("abcdefghijklmnñopqrstuvwxyz".ToUpper()); 
		this.BindingContext = this; 
		this.PickWord();
		this.CalculateWord(this.answer, this.guessed);
	}

	#region Game Engine

	private void PickWord()
	{
		this.answer = this.words[new Random().Next(0, this.words.Count)];
		Debug.WriteLine(this.answer);
	}

	private void CalculateWord(string answer, List<Char> guessed)
	{
		List<char> temp =
			answer.Select(word => (guessed.IndexOf(word) >= 0 ? word : '_'))
			.ToList();

		this.SpotLight = string.Join(' ', temp);
	}

	#endregion

	private void Button_Clicked(object sender, EventArgs e)
	{

		Button button = sender as Button; 

		if (button == null)
			return; 

		button.IsEnabled = false;
		string letter = button.Text.ToLower();
		Debug.WriteLine($"{letter}");
		HandleGuess(letter.FirstOrDefault());
	}

	private void HandleGuess(char letter)
	{
		Debug.WriteLine($"{letter}");

		if (this.guessed.IndexOf(letter) == -1)
		{
			this.guessed.Add(letter);
			Debug.WriteLine($"{this.guessed.Count}");

		}

		if (this.answer.IndexOf(letter) >= 0)
		{
			Debug.WriteLine($"Entro");
			this.CalculateWord(this.answer, this.guessed);
			this.CheckIfGameWon();
		}
		else if (this.answer.IndexOf(letter) == -1)
		{
			mistakes++;
			this.UpdateStatus();
			this.CheckIfGameLost();
			CurrentImage = $"Hangman/hangman{mistakes}.jpg";
		}
	}

	private void CheckIfGameLost()
	{
		if (mistakes == maxWrong)
		{
			Message = "You Lost!!";
			DisableLetters();
		}
	}

	private void UpdateStatus()
	{
		this.GameStatus = $"Errors: {mistakes} of {maxWrong}";
	}

	private void CheckIfGameWon()
	{
		Debug.WriteLine($"answer: {this.answer}");
		Debug.WriteLine($"SpotLight: {this.SpotLight}"); 


		if (this.answer == this.SpotLight.Replace(" ", ""))
		{
			this.Message = "You Won!";
			this.DisableLetters(); 
		}
	}
	private void DisableLetters()
	{
		foreach (var children in LettersContainer.Children)
		{
			var btn = children as Button;
			if (btn != null)
			{
				btn.IsEnabled = false;
			}
		}
	}
	private void EnableLetters()
	{
		foreach (var children in LettersContainer.Children)
		{
			var btn = children as Button;
			if (btn != null)
			{
				btn.IsEnabled = true;
			}
		}
	}

	private void Reset_Clicked(object sender, EventArgs e)
     {
          mistakes = 0;
          guessed = new List<char>();
          CurrentImage = "Hangman/hangman0.jpg";
          PickWord();
          CalculateWord(answer, guessed);
          Message = "";
          UpdateStatus();
          EnableLetters();
     }
}