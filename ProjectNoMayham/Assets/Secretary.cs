using UnityEngine;
using System.Collections;

public class Secretary : MonoBehaviour {

    private static bool m_distracted = false;
    public float hintDelay = 5f;
    ScaleAnimation m_anim;
	// Use this for initialization
	void Start () {
        m_anim = GetComponent<ScaleAnimation>();
        Invoke("SecretaryHint", hintDelay);
	}
	
	// Update is called once per frame
	void Update () {
	    if (m_anim.finished)
        {
            //gameover;
            GodBot.GetGodBot().LaunchEvent();
            Score.Calc(-10);
        }
	}

    public void SecretaryHint()
    {
        GameObject.Find("Door").GetComponent<DoorInteraction>().Open();
        GameObject.Find("Door").GetComponent<DoorInteraction>().ToggleNextState();
        DialogPanel.CreateDialog("She is holding stack of papers and mail, I must close the door! Do not let her in! I can’t deal with the morning news….", "Continue");
    }

    public static bool IsDistracted
    {
        get { return false; }
        set { m_distracted = value; }
    }
}
