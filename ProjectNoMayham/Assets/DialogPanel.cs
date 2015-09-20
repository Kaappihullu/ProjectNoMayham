using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour {

    private static DialogPanel m_singleton;
    public Button OkButton;
    public Button DismissButton;
    public Text DialogText;

	// Use this for initialization
	void Start () {
        m_singleton = this;
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnAccept()
    {

        hideDialog();
    }

    public void OnDismiss()
    {
        hideDialog();
    }

    public DialogPanel GetDialogPanel()
    {
        return m_singleton;
    }

    public static void CreateDialog(string content, string ok, string dismiss)
    {
        m_singleton.DialogText.text = content;
        m_singleton.gameObject.SetActive(true);

        if (ok == "")
        {
            m_singleton.OkButton.enabled = false;
        }
        else
        {
            m_singleton.OkButton.enabled = true;
            m_singleton.OkButton.GetComponentInChildren<Text>().text = ok;
        }


        if (dismiss == "")
        {
            m_singleton.DismissButton.enabled = false;
        }
        else
        {
            m_singleton.DismissButton.enabled = true;
            m_singleton.DismissButton.GetComponentInChildren<Text>().text = dismiss;
        }       

    }

    public static void CreateDialog(string content, string ok)
    {
        CreateDialog(content, ok, "");
    }

    private void hideDialog()
    {
        m_singleton.gameObject.SetActive(false);
    }
}
