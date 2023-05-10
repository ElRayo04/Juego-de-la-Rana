using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbejaPinchoController : MonoBehaviour
{
    //Array de puntos por los que se mueve el enemigo
    public Transform[] points;
    //Velocidad de movimiento del enemigo
    public float moveSpeed;
    //Variable para conocer en que punto del recorrido se encuentra el enemigo
    public int currentPoint;

    //Una referencia al SpriteRenderer del enemigo
    private SpriteRenderer theSR;

    //Distancia del jugador para ser atacado, velocidad de persecución
    public float distanceToAttackPlayer, chaseSpeed;

    //Objetivo del enemigo
    private Vector3 attackTarget;

    //Tiempo entre ataques
    public float waitAfterAttack;
    //Contador de tiempo entre ataques
    private float attackCounter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
