using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TileSpawner : MonoBehaviour
{
    public GameObject[] tile;
    private SpriteRenderer t_renderer;
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                int index = (i + j) % 2;
                t_renderer = tile[index].GetComponent<SpriteRenderer>();
                t_renderer.sortingOrder = j + 1;
                tile[index].transform.position = new Vector3(16.40f - (4.08f * i), 11.40f - (3.56f * j), 0);
                Instantiate(tile[index]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
