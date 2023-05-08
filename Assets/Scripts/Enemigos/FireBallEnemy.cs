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
    //Fuerza de empuje del Bouncer
    public float bounceForce = 20f;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = false;
        //Inicializamos el rigidbody
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
            Bounce(bounceForce);
        }
    }

    private void AceleronIzquierdo()
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        theRB.AddForce(-transform.forward * push, ForceMode2D.Impulse);
    }

    public void Bounce(float bounceForce)
    {
        //Impulsamos al jugador rebotando
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
    }

}
