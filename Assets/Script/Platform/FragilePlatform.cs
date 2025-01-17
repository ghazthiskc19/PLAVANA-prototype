using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class FragilePlatform : MonoBehaviour
{
    Animator platformAnimator;
    AudioManager audioManager;
    void Awake(){
        platformAnimator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player") && collision.transform.up.y >= transform.up.y ){
            Invoke(nameof(DestroyPlatform), 1.5f);
            platformAnimator.SetBool("IsTouch", true);
        }
    }

    void DestroyPlatform(){
        audioManager.PlaySFX(audioManager.PlatformCrash);
        Destroy(gameObject);
    }
}
