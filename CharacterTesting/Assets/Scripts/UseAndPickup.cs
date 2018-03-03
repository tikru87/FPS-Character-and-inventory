using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAndPickup : MonoBehaviour {

	private Bag pB;
	private Eyes eyes;
	private Animator anim;

	private Transform weaponSlot;
	private GameObject weaponInHand, otherWeapon;

	private string wIHandName;
	private Bag pBag;


	void Start () {

		pB = GetComponent<Bag>();
		eyes = FindObjectOfType<Camera>().GetComponent<Eyes>();
		pBag = GameObject.FindGameObjectWithTag("Player").GetComponent<Bag>();
		weaponSlot = GameObject.FindGameObjectWithTag("WeaponSlot").transform;
		anim = GetComponentInChildren<Animator>();
	}
	
	void PickUpItem ()
	{
		if (Input.GetButtonDown ("UseAndGrab") && pB.weaponsFull == false && eyes.weaponInRange == true) {
			string weaponName = eyes.hit.transform.name;
			pB.weaponSlots.Add(Resources.Load("Weapons/" + weaponName)as GameObject);
			Destroy(eyes.hit.transform.gameObject);
//			EquipWeapon();
			pB.IsBagFull();
		} else if (Input.GetButtonDown ("UseAndGrab") && pB.weaponsFull == true && eyes.weaponInRange == true) {
			Debug.Log("Bag is Full");
		}
	}
	public void ScrollWeapons ()
	{

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 || Input.GetAxis ("Mouse ScrollWheel") < 0) {
			pBag.weaponSlots.Reverse ();
			foreach (GameObject weapon in pBag.weaponSlots) {
				Debug.Log (weapon.name);
			}
			foreach (GameObject weapon in pBag.weaponSlots) {
				if (pBag.weaponSlots.IndexOf (weapon) == 0) {
					anim.SetTrigger("equip");
					Destroy(weaponInHand);
					wIHandName = weapon.name;
					weaponInHand = Instantiate (Resources.Load ("Weapons/" + wIHandName), weaponSlot.transform.position, weaponSlot.transform.rotation) as GameObject;
					weaponInHand.GetComponent<Rigidbody> ().isKinematic = true;
					weaponInHand.tag = "Equipped";
					weaponInHand.transform.SetParent (weaponSlot, true);

				}

			}
		}
	}

	void FixedUpdate () {
	PickUpItem();
	ScrollWeapons();
	Debug.Log(weaponSlot.transform.position);
	}
}
