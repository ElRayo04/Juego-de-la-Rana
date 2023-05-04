using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour
{
    //Referencia al panel de información
    public GameObject infoPanel;
    public GameObject textPanel;
    public bool isTextPanelOpen;
    //Referencia al Sprite Renderer del interruptor
    private SpriteRenderer theSR;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el Sprite Renderer del interruptor
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Si pulsamos el botón E y el jugador puede interactuar
        if (Input.GetKeyDown(KeyCode.F) && PlayerControllerEdu.sharedInstance.canInteract)
        {
            textPanel.SetActive(true);
            isTextPanelOpen = true;
        }
        else if (isTextPanelOpen && (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.Space)))
        {
            textPanel.SetActive(false);
            isTextPanelOpen = false;
        }
    }


    //Método para conocer cuando un objeto entra en la zona de Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si es el jugador el que entra en la zona del interruptor
        if (collision.CompareTag("Player"))
        {
            //Mostramos el panel de información
            infoPanel.SetActive(true);
            //Permitimos al jugador que pueda interactuar con el objeto
            PlayerControllerEdu.sharedInstance.canInteract = true;
        }
    }

    //Método para conocer cuando un objeto sale de la zona de Trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Ocultamos el panel de información
        infoPanel.SetActive(false);
        //No permitimos al jugador que pueda interactuar con el objeto
        PlayerControllerEdu.sharedInstance.canInteract = false;
    }
}
