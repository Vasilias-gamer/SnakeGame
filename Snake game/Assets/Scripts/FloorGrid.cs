using UnityEngine;

public class FloorGrid : MonoBehaviour
{
    private GameData Data;
    private int Size = 1;
    [SerializeField]
    private GameObject Tile;
    
    private float TileSize;
    const float GridSize = 8;

    private void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        Data.tiles.Clear();
        Size = Data.SetGridSize;
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        TileSize = GridSize/Size;
        Tile.transform.localScale = new Vector3(TileSize, 1, TileSize);
        
        for (int row = 0; row < Size; row++)
        {
            for (int col = 0; col < Size; col++)
            {
                GameObject tile = Instantiate<GameObject>(Tile, transform);

                float posX = (col * TileSize) - (GridSize - TileSize) / 2;
                float posY = (row * TileSize) - (GridSize - TileSize) / 2;

                tile.transform.localPosition = new Vector3(posX, 0, posY);
                Data.tiles.Add(tile);
            }
        }
        Destroy(Tile);
    }
}
