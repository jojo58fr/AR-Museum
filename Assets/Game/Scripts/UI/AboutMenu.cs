using UnityEngine.UI;

public class AboutMenu : SimpleMenu<AboutMenu>
{

    public override void OnBackPressed()
	{
		AboutMenu.Close();
	}
}
