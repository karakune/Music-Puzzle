using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallNote : MonoBehaviour {

	public NoteAreaTrigger associatedTrigger;
	public Material validMaterial;
	public Material invalidMaterial;

	void OnTriggerEnter(Collider other)
	{
		if (other.name == "Reader")
		{
			MeshRenderer mr = GetComponent<MeshRenderer>();
			if (!associatedTrigger.isNoteValid)
			{
				mr.material = invalidMaterial;
			}
			else
			{
				mr.material = validMaterial;
			}
			mr.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.name == "Reader")
		{
			GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
