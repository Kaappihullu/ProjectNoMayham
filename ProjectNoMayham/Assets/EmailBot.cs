using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EmailBot : MonoBehaviour 
{

   // public float SendInterval = 10f;
   // public float SkipSendChance = 0.5f;

   // private System.Diagnostics.Stopwatch m_stopwatch = new System.Diagnostics.Stopwatch();

    private static List<Email> m_emails = new List<Email>();

	// Use this for initialization
	void Start () 
    {
      //  m_stopwatch.Start();
	}

    //Maybe implement prober name generator... meh.
    public static string GenerateTopic()
    {

        string[] topics = { "Urgent", "Important", "Only for you!", "You have won the spanish national lottery"
                            ,"People will die!", "Opportunity", "Cat pics", "need money?", "VIP Eyes only", "Beeutifull nudezz"
                          , "need permission","permission pending","another permission request", "for good cause"};


        return topics[Random.Range(0,topics.Length)];

    }

    public static void SendEmail()
    {

        Email email = Email.SpawnEmail();
        
        email.Init(GenerateTopic(),Random.Range(0,3),Random.Range(5f,30f));

        m_emails.Add(email);

        Computer.GetComputer().ReceiveEmail(email);

    }

	// Update is called once per frame
	void Update () 
    {


        for (int i = 0; i < m_emails.Count; i++)
        {
            if (m_emails[i].IsLate)
            {
                m_emails[i].Handle(Email.RESPONSE_DISSMISS);
                m_emails.RemoveAt(i);
            }
        }
        

   /*     if (m_stopwatch.Elapsed.TotalSeconds > SendInterval)
        {

            if (SkipSendChance >= Random.value)
            {
                SendEmail();
            }


            m_stopwatch.Reset();
            m_stopwatch.Start();
        }
        */
	}
}
