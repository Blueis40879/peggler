using UnityEngine;

public class ShootBall : MonoBehaviour
{



    public float ShootForce = 500f;


    public Vector3 Direction = new Vector3(0f, 1f, 0f);

    private Rigidbody2D rb;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {

            rb.AddForce(Direction * ShootForce);

        }
    }
}
