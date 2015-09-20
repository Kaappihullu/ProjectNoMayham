using UnityEngine;
using System.Collections;

public class PaperMailTube : MonoBehaviour {


    private static PaperMailTube m_paperMailTube;

    public delegate void IncomingMailAction();

    public event IncomingMailAction OnIncomingPaperMail = null;

	// Use this for initialization
	void Start () 
    {
        m_paperMailTube = this;
        Send(5f);
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SendNow()
    {
        if (OnIncomingPaperMail != null)
        {
            OnIncomingPaperMail();
        }
        Score.Calc(-1);
        Spawner.Spawn("Prefabs/Envelope");

    }

    public void Send(float time)
    {
        Invoke("SendNow", time);
    }

    public static PaperMailTube GetPaperMailTube()
    {
        return m_paperMailTube;
    }

}
