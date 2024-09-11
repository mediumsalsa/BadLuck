using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public int brickSpawnRate;
    private int tillNextBrick;
    private Vector2 brickSpawn;

    private void Start()
    {
        tillNextBrick = 0;
    }

    private void Update()
    {
        int brickRandomiser = Random.Range(-10, 10);

        brickSpawn = gameObject.transform.position;

        if (tillNextBrick >= brickSpawnRate)
        {
            tillNextBrick = 0;
            Instantiate(brick, new Vector2(brickSpawn.x + brickRandomiser, brickSpawn.y), Quaternion.identity);

        } else {
            tillNextBrick++;
        }

    }

}
