using UnityEngine;
using System.Collections;

public class ScaleAnimation : MonoBehaviour {
    public Vector3 startScale = new Vector3 (0.5f,0.5f,1f);
    public Vector3 endScale = new Vector3(1.5f,1.5f,1f);
    public float animationLenght = 5;
    public bool playing = false;
    public bool finished = false;
	// Use this for initialization
	void Start () {
        StartAnimation();
	}
	
	// Update is called once per frame
	void Update () {

        if (playing)
        {
            Vector3 scale = transform.localScale;
            scale = Vector3.Min(scale + (endScale - startScale) / animationLenght * Time.deltaTime, endScale);
            if (scale.Equals(endScale))
            {
                StopAnimation();
                finished = true;
            }
            transform.localScale = scale;
        }
	
	}

    public void StartAnimation()
    {
        transform.localScale = startScale;
        playing = true;
        finished = false;
    }

    public void StopAnimation()
    {
        playing = false;
    }
}
