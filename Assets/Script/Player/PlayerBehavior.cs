using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject ResumeUI;
    public GameObject ControlUI;
    AudioManager audioManager;
    private Button[] childsButton;

    // Start is called before the first frame update
    void Awake(){
        childsButton = ControlUI.GetComponentsInChildren<Button>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        ResumeUI.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            Debug.Log("Touch!!");
            transform.parent = collision.transform; 
        }
        if (collision.transform.CompareTag("Monster")) {
            TriggerGameOver();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            transform.parent = null;
        }
    }
    public void TriggerGameOver(){
        Time.timeScale = 0f;
        audioManager.PlaySFX(audioManager.Death);
        gameOverUI.SetActive(true);
        ControlUI.SetActive(false);
    }
    public void OnGamePause(){
        audioManager.PlaySFX(audioManager.Pause);
        Time.timeScale = 0f;
        ResumeUI.SetActive(true);
        foreach (Button btn in childsButton){
            btn.enabled = false;
        }
    }
    public void OnGameContinue(){
        audioManager.PlaySFX(audioManager.Unpause);
        Time.timeScale = 1f;
        ResumeUI.SetActive(false);

        foreach (Button btn in childsButton){
            btn.enabled = true;
        }
    }
}
