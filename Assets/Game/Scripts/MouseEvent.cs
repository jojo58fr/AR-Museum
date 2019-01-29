using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseEvent : MonoBehaviour
{

	private float waitingTime = 0.5f;
	private float currentTime = 0f;
	private bool startedCoroutine = false;

    // Use this for initialization
    void Start()
    {
		currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log(currentTime);
        GetComponentInChildren<Slider>().transform.position = new Vector2(Input.mousePosition.x + 18f, Input.mousePosition.y - 18f);//Input.mousePosition;

		if(currentTime >= waitingTime)
		{
			GameObject[] objects = RaycastMouse("Interactable").ToArray();
			if(objects.Length > 0)
			{
				if(!startedCoroutine)
				{
					startedCoroutine = true;
					StartCoroutine(CoroutineMouseHover(objects[0],1.5f));
				}

			}

		}
		else
		{
			currentTime += Time.deltaTime;
		}

    }

	public List<GameObject> RaycastMouse(){
		
		PointerEventData pointerData = new PointerEventData (EventSystem.current)
		{
			pointerId = -1,
		};
		
		pointerData.position = Input.mousePosition;

		List<RaycastResult> raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll(pointerData, raycastResults);
		
		//Debug.Log( results.Count);
		
		List<GameObject> results = new List<GameObject>();

		foreach(RaycastResult raycast in raycastResults)
		{
			results.Add(raycast.gameObject);
		}

		return results;
	}

	public List<GameObject> RaycastMouse(string tag){
		
		List<GameObject> results = new List<GameObject>();

		foreach(GameObject go in RaycastMouse())
		{
			if(go.tag == "Interactable")
			{
				results.Add(go);
			}
		}

		return results;
	}

    IEnumerator CoroutineMouseHover(GameObject target, float timeLeft)
    {
		Slider slider = GetComponentInChildren<Slider>();

		float time = 0f;
		while (time < timeLeft && RaycastMouse("Interactable").Contains(target)) 
		{
			time += Time.deltaTime;
			slider.value = Mathf.Lerp(slider.minValue, slider.maxValue, (slider.maxValue / timeLeft) * time );
			yield return null;
		}

		if(slider.value >= slider.maxValue)
		{
			target.GetComponent<Button>().onClick.Invoke();
		}

		slider.value = slider.minValue;
		currentTime = 0f;
		startedCoroutine = false;
    }

}
