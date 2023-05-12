using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaPinchoController : MonoBehaviour
{
    //Sin atacar
    //Array de puntos por los que se mueve el enemigo
    public Transform[] points;    
    //Variable para conocer en que punto del recorrido se encuentra el enemigo
    public int currentPoint;
    //Velocidad de movimiento del enemigo
    public float moveSpeed;

    //Variables para el ataque    
    public Transform target;
    public bool seePlayer;
    public bool goingToFrog;
    public float speedAtack;
    // Evita que la coorrutina ejecute 800 veces
    public bool hasStartedChasing;

    //Una referencia al SpriteRenderer y al Rigidbody del enemigo
    private SpriteRenderer theSR;
    private Rigidbody2D theRB;

    // Start is called before the first frame update
    void Start()
    {
        seePlayer = false;
        goingToFrog = false;
        //Inicializamos el rigidbody
        theRB = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(seePlayer == true && goingToFrog )
        {
           
            if(goingToFrog)
            {
                AtaqueTaladro();
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
        
        if(seePlayer== true && hasStartedChasing == false)
        {
            StartCoroutine(AtackSecuence());
            hasStartedChasing = true;
        }        

        //Si el enemigo ha llegado al punto más a la izquierda
        if (transform.position.x < points[currentPoint].position.x)
        {
            //Rotamos al enemigo para que mire en dirección contraria
            theSR.flipX = true;
        }
        //Si el enemigo ha llegado al punto más a la derecha
        else if (transform.position.x > points[currentPoint].position.x)
        {
            //Dejamos al enemigo mirando a donde estaba
            theSR.flipX = false;
        }
    }

    public void AtaqueTaladro()
    {
        float beeStep = speedAtack * Time.deltaTime;
        // Movemos el enemigo hacia el jugador
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,target.position, beeStep); ;
    }

    //Corruutina 
    public IEnumerator AtackSecuence()
    {
        yield return new WaitForSeconds(1f);
        goingToFrog = true;
        yield return new WaitForSeconds(1f);
        goingToFrog = false;
        yield return new WaitForSeconds(1f);

        hasStartedChasing = false;
    }
}
