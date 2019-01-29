using UnityEngine;
using TMPro;

public class IntroMenu : SimpleMenu<IntroMenu>
{

    public override void OnBackPressed()
	{
		IntroMenu.Close();
	}

	public void PageUp(GameObject textContainer)
	{
		TextMeshProUGUI text = textContainer.GetComponent<TextMeshProUGUI>();

		if(text.pageToDisplay < text.textInfo.pageCount)
		{
			text.pageToDisplay++;
		}

	}

	public void PageDown(GameObject textContainer)
	{
		TextMeshProUGUI text = textContainer.GetComponent<TextMeshProUGUI>();

		if(text.pageToDisplay > 0)
		{
			text.pageToDisplay--;
		}

	}
}
