﻿using UnityEngine;
using System.Collections;

public class PhoneBot : MonoBehaviour 
{

    private static PhoneBot m_phoneBot = null;

    public float CallMinDuration = 10f;
    public float CallMaxDuration = 50f;

    private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();

    private float m_currentCallDuration = 0f;


    public void MakeCallNow()
    {

        if (m_currentCallDuration == 0f && Phone.GetPhone().State == PhoneState.Idle)
        {
            m_currentCallDuration = Random.Range(CallMinDuration,CallMaxDuration);

            Phone.GetPhone().Ring();
            m_stopwatch.Start();

        }
        else
        {
            GodBot.GetGodBot().LaunchEvent();
        }

    }

    public void MakeCall(float time)
    {
        Invoke("MakeCallNow",time);
    }

	// Use this for initialization
	void Start () 
    {
        m_phoneBot = this;
        //m_stopwatch.Start();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (m_currentCallDuration != 0f && m_stopwatch.Elapsed.TotalSeconds > m_currentCallDuration)
        {
            //Mayor didnt answer SEND MAIL!
            if (Phone.GetPhone().State == PhoneState.Ring)
            {
                Phone.GetPhone().Hangup();

                GodBot.GetGodBot().LaunchEvent();

                m_stopwatch.Stop();
                m_stopwatch.Reset();

            }

            m_currentCallDuration = 0f;
        }
	}

    public static PhoneBot GetPhoneBot()
    {
        return m_phoneBot;
    }

}
