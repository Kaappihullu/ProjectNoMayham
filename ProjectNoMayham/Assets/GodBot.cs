﻿using UnityEngine;
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

        switch (Random.Range(0, 13))
        {
            case 0:
            case 1:
            case 3:
                EmailBot.SendEmail();
                break;
            case 4:
            case 5:
            case 6:
                PhoneBot.GetPhoneBot().MakeCall(Random.Range(10f,180f));
                break;
            case 7:
            case 8:
            case 9:
                PaperMailTube.GetPaperMailTube().Send(Random.Range(20f,360f));
                break;
            case 10:// jackpot!! double event!
                LaunchEvent();
                LaunchEvent();
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
