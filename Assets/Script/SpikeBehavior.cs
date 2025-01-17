using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    private PlayerBehavior playerBehavior;
    // Start is called before the first frame update
    void Start()
    {
        playerBehavior = FindObjectOfType<PlayerBehavior>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            Debug.Log("Kena Anjim!!!");
            playerBehavior.TriggerGameOver();
        }
    }
}
