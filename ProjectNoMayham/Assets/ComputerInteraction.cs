using UnityEngine;
using System.Collections;
using System;

public class ComputerInteraction : MonoBehaviour {

    public int EmailFetchCount;
    private int m_emails;
    public UnityEngine.UI.Text TextObject;    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        int emails = Computer.GetComputer().GetEmailCount();
        
        if (emails > 0)
        {
            if (emails > m_emails)
            {
                //TODO: Notify messages
                Debug.Log("New messages!!");
            }

            TextObject.text = "You have " + emails + " new messages!";
        }
        else if (emails == 0)
        {
            TextObject.text = "You have no new messages :'(";
        }

        m_emails = emails;
	}

    void OnMouseDown()
    {
        Interact();
    }

    public void Interact()
    {

        Email[] emails = Computer.GetComputer().GetEmails(1);
        Debug.Log(emails.Length);
        if (emails.Length > 0)
        {
            Computer.GetComputer().ReadMessage(emails[0]);
        }
    }
}
