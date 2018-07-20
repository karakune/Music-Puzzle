using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRIO_Parented : VRInteractableObject {


	public EVRButtonId pickupButton = EVRButtonId.k_EButton_SteamVR_Trigger;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
public override void ButtonPressDown(EVRButtonId button, VRControllerInput controller)
{
	//If pickup button was pressed
	if (button == pickupButton)
		Pickup(controller);
}
 
public override void ButtonPressUp(EVRButtonId button, VRControllerInput controller)
{
	//If pickup button was released
	if (button == pickupButton)
		Release(controller);
}
}
