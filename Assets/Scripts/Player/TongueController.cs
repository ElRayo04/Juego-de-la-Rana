using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    
    public bool tongueOut;
    public float tongueOutTime;
    public float limitTongueOutTime;

    //REFERENCIAS

    //al Sprite Renderer
    private SpriteRenderer theSR;

    public Animator anim;
    public Transform frogTransform;
    //Referencia al collider de la lengua
    public Collider2D tongueCollider;

    [SerializeField] PlayerControllerEdu player;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //Obtenemos el SpriteRenderer del jugador
        theSR = GetComponent<SpriteRenderer>();
        //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad al minimo
        theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad al minimo
            theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            tongueOut = true;
            tongueCollider.enabled = true;
        }

        if(tongueOut == true)
        {
            tongueOutTime += Time.deltaTime;

            if(tongueOutTime > limitTongueOutTime)
            {
                tongueOut = false;
                tongueOutTime = 0;
                tongueCollider.enabled = false;
                //Cambiamos el color del sprite, mantenemos el RGB y ponemos la opacidad al minimo
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 0f);
            }
        }
        anim.SetBool("Tongue_Out", tongueOut);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Guardamos la posicion del enemigo --> variable que se actualiza cuando chocamos con un enemigo
            player.positionEnemy = collision.transform.position;
            player.goingToTheEnemy = true;

          
        }
        
    }

    

}
