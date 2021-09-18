using UnityEngine;

public class TileChange : MonoBehaviour
{
    private GameData Data;
    public Material SeconderyMat;

    private void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("snake"))
        {
            GetComponent<MeshRenderer>().material = SeconderyMat;
            Data.tiles.Remove(gameObject);
        }
    }
}
