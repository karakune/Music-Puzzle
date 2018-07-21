using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAreaTrigger : MonoBehaviour
{

    public string desiredNote;
    public bool isNoteValid;

    public List<GameObject> bouncersInTrigger;

    // Use this for initialization
    void Start()
    {
        switch (desiredNote)
        {
            case "A":
            case "B":
            case "C":
            case "C2":
            case "D":
            case "E":
            case "F":
            case "G":
                break;
            default:
                Debug.LogError("This note area trigger's desired note is either missing or invalid.");
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //if the object is actually a bouncer
        if (other.gameObject.tag.Contains("Bouncer "))
        {
            //if the bouncer isn't already in the bouncers list
			bool otherFound = false;
			foreach (GameObject g in bouncersInTrigger)
			{
				if (g == other.gameObject)
				{
					otherFound = true;
					break;
				}
			}
			if (!otherFound)
			{
				bouncersInTrigger.Add(other.gameObject);
			}
        }
        //if it's not a bouncer then we don't care
        else
        {
            return;
        }
		isNoteValid = IsNoteValid();
    }

    void OnTriggerExit(Collider other)
    {
		bouncersInTrigger.Remove(other.gameObject);
        isNoteValid = IsNoteValid();
    }

	bool IsNoteValid()
	{
		//if there's only one bouncer in the list
		if (bouncersInTrigger.Count == 1)
        {
			//if it's the right kind of bouncer
			if (bouncersInTrigger[0].CompareTag("Bouncer " + desiredNote))
			{
				return true;
			}
        }
        return false;
	}
}
