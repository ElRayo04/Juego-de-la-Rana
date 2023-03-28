using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    
    public bool tongueOut;
    

    public float tongueOutTime;
    public float limitTongueOutTime;
    public float frogGoingToTargetSpeed;

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
            float frogStep = frogGoingToTargetSpeed * Time.deltaTime;

            frogTransform.position = Vector2.MoveTowards(frogTransform.position, collision.transform.position, frogStep);

            //Que se fezee el collider 
        }
    }

}
