using UnityEngine;
using System.Collections;

public class DoorInteraction : SpriteInteraction {

    GameObject secretary;
    public AudioSource openAudio;
    public AudioSource lockDoorAudio;
    bool playLockAudio = false;
	// Use this for initialization
	void Start () {
        secretary = GameObject.Find("secretary");
        secretary.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (playLockAudio && !openAudio.isPlaying)
        {
            playLockAudio = false;
            lockDoorAudio.Play();
        }
	}

    public override void Interact()
    {
        base.Interact();
        if (state == 1)
        {
            Open();
        }
        else if (state == 0)
        {
            Close();
        }
    }

    public void Open()
    {
        openAudio.Play();
        // Door open
        if (!Secretary.IsDistracted)
        {
            secretary.SetActive(true);
            secretary.GetComponent<ScaleAnimation>().StartAnimation();
        }        
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(bc.size.x * 2, bc.size.y);
        bc.offset = new Vector2(bc.offset.x * 2, bc.offset.y);
    }

    public void Close()
    {
        openAudio.Play();
        playLockAudio = true;        
        // Door closed
        secretary.GetComponent<ScaleAnimation>().StopAnimation();
        secretary.SetActive(false);
        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = new Vector2(bc.size.x / 2, bc.size.y);
        bc.offset = new Vector2(bc.offset.x / 2, bc.offset.y);
    }
}
