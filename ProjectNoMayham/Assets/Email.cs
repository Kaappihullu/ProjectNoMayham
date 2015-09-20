using UnityEngine;
using System.Collections;

public class Email 
{

    public const int RESPONSE_DISSMISS = 0;
    public const int RESPONSE_FORWARD = 1;
    public const int RESPONSE_OPEN = 2;

    private string m_topic;
    private int m_correctResponse;
    private float m_autoDissmissTimeout;

    private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();


    public Email()
    {

    }

    public void Init(string topic, int correctResponse, float autoDissmissTimeout)
    {

        m_stopwatch.Start();

        m_topic = topic;
        m_correctResponse = correctResponse;
        m_autoDissmissTimeout = autoDissmissTimeout;
    }

    //todo: implement.
    public static Email SpawnEmail()
    {
        return new Email();
    }


    public void Handle(int response)
    {
        if (response != m_correctResponse)// What? Who decided to send construction workers to burning buildings and firemen to falling building... Mayor needs to know about this, need to call him. in a minute
        {
            GodBot.GetGodBot().LaunchEvent();
            //PhoneBot.GetPhoneBot().MakeCall(Random.Range(20f,180f));
        }
        m_stopwatch.Stop();
    }

    public bool IsLate
    {
        get
        {
            return m_stopwatch.Elapsed.TotalSeconds > m_autoDissmissTimeout;
        }
    }

    public string Topic
    {
        get
        {
            return m_topic;
        }
    }

	// Update is called once per frame
	/*void FixedUpdate () 
    {
        if (m_stopwatch.Elapsed.TotalSeconds > m_autoDissmissTimeout)
        {
            Handle(RESPONSE_DISSMISS);
        }
	}*/
}
