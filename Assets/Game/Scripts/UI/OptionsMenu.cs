using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : SimpleMenu<OptionsMenu>
{
	public override void OnBackPressed()
	{
		//Debug.Log("Hey !!!!!!");
		OptionsMenu.Close();
	}


	public void OnLanguageButtonPressed()
	{
		Debug.Log("Language selected: ");
	}

	public void OnAboutButtonPressed()
	{
		OptionsMenu.Close();
		AboutMenu.Show();
	}

	public void OnIntroButtonPressed()
	{
		OptionsMenu.Close();
		IntroMenu.Show();
	}

	public void OnCalibrateButtonPressed()
	{
		OptionsMenu.Close();
		CalibrationMenu.Show();
	}
}
