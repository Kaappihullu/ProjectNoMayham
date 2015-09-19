using UnityEngine;
using System.Collections;

public class GodBot : MonoBehaviour 
{

    private static GodBot m_godBot = null;

    public float EventRate = 15f;


    private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();

	// Use this for initialization
	void Start () 
    {
        m_godBot = this;
        m_stopwatch.Start();
	}


    public void LaunchEvent()
    {

        switch (Random.Range(0, 5))
        {
            case 0:
                EmailBot.SendEmail();
                break;
            case 1:
                PhoneBot.GetPhoneBot().MakeCall(Random.Range(10f,180f));
                break;
            case 3:
                PaperMailTube.GetPaperMailTube().Send(Random.Range(20f,360f));
                break;
            default://forget about it.
                break;
        }

    }

	// Update is called once per frame
	void Update () 
    {
        if (m_stopwatch.Elapsed.TotalSeconds > EventRate)
        {

            LaunchEvent();

            m_stopwatch.Reset();
            m_stopwatch.Start();
        }
	}


    public static GodBot GetGodBot()
    {
        return m_godBot;
    }

}
