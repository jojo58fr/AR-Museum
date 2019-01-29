using UnityEngine.UI;

public class ResultMenu : SimpleMenu<ResultMenu>
{

    public override void OnBackPressed()
	{
		ResultMenu.Close();
	}

}
