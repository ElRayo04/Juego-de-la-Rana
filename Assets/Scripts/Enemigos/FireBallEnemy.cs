using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallEnemy : MonoBehaviour
{
    //variable para saber si esta viendo al jugador
    public bool seePlayer;
    public bool imAtacking;
    public bool atack;
    public Transform target;

    private Rigidbody2D theRB;
    public SpriteRenderer theSR;
    public float push = 1f;
    //Variable para conocer la dirección de movimiento del enemigo
    private bool movingRight;


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
            atack = false;
        }

        if(movingRight == true) { theSR.flipX = true; }
        else { theSR.flipX = false; }
    }

    private void Aceleron(int sign)
    {
        // Alternatively, specify the force mode, which is ForceMode2D.Force by default
        theRB.AddForce(new Vector2(1,0) * push* sign, ForceMode2D.Impulse);
        imAtacking = true;
        Debug.Log("se activa AceleronIzquierdo ");
    }

    //Corruutina 
    public IEnumerator AtackPlayer()
    {
        //if(atack == true)
        //{
        yield return new WaitForSeconds(1f);
        //Si el jugador esta a la izquierda, atacamois hacia la izquierda
        if (target.position.x < this.gameObject.transform.position.x)
        {
            movingRight = false;
            Aceleron(-1);
        }
        else // en su defecto esta en la derecha, atacamos a la derecha.
        {
            movingRight = true;
            Aceleron(1);            
        }
        yield return new WaitForSeconds(0.5f);
        theRB.AddForce(theRB.velocity * -1, ForceMode2D.Impulse);

        yield return new WaitForSeconds(1f);
        imAtacking = false;
        //}
    }
   
}
