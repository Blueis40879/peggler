using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    private int maxhits;
    private int pointsperhit;
    
    void Start()
    {
        maxhits = 2;
        pointsperhit = 2;
    }

            void OnCollisionEnter2D(Collision2D collision)
        {
            ScoreManager.Instance.AddScore(pointsperhit);
            maxhits--;
            if (maxhits <= 0)
            {
                Destroy(gameObject);
            }
        }

    // Update is called once per frame
    void Update()
    {

    }
}
