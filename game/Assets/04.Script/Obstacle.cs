using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float ObstacleSpeed = 0f;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameManager.playerDie)
        {
            if(collision.gameObject.tag.CompareTo("Player") == 0)
            {
                DataManager1.Instance.PlayerDie = true;
            }
        }
    }
    private void Update()
    {
        
        if (!GameManager.playerDie)
        {
            transform.Translate(-ObstacleSpeed * Time.deltaTime, 0, 0);
            if (transform.position.x <= -100f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
