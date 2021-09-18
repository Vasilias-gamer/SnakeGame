using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawncCollectible : MonoBehaviour
{
    private GameData Data;
    public GameObject Collectible;

    private float counter;

    private void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        counter = 0;
    }
    private void Update()
    {
        if (counter > Data.SetCollectableSpwanDelay)
        {
            Transform Randomtile = Data.tiles[Random.Range(0, Data.tiles.Count)].transform;
            
            Transform SpwanedCollactable = Instantiate<GameObject>(Collectible,Randomtile).transform;
            
            SpwanedCollactable.GetComponent<DestroyCollactable>().DestroyTime = Data.SetCollectableOnscreenTime;
            SpwanedCollactable.localPosition = new Vector3(0, 0.5f, 0);
            SpwanedCollactable.localScale = new Vector3(5, Randomtile.localScale.x * 5, 5);
            
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }
    }
}
