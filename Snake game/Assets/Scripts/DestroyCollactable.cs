using UnityEngine;

public class DestroyCollactable : MonoBehaviour
{
    [HideInInspector]
    public float DestroyTime;
    private float counter;

    private void Start()
    {
        counter = 0;
    }
    private void Update()
    {
        if (counter > DestroyTime)
        {
            Destroy(gameObject);
        }
        else
        {
            counter += Time.deltaTime;
        }
    }
}
