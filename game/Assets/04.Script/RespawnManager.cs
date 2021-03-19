using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public List<GameObject> ObstaclePool = new List<GameObject>();
    public GameObject[] Obstacles;
    public int objCnt = 1;

    GameObject CreateObj(GameObject obj, Transform parent)
    {
        GameObject copy = Instantiate(obj);
        copy.transform.SetParent(parent);
        copy.SetActive(false);
        return copy;
    }
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i< Obstacles.Length; i++)
        {
            for(int q= 0; q< objCnt; q++)
            {
                ObstaclePool.Add(CreateObj(Obstacles[i], transform));
            }
        }
        
    }
    private void Start()
    {
        GameManager.instance.onPlay += PlayGame;
        
    }
    void PlayGame()
    {

    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
