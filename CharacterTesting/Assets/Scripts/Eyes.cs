using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eyes : MonoBehaviour {

	public bool weaponInRange = false;
	public Text hintText;

	private Camera cam;
	public RaycastHit hit;
	public Ray ray;


	private float pickUpRange = 2f;
	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();

	}
	
	// Update is called once per frame
	public void Update ()
	{
		Debug.DrawRay (transform.position, transform.forward, Color.blue);
		ray = cam.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, pickUpRange) && hit.transform.tag == "Weapon") {
			weaponInRange = true;
			hintText.text = hit.transform.name; 
		} else {
			weaponInRange = false;
			hintText.text = null;
		}
	}
}
