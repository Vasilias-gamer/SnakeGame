
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public float SetSnakeSpeed;
    public int SetGridSize;
    public float SetCollectableSpwanDelay;
    public float SetCollectableOnscreenTime;
    [HideInInspector]
    public List<GameObject> tiles;
    [HideInInspector]
    public int Score;
    [HideInInspector]
    public string CurrentScene;
    [HideInInspector]
    public bool GamePause;
    [HideInInspector]
    public bool GameOver;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("data");
        if (objs.Length > 1)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
}
