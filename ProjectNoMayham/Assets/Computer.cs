using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Computer : MonoBehaviour 
{

    private static Computer m_computer = null;

    private List<Email> m_emails = new List<Email>();

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
        m_emails.Add(email);
    }

    private void emptyNulls()
    {
        for (int i = 0; i < m_emails.Count; i++)
        {
            if (m_emails[i] == null)
            {
                m_emails.RemoveAt(i);
                i--;
            }
           
        }
    }

    public Email[] GetEmails(int count)
    {
        emptyNulls();

        List<Email> firstEmails = new List<Email>();


        foreach (Email email in m_emails) 
        {
            firstEmails.Add(email);

            if (firstEmails.Count == count)
            {
                break;
            }
        }
        return firstEmails.ToArray();
    }

    public static Computer GetComputer()
    {
        return m_computer;
    }

}
