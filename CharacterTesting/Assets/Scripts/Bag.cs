using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour {

	public List<GameObject> weaponSlots;
	public int maxWeapons = 2;

	public bool weaponsFull = false;

	// Use this for initialization
	void Start ()
	{
		weaponSlots = new List<GameObject>();

	}

	public void IsBagFull ()
	{
		if (weaponSlots.Count == maxWeapons) {
			weaponsFull = true;
		}
	}

	public void Update ()
	{

	}
}
