using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    int gridWidth = 100;
    int gridHeight = 100;

    public GameObject groundPrefab;
    public GameObject wallPrefab;
    public GameObject minionPrefab;

    public float scale = 10;


    public Ground[,] grid;

    public List<Minion> minions;

    void Start()
    {
        CreateGrid();

        minions = new List<Minion>();
        GameObject minion = Instantiate(minionPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        minions.Add(minion.GetComponent<Minion>());

    }

    public void GroundClick(Ground ground)
    {
        // Debug.Log(x + "," + y);
        Debug.Log(ground);
        minions[0].target = ground;
    }

    private void CreateGrid()
    {
        grid = new Ground[gridWidth, gridHeight];
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float sample = Mathf.PerlinNoise(x / scale, y / scale);
                sample = Mathf.Abs(sample - 0.5f);

                GameObject prefab = sample > 0.05 ? groundPrefab : wallPrefab;

                if (x % 10 == 0 || y % 10 == 0)
                {
                    prefab = groundPrefab;
                }


                GameObject tile = Instantiate(prefab, new Vector3(x, 0, y), Quaternion.identity);

                Ground ground = tile.GetComponent<Ground>();
                if (ground)
                {
                    ground.x = x;
                    ground.y = y;
                }
                grid[x, y] = ground;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            // Debug.Log("fuckyou");

        }
    }
}
