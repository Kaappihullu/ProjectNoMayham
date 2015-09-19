using UnityEngine;
using System.Collections;

public class EmailBot : MonoBehaviour 
{

    public float SendInterval = 10f;
    public float SkipSendChance = 0.5f;

    private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();

	// Use this for initialization
	void Start () 
    {
        m_stopwatch.Start();
	}

    //Maybe implement prober name generator... meh.
    public static string GenerateTopic()
    {

        string[] topics = { "Urgent", "Important", "Only for you!", "You have won the spanish national lottery"
                            ,"People will die!", "Opportunity", "Cat pics", "need money?", "VIP Eyes only", "Beeutifull nudezz"
                          , "need permission","permission pending","another permission request"};


        return topics[Random.Range(0,topics.Length)];

    }

    public void SendEmail()
    {

        Email email = Email.SpawnEmail();
        
        email.Init(GenerateTopic(),Random.Range(0,3),Random.Range(5f,30f));

        Computer.GetComputer().ReceiveEmail(email);

    }

	// Update is called once per frame
	void Update () 
    {

        if (m_stopwatch.Elapsed.TotalSeconds > SendInterval)
        {

            if (SkipSendChance >= Random.value)
            {
                SendEmail();
            }


            m_stopwatch.Reset();
            m_stopwatch.Start();
        }

	}
}
