using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    static Singleton instance;

    //Destroys duplicate objects
    public void Start()
    {
        if (instance != null)
        {
            GameObject.Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
}
