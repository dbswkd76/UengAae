using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float ObstacleSpeed = 0;
    public Vector2 Starposition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        transform.position = Starposition;
          
    }
    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPlay)
        transform.Translate(Vector2.left * Time.deltaTime * GameManager.instance.gameSpeed);

        if(transform.position.x < -6)
        {
            gameObject.SetActive(false);
        }
    }
}
