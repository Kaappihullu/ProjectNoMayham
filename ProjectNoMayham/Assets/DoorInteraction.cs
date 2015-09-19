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
            // Door open
            secretary.SetActive(true);
            secretary.GetComponent<ScaleAnimation>().StartAnimation();
            BoxCollider2D bc = GetComponent<BoxCollider2D>();
            bc.size = new Vector2(bc.size.x * 2, bc.size.y);
            bc.offset = new Vector2(bc.offset.x * 2, bc.offset.y);
        }
        else if (state == 0)
        {
            // Door closed
            secretary.GetComponent<ScaleAnimation>().StopAnimation();
            secretary.SetActive(false);
            BoxCollider2D bc = GetComponent<BoxCollider2D>();
            bc.size = new Vector2(bc.size.x / 2, bc.size.y);
            bc.offset = new Vector2(bc.offset.x / 2, bc.offset.y);
        }
    }
}
