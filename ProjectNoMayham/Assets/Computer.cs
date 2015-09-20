using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Computer : MonoBehaviour 
{

    private static Computer m_computer = null;
    private Email m_reading = null;

    private List<Email> m_emails = new List<Email>();

	// Use this for initialization
	void Start ()
    {
        m_computer = this;
        DialogPanel.GetDialogPanel().OnDialogResolvedEvent += OnDialogResolved;
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
            if (m_emails[i].IsLate)
            {
                m_emails.RemoveAt(i);
                i--;
            }
           
        }
    }

    public int GetEmailCount()
    {

        emptyNulls();

        return m_emails.Count;
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

    public void ReadMessage(Email mail)
    {
        Debug.Log("Reading Message");
        if (m_reading == null)
        {
            m_reading = mail;
            m_emails.Remove(mail);
            DialogPanel.CreateDialog(mail.GetFullEmailString(), "Forward", "Delete");            
        }
        
    }

    public void DeleteReadMessage()
    {
        m_reading = null;
        //DialogPanel.GetDialogPanel().OnDialogResolvedEvent -= OnDialogResolved;
    }

    public void OnDialogResolved(bool okPressed)
    {
        if (m_reading != null && okPressed)
        {

        }
    }

}
