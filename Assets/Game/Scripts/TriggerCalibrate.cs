using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerCalibrate : MonoBehaviour 
{

	// Use this for initialization
	void Start () {

		StartGlowing();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerButtonDown()
	{
		Destroy(this.gameObject);
	}

	public void StartGlowing()
	{
		StartCoroutine(Fade(0.25f));
	}

	IEnumerator Fade(float maxtime) 
	{
		Image image = GetComponent<Image>();
		while(true)
		{
			for (float f = image.color.a; f >= 0; f -= 0.1f) 
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, f);
				yield return new WaitForSeconds(0.075f);
			}
			yield return new WaitForSeconds(maxtime);
			for (float f = image.color.a; f <= 1; f += 0.1f) 
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, f);
				yield return new WaitForSeconds(0.075f);
			}
		}

	}

}
