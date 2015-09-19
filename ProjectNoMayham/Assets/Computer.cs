using UnityEngine;
using System.Collections;

public class Computer : MonoBehaviour 
{

    private static Computer m_computer = null;


	// Use this for initialization
	void Start ()
    {
        m_computer = this;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void ReceiveEmail(Email email)
    {

    }

    public static Computer GetComputer()
    {
        return m_computer;
    }

}
