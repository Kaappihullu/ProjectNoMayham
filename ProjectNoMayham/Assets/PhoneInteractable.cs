using UnityEngine;
using System.Collections;

public class PhoneInteractable : SpriteInteraction 
{


    public override void Interact()
    {
        base.Interact();

        if (state == 0)
        {
            Phone.GetPhone().Hangup();
        }
        else if (state == 1)
        {
            Phone.GetPhone().Answer();
        }
    }

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
