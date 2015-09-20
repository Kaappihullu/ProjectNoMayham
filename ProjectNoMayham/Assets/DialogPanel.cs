using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class DialogPanel : MonoBehaviour
{

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
        Debug.Log("Awake");
    }
    void Start()
    {
        Debug.Log("start!");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnAccept()
    {
        HideDialog();
        if (OnDialogResolvedEvent != null)
        {
            OnDialogResolvedEvent(true);
        }
    }

    public void OnDismiss()
    {
        HideDialog();
        if (OnDialogResolvedEvent != null)
        {
            OnDialogResolvedEvent(false);
        }
    }

    public static DialogPanel GetDialogPanel()
    {
        return m_singleton;
    }

    public static DialogPanel CreateDialog(string content, string ok, string dismiss)
    {
        if (m_singleton == null)
        {
            DialogPanel dialog = ((GameObject)GameObject.Instantiate(Resources.Load("Prefabs/DialogPanel"))).GetComponent<DialogPanel>();
            GameObject canvas = GameObject.Find("OverlayCanvas");
            dialog.transform.SetParent(canvas.transform, false);

            dialog.m_content = content;
            dialog.m_dismiss = dismiss;
            dialog.m_ok = ok;
            m_singleton = dialog;
            dialog.CreateDialog();
        }

        return m_singleton;
    }

    public void CreateDialog()
    {
        //Debug.Log("Pip!");
        //m_singleton.gameObject.SetActive(true);
        //yield return 0;
        Debug.Log("Pop!");
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

    public void CreateDialog(string content, string ok)
    {
        CreateDialog(content, ok, "");
    }

    public void HideDialog()
    {
        //gameObject.SetActive(false);
        GameObject.Destroy(this.gameObject);
    }
    //public void ShowDialog()
    //{
    //    m_singleton.gameObject.SetActive(true);
    //}
}
