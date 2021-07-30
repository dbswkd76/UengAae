using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadYcor : MonoBehaviour {
    public AudioSource diesound;
    public GameObject music;
    Animator anim;

    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!GameManager.playerDie){
            if (transform.position.y>10){
                GameManager.playerDie = true;
                music.SetActive(false);
                Debug.Log("Die");
                anim.SetBool("isDie", true);
                diesound.Play();
            }
        }
    }
}
