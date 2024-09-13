using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    public GameObject brick;
    public float brickSpawnRate;
    private float tillNextBrick;
    public int brickSpawnRange;
    public bool brickCanSpawn;

    private void Update()
    {
        tillNextBrick += Time.deltaTime;

        Vector2 brickSpawn = transform.position;
        int brickRandomiser = Random.Range(-Mathf.RoundToInt(brickSpawnRange), Mathf.RoundToInt(brickSpawnRange));

        if (tillNextBrick >= brickSpawnRate)
        {
            tillNextBrick = 0f;

            if (brickCanSpawn)
            {
                Instantiate(brick, new Vector2(brickSpawn.x + brickRandomiser, brickSpawn.y), Quaternion.identity);
            }
        }
    }

}
