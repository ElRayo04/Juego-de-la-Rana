using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEnemy : MonoBehaviour
{
    //variable para saber si esta viendo al jugador
    public bool seePlayer;
    public bool imAtacking;
    public bool atack;

    private Rigidbody2D theRB;    
    public float push = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = false;
        imAtacking = false;
        //Inicializamos el rigidbody
        theRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //// Alternatively, specify the force mode, which is ForceMode2D.Force by default
        //theRB.AddForce(transform.up * push, ForceMode2D.Impulse);
        if (seePlayer == true && imAtacking == false)
        {
            atack = true;
            StartCoroutine(AtackPlayer());
        }
    }

    private void AceleronIzquierdo()
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        theRB.AddForce(new Vector2(-1,0) * push, ForceMode2D.Impulse);
        imAtacking = true;
        Debug.Log("se activa AceleronIzquierdo ");
    }

    //Corruutina 
    public IEnumerator AtackPlayer()
    {
        if(atack == true)
        {
            yield return new WaitForSeconds(1f);
            AceleronIzquierdo();
            atack = false;
        }
    }
   
}
