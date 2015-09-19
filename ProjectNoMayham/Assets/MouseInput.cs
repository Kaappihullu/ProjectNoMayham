using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour
{

    public static Vector3 WorldPosition
    {
        get
        {
            return (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }
    }
}
