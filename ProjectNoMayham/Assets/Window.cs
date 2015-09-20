using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

    SpriteRenderer m_apocalypse;

	// Use this for initialization
	void Start () {
        m_apocalypse = GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Score.Total < 0)
        {
            m_apocalypse.enabled = true;
        }
        else
        {
            m_apocalypse.enabled = false;
        }
	}
    
}
