using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private GameData Data;
    private Rigidbody rb;
    public SteeringControl Handle;
    public float AngleOffset;

    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        AngleOffset = 0;
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

    void movement()
    {
        rb.MovePosition(transform.position + transform.forward * Time.deltaTime * Data.SetSnakeSpeed);
    }

    void turn()
    {
        transform.localEulerAngles = new Vector3(0, AngleOffset + Handle.GetAngle(), 0);
    }

    void FixedUpdate()
    {
        movement();
        if (Data.CurrentScene.Equals("Game"))
            turn();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("wall") && !Data.GameOver)
        {
            Vector3 normal = collision.GetContact(0).normal;
            transform.forward = Vector3.Reflect(transform.forward, normal);
            if(Data.CurrentScene.Equals("Game"))
                AngleOffset = transform.localEulerAngles.y - Handle.GetAngle();
        }
        else if (collision.gameObject.tag.Equals("collactable") && !Data.GameOver)
        {
            Data.Score++;
            Destroy(collision.gameObject);
        }
    }
}
