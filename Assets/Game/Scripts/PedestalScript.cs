using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestalScript : MonoBehaviour {

	public float horizontalSpeed = 2.0F; 
	public float verticalSpeed = 2.0F; 
	public float angle = 45.0f;

	// Use this for initialization
	void Start () {
		
	}
	
    void Update()
	{
		if (Input.GetMouseButton(0))
		{
			MouseSpin();
		}

		if (Input.GetMouseButtonDown(1))
		{
			this.transform.rotation = Quaternion.identity;
		}
	}
 
     void MouseSpin()
     {
         float h = horizontalSpeed * Input.GetAxis("Mouse X");
         this.transform.Rotate(0, h, 0);
     }
 
 
}
