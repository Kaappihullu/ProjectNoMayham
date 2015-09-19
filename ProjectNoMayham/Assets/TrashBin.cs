using UnityEngine;
using System.Collections;

public class TrashBin : DropZone {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override void Interact(GameObject interactor)
    {
        base.Interact(interactor);
        if (interactor.name == "Enveloped")
        {
            GameObject.Destroy(interactor);
            Debug.Log("Letter Destroyed");
        }
    }
}
