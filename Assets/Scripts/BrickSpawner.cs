using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public int brickSpawnRate;
    private int tillNextBrick;
    private Vector2 brickSpawn;
    public int brickSpawnRange;
    public bool brickCanSpawn;

    private void Start()
    {
        tillNextBrick = 0;
    }

    private void Update()
    {
        int brickRandomiser = Random.Range(-brickSpawnRange, brickSpawnRange);

        brickSpawn = gameObject.transform.position;

        if (tillNextBrick >= brickSpawnRate)
        {
            tillNextBrick = 0;
            if (brickCanSpawn)
            {
                Instantiate(brick, new Vector2(brickSpawn.x + brickRandomiser, brickSpawn.y), Quaternion.identity);
            }

        } else {
            tillNextBrick++;
        }

    }

}
