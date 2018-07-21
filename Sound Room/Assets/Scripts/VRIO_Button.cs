using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRIO_Button : VRInteractableObject
{
    public EVRButtonId buttonToTrigger = EVRButtonId.k_EButton_SteamVR_Trigger;
    public Transform button;
    public Vector3 currentButtonDestination;
    public float buttonClickSpeed;
    public Vector3 buttonStartPos;
    public Vector3 buttonDownPos;


    protected void MethodToTrigger()
    {
        //This method will be called any time the button is pressed,
        //and the event is Invoked. Note that since the event is static,
        //this method will fire any time ANY button of that type is pressed.
        if (CompareTag("Reader Button"))
        {
            GameObject.Find("Reader").GetComponent<Reader>().Read();
        }
        else if (CompareTag("Generator Button"))
        {
            GameObject.Find("Sound Generator").GetComponent<SoundGenerator>().SpawnSoundWave();
        }
        else if (CompareTag("Both Button"))
        {
            GameObject.Find("Reader").GetComponent<Reader>().Read();
            GameObject.Find("Sound Generator").GetComponent<SoundGenerator>().SpawnSoundWave();
        }
        else 
        {
            Debug.LogError("This button's tag is missing or there's no action configured for it.");
        }
    }

    public void Update()
    {
        //Check to see if button is in the same position as its destination position
        if (button.localPosition != currentButtonDestination)
        {
            //If its not, lerp toward it at a predefined speed.
            //Remember to multiply movements in Update by Time.deltaTime, so that things don't move faster 
            //on computers with higher framerates
            Vector3 position = Vector3.MoveTowards(button.localPosition, currentButtonDestination, buttonClickSpeed * Time.deltaTime);
            button.localPosition = position;
        }
    }

    public override void ButtonPressDown(EVRButtonId button, VRControllerInput controller)
    {
        //If button is desired "trigger" button
        if (button == buttonToTrigger)
        {
            //Set button's destination position to the "down" position
            currentButtonDestination = buttonDownPos;

            MethodToTrigger();

        }
    }

    public override void ButtonPressUp(EVRButtonId button, VRControllerInput controller)
    {
        //Set button's destination position to the "up" position
        if (button == buttonToTrigger)
        {
            currentButtonDestination = buttonStartPos;
        }
    }


}
