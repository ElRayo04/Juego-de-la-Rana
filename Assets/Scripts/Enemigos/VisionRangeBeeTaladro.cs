using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRangeBeeTaladro : MonoBehaviour
{
    public GameObject enemy;

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
        if (collision.gameObject.CompareTag("Player")) enemy.GetComponent<AbejaPinchoController>().seePlayer = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) enemy.GetComponent<AbejaPinchoController>().seePlayer = false;
    }
}
