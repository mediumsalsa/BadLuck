using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;

    private void Start()
    {
        Instantiate(brick);
    }
}
