using UnityEngine.UI;

public class VideoMenu : SimpleMenu<VideoMenu>
{

    public override void OnBackPressed()
	{
		VideoMenu.Close();
	}

	public void OnQuizzPressed()
	{
		VideoMenu.Close();
		QuizzMenu.Show();
	}
}
