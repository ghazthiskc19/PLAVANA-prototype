using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject player;
    public GameObject monsterController;
    public GameObject spawnerPlatform;
    public GameObject gameStartUI;
    public Text textScore;
    public Text textBestScore;
    private PlayerBehavior playerBehavior;
    private PlayerController playerController;
    private MonsterController controller;
    private Spawner spawnerScript;
    private int score;
    AudioManager audioManager;
    void Awake(){
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        score = 0;
        playerBehavior = player.GetComponent<PlayerBehavior>();
        playerController = player.GetComponent<PlayerController>();
        controller = monsterController.GetComponent<MonsterController>();
        spawnerScript = spawnerPlatform.GetComponent<Spawner>();
        playerBehavior.ControlUI.SetActive(false);   
        playerBehavior.gameOverUI.SetActive(false);
        spawnerScript.OnDisabling();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        UpdateBestScore();
        DontDestroyOnLoad(audioManager);
    }

    void Update(){
        textScore.text = score.ToString();
    }
    public void OnRestart(){
        audioManager.PlaySFX(audioManager.Pause);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CheckHighScore(){
        if(score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
            Debug.Log(score);
            UpdateBestScore();
        }
    }

    void UpdateBestScore(){
        textBestScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void OnPointerClick(){
        audioManager.PlaySFX(audioManager.Confirm);
        playerBehavior.ControlUI.SetActive(true);
        spawnerScript.OnEnabling();
        playerController.setGameStarted();
        controller.GetComponent<Animator>().SetBool("IsStarted", true);
        gameStartUI.SetActive(false);
    }

    public void AddScore(){
        score++;
        CheckHighScore();
    }

    public int GetScore(){
        return score;
    }
}
