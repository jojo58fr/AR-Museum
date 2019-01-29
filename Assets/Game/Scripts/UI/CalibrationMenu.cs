using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class CalibrationMenu : SimpleMenu<CalibrationMenu>
{

	public void Start()
	{

        foreach (TriggerCalibrate trigger in FindObjectsOfType<TriggerCalibrate>())
		{
			trigger.StartGlowing();
		}

	}

    public override void OnBackPressed()
	{
		AboutMenu.Close();
	}

	public void Update()
	{
		if(GameObject.Find("Point") == null)
		{
			TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
			text.text = "Calibration complete !";
			StartCoroutine(WaitingDestroy(4));
			
		}
	}

    IEnumerator WaitingDestroy(float timeLeft)
	{
		yield return new WaitForSeconds(timeLeft);
		CalibrationMenu.Close();
	}
}
