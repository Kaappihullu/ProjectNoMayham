using UnityEngine;
using System;

class Spawner
{

    public static T Spawn<T>(string path) where T : MonoBehaviour
    {
        return ((GameObject)MonoBehaviour.Instantiate(Resources.Load(path))).GetComponent<T>();
    }

    public static GameObject Spawn(string path)
    {
        return (GameObject)GameObject.Instantiate(Resources.Load(path));
    }

}
