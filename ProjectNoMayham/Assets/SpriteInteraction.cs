using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]
public class SpriteInteraction : MonoBehaviour {

    public Sprite[] ToggleStates;

    public SpriteRenderer SpriteObject;
    int state = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log(state);
        interact();
    }

    private void interact()
    {
        ToggleNextState();
    }

    public void ToggleNextState()
    {
        state++;
        if (state >= ToggleStates.Length)
            state = 0;
        SpriteObject.sprite = ToggleStates[state];


    }
}
