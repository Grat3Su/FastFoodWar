using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ItemSpawn : MonoBehaviour
{
    public GameObject[] item;
    float timer;
    bool first_create;
    float max_time;
    float min_time;

    float Tile_timer;
    public float SpawnTimer;
    Vector2 targetTile;
    public GameObject obs;
    Vector2[] TilePos;
    public int tileindex;

    // Start is called before the first frame update
    void Start()
    {
        first_create = false;
        timer = 0;
        max_time = 10;
        min_time = 5;

        int index = 0;
        TilePos = new Vector2[81];
        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                TilePos[index] = new Vector2(16.40f - (4.08f * i), 11.40f - (3.56f * j));
                index++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > max_time)
        {
            first_create = true;
            timer = 0;
            if(max_time >= min_time)
            max_time -= 1;
        }

        if(first_create == true)
        {//생성... 아이템 생성.... 랜덤으로 index 받아서 랜덤 위치에 생성
            int index = Random.Range(0, 3);
            int spawn_index = Random.Range(0,81);
            //랜덤 x, y값 지정
            Vector2 addvec = new Vector2(0, 0.5f);

            Vector2 pos = TilePos[spawn_index] + addvec;

            item[index].transform.position = pos;//랜덤한 위치 지정
            Instantiate(item[index]);
            first_create = false;
        }

        Tile_timer += Time.deltaTime;
        if (Tile_timer > SpawnTimer)
        {
            Tile_timer = 0;
            int spawn = Random.Range(0, 10);
            if (spawn < 3)
            {// 랜덤 위치로 생성
                tileindex = Random.Range(0, 81);
                obs.transform.position = TilePos[tileindex];
                Instantiate(obs);
            }
        }
    }
}
