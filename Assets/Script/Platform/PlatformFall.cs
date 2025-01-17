using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{
    AudioManager audioManager;
    void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // private bool isDisappear = false;
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Monster")){
            audioManager.PlaySFX(audioManager.PlatformCrash);
            Destroy(gameObject);
        }
    }
}
