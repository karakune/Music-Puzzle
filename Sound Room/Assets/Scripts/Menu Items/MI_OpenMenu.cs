using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MI_OpenMenu : MenuItem {

	public bool isMenuOpen;
	public GameObject[] menuItems;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Navigate()
    {
		Debug.Log("Opening menu!");
        isMenuOpen = !isMenuOpen;
		SetItemsActive(isMenuOpen);
    }

	private void SetItemsActive(bool isActive)
	{
		foreach (GameObject mi in menuItems)
		{
			mi.SetActive(isActive);
		}
	}
}
