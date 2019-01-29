using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInterface : SimpleMenu<UserInterface>
{

    public void OnOptionsPressed()
    {
		OptionsMenu.Show();
	}

	public override void OnBackPressed()
	{
		Application.Quit();
	}

}