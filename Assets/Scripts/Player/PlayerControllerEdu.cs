using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEdu : MonoBehaviour
{
    ////Movimiento horizontal
    //[SerializeField] float xSpeed;
    //[SerializeField] float maxXSpeed = 30;
    //[SerializeField] float runAccel; //Cuanto tarda en llegar al máximo de velocidad
    //[SerializeField] float runDeaccel; //Cuanto tarda en frenar al soltar las teclas

    //Velocidad del jugador
    public float moveSpeed;

    //Movimiento vertical
    [SerializeField] float ySpeed; // Velocidad horizontal
    [SerializeField] float yStart; //Velocidad inicial con la que empieza el salto para que no tarde tanto en empezar a subir

    [SerializeField] bool duringJump; //Es true durante todo el proceso del salto, desde el impulso hasta tocar el suelo
    [SerializeField] bool isGrounded; //indica si está colisionando con el suelo, también es false instantaneamente en cuanto usamos el salto
    [SerializeField] bool hasJumpEnded = true; // Es false durante el impulso del salto y hasta que frena, cuando empieza a caer es true
    [SerializeField] float jumpMaxSpeed; // velocidad máxima para ascender hacia arribva
    [SerializeField] float jumpAccel; // que tan rápido llega a la velocidad de salto máxima
    [SerializeField] float jumpTimer; //contador que decrece cuando mantienes el salto
    [SerializeField] float jumpTimerLimit; //cuanto tiempo máximo puedes aguantar el botón de salto (en segundos)
    [SerializeField] float jumpDeaccel;

    [SerializeField] float fallAccel; //cuanto tarda en alcanzar la velocidad de caída máxima
    [SerializeField] float fallMaxSpeed; //velocidad de caída máxima


    private int speedSign;
    [SerializeField] Vector2 speed;

    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Rigidbody2D theRB;
    [SerializeField] Transform groundCheckPoint;


    //VARABLES PARA LA LENGUA

    //Referencia al collider de la lengua
    public Collider2D tongueCollider;

    public Vector3 positionEnemy;
    
    public float frogGoingToTargetSpeed;

    //Variable para saber si estamos llendo al enemigo con la lengua
    public bool goingToTheEnemy;


    //VARIABLES PARA LA RANA

    //Referencia al Animator del jugador
    private Animator anim;
    //Referencia al SpriteRenderer del jugador
    private SpriteRenderer theSR;

    //Variable para conocer hacia donde mira el jugador
    public bool isLeft;

    //Hacemos el Singleton de este script
    public static PlayerControllerEdu sharedInstance;

    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Rellenamos las referencias        
        theRB = GetComponent<Rigidbody2D>();        
        anim = GetComponent<Animator>();        
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        if (hasJumpEnded)
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);
        }
        else
        {
            isGrounded = false;
        }


        if (isGrounded)
        {
            duringJump = false;
            ySpeed = 0;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                //theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                Startjump();
            }
        }

        if (!hasJumpEnded)
        {
            jump();
        }
        else if (!isGrounded && duringJump)
        {
            ySpeed = Mathf.Lerp(ySpeed, fallMaxSpeed, fallAccel);
            theRB.velocity = new Vector2(theRB.velocity.x, ySpeed);
        }

        //Llamamos al metodo para ir hacia la lengua
        if (goingToTheEnemy == true)
        {
            MoveFrogTowards();

            //Desactivamos el collider de la lengua
            tongueCollider.enabled = false;  // .enable sirbe para desactivar componestes

            if (Vector3.Distance(positionEnemy, this.gameObject.transform.position) < 0.3f) //this.gameObject hace referencia a el gameobject que lleve este Script
            {
                Debug.Log("AAAAAAAA me caigo");
                goingToTheEnemy = false;                
            }
            Debug.Log("si 2dos cosita");
            Debug.Log("si una cosita");
        }

        //Girar el sprite del jugador según su dirección de movimiento
        //Si el jugador se mueve hacia la izquierda
        if (theRB.velocity.x > 0)
        {
            Debug.Log("si una cosita");
            //No cambiamos la dirección del sprite
            theSR.flipX = false;
            //El jugador mira a la izquierda
            isLeft = true;
        }
        //Si el jugador por el contrario se está moviendo hacia la derecha
        else if (theRB.velocity.x < 0)
        {
            Debug.Log("si 2dos cosita");
            //Cambiamos la dirección del sprite
            theSR.flipX = true;
            //El jugador mira a la derecha
            isLeft = false;
        }
    }

    private void Startjump()
    {
        hasJumpEnded = false;
        jumpTimer = jumpTimerLimit;
        ySpeed = yStart;
        duringJump = true;
    }

    private void jump()
    {
        if (jumpTimer >= 0) jumpTimer -= Time.deltaTime;
        if (Input.GetButtonUp("Jump"))
        { 
            jumpTimer = 0;
            Debug.Log("HAS SOLTADO LA PUTA TECLA");
        }

        if (Input.GetButton("Jump") && jumpTimer > 0)
        {
            Debug.Log("Estás manteniendo el salto");
            ySpeed = Mathf.Lerp(ySpeed, jumpMaxSpeed, jumpAccel);
        }
        else
        {
            ySpeed = Mathf.Lerp(ySpeed, 0, jumpDeaccel);
            if (ySpeed <= 0.2) ySpeed = 0;
            if (ySpeed == 0) hasJumpEnded = true;
        }
        if (ySpeed > 0.2) theRB.velocity = new Vector2(theRB.velocity.x, ySpeed);
    }

    //Metodo para mover a la rana hacia su lengua
    public void MoveFrogTowards()
    {
        //Multiplicamos la velocidad por Time.deltaTime para que vaya igual en todos los ordenadores
        float frogStep = frogGoingToTargetSpeed * Time.deltaTime;

        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, positionEnemy, frogStep);
    }
}
