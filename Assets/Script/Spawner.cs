using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject normalPlataform;
    public GameObject fragilePlatform;
    public GameObject coin;
    public GameObject spike;
    public Transform player;
    public float minWidth = -1f;
    public float maxWidth = 1f;
    public float spawnRate;
    private float originalSpawnRate;
    bool spikeAppear;
    public void OnEnabling(){
        InvokeRepeating(nameof(Spawn), 0f, spawnRate);
    }       

    public void OnDisabling(){
        CancelInvoke(nameof(Spawn));
    }

    void Awake(){
        originalSpawnRate = spawnRate;
    }
    private void Spawn(){
        int random = Random.Range(0, 10);
        GameObject platform;
        float platSize;
        if(random < 3){
            platform = Instantiate(fragilePlatform, transform.position, Quaternion.identity);
        }else{
            int randomSpike = Random.Range(0, 10);
            platform = Instantiate(normalPlataform, transform.position, Quaternion.identity);
            platSize = platform.GetComponent<BoxCollider2D>().bounds.size.x;
            if(randomSpike > 3){
                spikeAppear = true;
                spawnSpike(platform.transform, platSize);
            } 
        }
        platSize = platform.GetComponent<BoxCollider2D>().bounds.size.x;

        Vector3 leftBoundary = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 rightBoundary = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));

        float minX = leftBoundary.x + platSize / 2;
        float maxX = rightBoundary.x - platSize / 2;
        platform.transform.position = new Vector3(Random.Range(minX,maxX), platform.transform.position.y, platform.transform.position.z);

        spawnCoin(platform.transform, platSize);
        spawnRate = spawnRate - (GameManager.Instance.GetScore() / 30);
    }

    void spawnCoin(Transform transform, float platPositionX){
        float gap = spikeAppear ? 1f : 0.5f ; 
        float randomX = Random.Range(transform.position.x - platPositionX / 2, transform.position.x + platPositionX / 2);
        Vector3 coinPosition = new Vector3(randomX,  transform.position.y + gap, transform.position.z);
        spikeAppear = false;
        GameObject newCoin = Instantiate(coin, coinPosition, Quaternion.identity);
        newCoin.transform.parent = transform;
    }

    void spawnSpike(Transform transform, float platPositionX){
        float randomX = Random.Range(transform.position.x - (platPositionX / 2) + 0.5f, transform.position.x + (platPositionX / 2) - 0.5f);
        Vector3 spikePosition = new Vector3(randomX,  transform.position.y + 0.2f, transform.position.z);

        GameObject newSpike = Instantiate(spike, spikePosition, Quaternion.identity);
        newSpike.transform.parent = transform;
    }
}
