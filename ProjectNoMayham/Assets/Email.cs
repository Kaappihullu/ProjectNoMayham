using UnityEngine;
using System.Collections;

public class Email : MonoBehaviour 
{

    public const int RESPONSE_DISSMISS = 0;
    public const int RESPONSE_FORWARD = 1;
    public const int RESPONSE_OPEN = 2;

    private string m_topic;
    private int m_correctResponse;
    private float m_autoDissmissTimeout;

    private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();

    public void Init(string topic, int correctResponse, float autoDissmissTimeout)
    {
        m_topic = topic;
        m_correctResponse = correctResponse;
        m_autoDissmissTimeout = autoDissmissTimeout;
    }

    //todo: implement.
    public static Email SpawnEmail()
    {
        return null;
    }

	// Use this for initialization
	void Start () 
    {
        m_stopwatch.Start();
	}

    public void Handle(int response)
    {
        if (response != m_correctResponse)
        {

        }
        m_stopwatch.Stop();
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        if (m_stopwatch.Elapsed.TotalSeconds > m_autoDissmissTimeout)
        {
            Handle(RESPONSE_DISSMISS);
        }
	}
}
