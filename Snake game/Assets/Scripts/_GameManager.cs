
using UnityEngine;

public class _GameManager : MonoBehaviour
{
    private GameData Data;

    private void Start()
    {
        Data= GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        Data.Score = 0;
        Data.GameOver = false;
    }

    private void Update()
    {
        if (Data.tiles.Count == 0)
        {
            Data.GameOver = true;
        }
    }
}
