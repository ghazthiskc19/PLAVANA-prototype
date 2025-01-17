using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 5f;
    private float currentSpeed = 1;
    public float speedMultiplier;
    // private float bottomEdge;
    void Update()
    {   
        currentSpeed = 1 + (GameManager.Instance.GetScore() / 30);
        transform.position += Vector3.down * currentSpeed * Time.deltaTime;
    }
}
