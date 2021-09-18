using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public float SetSnakeSpeed;
    public int SetGridSize;
    public float SetCollectableSpwanDelay;
    public float SetCollectableOnscreenTime;
    public List<GameObject> tiles;
    public int Score;
    public string CurrentScene;
    public bool GamePause;
    public bool GameOver;

    private void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("data");
        if (obj != gameObject)
            Destroy(obj);
        DontDestroyOnLoad(gameObject);
    }
}
