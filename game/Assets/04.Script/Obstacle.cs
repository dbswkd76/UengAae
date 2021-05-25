using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float ObstacleSpeed = 0f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager1.playerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager1.Instance.PlayerDie = true;
            }
        }
    }
    private void Update()
    {
        if (!GameManager1.playerDie)
        {
            transform.Translate(-ObstacleSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -4f)
            {
                Destroy(gameObject);
            }
        }
    }
}
