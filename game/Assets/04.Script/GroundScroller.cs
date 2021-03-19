using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroller : MonoBehaviour
{
    public SpriteRenderer[] tiles;
    public Sprite[] groundimg;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    SpriteRenderer temp;
    void Update()
    {
        if (GameManager.instance.isPlay)
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (-5 >= tiles[i].transform.position.x)
                    {
                        for (int q = 0; q < tiles.Length; q++)
                        {
                            if (temp.transform.position.x < tiles[q].transform.position.x)
                                temp = tiles[q];
                        }
                        tiles[i].transform.position = new Vector2(temp.transform.position.x + 1, -0.3f);
                        tiles[i].sprite = groundimg[Random.Range(0, groundimg.Length)];
                    }
                    tiles[i].transform.Translate(new Vector2(-1, 0) * Time.deltaTime * GameManager.instance.gameSpeed);
                }
            }
        
    }
}