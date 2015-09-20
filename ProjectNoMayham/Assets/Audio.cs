using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {

    public AudioClip[] Clips;

    private AudioSource m_source;

	// Use this for initialization
	void Start () 
    {
        m_source = gameObject.GetComponent<AudioSource>();

        m_source.clip = Clips[0];
        m_source.Play();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!m_source.isPlaying)
        {
            m_source.clip = Clips[1];
            m_source.loop = true;
            m_source.Play();
        }
	}
}
