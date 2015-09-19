using UnityEngine;
using System.Collections;

public class Phone : MonoBehaviour 
{

    private static Phone m_phone = null;

    private PhoneState m_state = PhoneState.Idle;

    public delegate void PhoneStateAction();

    public event PhoneStateAction OnPhoneStateChangeEvent;

	// Use this for initialization
	void Start () 
    {
        m_phone = this;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    public PhoneState State
    {

        private set
        {
            m_state = value;
            if (OnPhoneStateChangeEvent != null)
            {
                OnPhoneStateChangeEvent();
            }
        }
        get
        {
            return m_state;
        }
    }


    public void Answer()
    {
        if (State == PhoneState.Ring)
        {
            State = PhoneState.Ongoing;
        }
    }

    public void Ring()
    {
        if (State == PhoneState.Idle)
        {
            State = PhoneState.Ring;
        }
    }

    public void Hangup()
    {
        if (State == PhoneState.Ongoing || State == PhoneState.Ring)
        {
            State = PhoneState.Idle;
        }
    }

    public static Phone GetPhone()
    {
        return m_phone;
    }

}

public enum PhoneState
{
    Idle,
    Ring,
    Ongoing,
}
