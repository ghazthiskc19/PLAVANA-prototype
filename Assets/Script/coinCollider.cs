using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollider : MonoBehaviour
{
    AudioManager audioManager;

    void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    // GameManager gameManager;
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            GameManager.Instance.AddScore();
            audioManager.PlaySFX(audioManager.CollectCoin);
            Destroy(gameObject);
        }
    }
}
