using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SelectedMode
{
    None,
    Minion,
    Build,
    Furniture
}

public class Manager : MonoBehaviour
{

    int gridWidth = 100;
    int gridHeight = 100;

    public GameObject groundPrefab;
    public GameObject wallPrefab;
    public GameObject minionPrefab;
    public SelectedMode selectedMode;
    public List<Minion> selectedMinions;
    public float scale = 10;
    public Ground[,] grid;

    public List<Minion> minions;

    void Start()
    {
        CreateGrid();

        minions = new List<Minion>();
        Minion minion = Instantiate(minionPrefab, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<Minion>();
        // minion.targer
        minion.target = GetGround(5, 5);
        minions.Add(minion);

    }

    public void GroundClick(Ground ground)
    {
        // Debug.Log(x + "," + y);
        // Debug.Log(ground);
        minions[0].target = ground;
    }
    public List<Ground> GetAdjacentGround(Ground ground)
    {
        List<Ground> output = new List<Ground>();
        int[,] combos = new int[,] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 } };
        for (int i = 0; i < combos.GetLength(0); i++)
        {
            Ground test = GetGround(ground.x + combos[i, 0], ground.y + combos[i, 1]);
            if (test)
            {
                output.Add(test);
            }
        }

        return output;
    }

    internal void MinionClick(Minion minion)
    {
        throw new NotImplementedException();
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
                // Debug.Log(ground);
                if (ground)
                {
                    ground.x = x;
                    ground.y = y;
                }
                grid[x, y] = ground;
            }
        }
    }

    public Ground GetGround(int x, int y)
    {
        if (x < 0 || y < 0)
        {
            return null;
        }
        if (x >= grid.GetLength(0) || y >= grid.GetLength(1))
        {
            return null;
        }
        return grid[x, y];
    }

    public Ground GetRandomGround()
    {
        Ground ground;
        System.Random random = new System.Random();
        ground = grid[random.Next(grid.GetLength(0)), random.Next(grid.GetLength(1))];

        return ground;
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
