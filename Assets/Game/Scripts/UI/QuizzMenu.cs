using UnityEngine.UI;

public class QuizzMenu : SimpleMenu<QuizzMenu>
{

    public override void OnBackPressed()
	{
		QuizzMenu.Close();
	}

	public void OnQuizzPressed()
	{
		QuizzMenu.Close();
		ResultMenu.Show();
	}
}
