using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    
    public bool tongueOut;
    

    public float tongueOutTime;
    public float limitTongueOutTime;
    public float frogGoingToTargetSpeed;

    public bool goingToTheEnemy;

    //Referencias
    public Animator anim;
    public Transform frogTransform;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            tongueOut = true;
            
        }

        if(tongueOut == true)
        {
            tongueOutTime += Time.deltaTime;

            if(tongueOutTime > limitTongueOutTime)
            {
                tongueOut = false;
                tongueOutTime = 0;
            }
        }        

        anim.SetBool("Tongue_Out", tongueOut);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            goingToTheEnemy = true;

            if(goingToTheEnemy ==true)
            {
                //Multiplicamos la velocidad por Time.deltaTime para que vaya igual en todos los ordenadores
                float frogStep = frogGoingToTargetSpeed * Time.deltaTime;

                frogTransform.position = Vector2.MoveTowards(frogTransform.position, collision.transform.position, frogStep);
            }
            if (Vector3.Distance(collision.transform.position, frogTransform.position) <0.1f)
            {
                goingToTheEnemy = false;
            }

            //Hacer un metodo para cuando este llendo al enemgio se ejecute el true. un metodo con el que se ejecute el MoveTowards
        }
    }

}
