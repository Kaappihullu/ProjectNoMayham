using UnityEngine;
using System.Collections;

public class DoorInteraction : SpriteInteraction {

    GameObject secretary;
	// Use this for initialization
	void Start () {
        secretary = GameObject.Find("secretary");
        secretary.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override void Interact()
    {
        base.Interact();
        if (state == 1)
        {
            secretary.SetActive(true);
            secretary.GetComponent<ScaleAnimation>().StartAnimation();
        }
        else if (state == 0)
        {
            secretary.GetComponent<ScaleAnimation>().StopAnimation();
            secretary.SetActive(false);
        }
    }
}
