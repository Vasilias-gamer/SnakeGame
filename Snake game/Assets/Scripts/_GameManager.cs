
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    private GameData Data;

    private void Awake()
    {
        Data= GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        Data.GamePause = false;
        Data.GameOver = false;
        Data.Score = 0;
        Data.tiles.Clear();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Data.tiles.Count == 0)
        {
            Data.GameOver = true;
        }
    }
}
