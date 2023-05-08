using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEnemy : MonoBehaviour
{
    //variable para saber si esta viendo al jugador
    public bool seePlayer;
    public Transform target;

    private Rigidbody2D theRB;    
    private float push = 100f;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = false;
        theRB = gameObject.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //// Alternatively, specify the force mode, which is ForceMode2D.Force by default
        //theRB.AddForce(transform.up * push, ForceMode2D.Impulse);
        if (seePlayer == true)
        {
            AceleronIzquierdo();
        }
    }

    private void AceleronIzquierdo()
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        theRB.AddForce(-transform.forward * push, ForceMode2D.Impulse);
    }

}
