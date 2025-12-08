using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

            void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Hit!");
        }

    // Update is called once per frame
    void Update()
    {

    }
}
