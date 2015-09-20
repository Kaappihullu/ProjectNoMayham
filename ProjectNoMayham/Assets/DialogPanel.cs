using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour {

    private static DialogPanel m_singleton;
    public Button OkButton;
    public Button DismissButton;
    public Text DialogText;

    public delegate void DialogResolution(bool resolution);
    public event DialogResolution OnDialogResolvedEvent;

    private string m_content;
    private string m_ok;
    private string m_dismiss;

    // Use this for initialization
    void Awake()
    {
        m_singleton = this;
    }
    void Start () {
        
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnAccept()
    {
        hideDialog();
        if (OnDialogResolvedEvent != null)
        {
            OnDialogResolvedEvent(true);
        }
    }

    public void OnDismiss()
    {
        hideDialog();
        if (OnDialogResolvedEvent != null)
        {
            OnDialogResolvedEvent(false);
        }
    }

    public static DialogPanel GetDialogPanel()
    {
        return m_singleton;
    }

    public static void CreateDialog(string content, string ok, string dismiss)
    {
        m_singleton.gameObject.SetActive(true);
        m_singleton.m_content = content;
        m_singleton.m_dismiss = dismiss;
        m_singleton.m_ok = ok;

        m_singleton.Invoke("CreateDialog", 0.2f);

      
    }

    private void createDialog()
    {
        DialogText.text = m_content;

        if (m_ok == "")
        {
            OkButton.enabled = false;
        }
        else
        {
            OkButton.enabled = true;
            OkButton.GetComponentInChildren<Text>().text = m_ok;
        }


        if (m_dismiss == "")
        {
            DismissButton.enabled = false;
        }
        else
        {
            DismissButton.enabled = true;
            DismissButton.GetComponentInChildren<Text>().text = m_dismiss;
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
