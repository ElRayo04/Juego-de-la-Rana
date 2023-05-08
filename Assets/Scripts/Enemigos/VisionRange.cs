using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRange : MonoBehaviour
{
    public GameObject fireBallEnemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))fireBallEnemy.GetComponent<FireBallEnemy>().seePlayer = true;
    }
}
