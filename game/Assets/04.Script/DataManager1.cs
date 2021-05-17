using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager1 : MonoBehaviour
{
    static DataManager1 instance;
    public bool PlayerDie = false;
    public static DataManager1 Instance
       
    {
        get
        {
            return instance;
        }
    }

    [System.Obsolete]
    private void Awake()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            DestroyObject(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
