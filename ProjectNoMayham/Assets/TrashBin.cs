using UnityEngine;
using System.Collections;

public class TrashBin : DropZone {

    public AudioClip[] clips;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Interact(GameObject interactor)
    {
        base.Interact(interactor);
        if (interactor.name.StartsWith("Envelope"))
        {
            GameObject.Destroy(interactor);
            Score.Calc(1);
            Debug.Log("Letter Destroyed");
            PlayRandomClip();
        }
    }

    public void PlayRandomClip()
    {
        int i = Random.Range(0, clips.Length);

        AudioSource.PlayClipAtPoint(clips[i], Vector3.zero);
    }
}
