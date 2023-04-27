using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI

public class UIController : MonoBehaviour
{
    //Referencias a las im�genes de los corazones de la UI
    public Image heart1, heart2, heart3, heart4, heart5, heart6;

    //Referencias a los sprites que cambiar�n al perder o ganar un coraz�n
    public Sprite heartFull, heartEmpty;

    //Hacemos el Singleton de este script
    public static UIController sharedInstance;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //M�todo para actualizar la vida en la UI
    public void UpdateHealthDisplay()
    {
        //En este caso ser� mejor implementar un Switch ya que depende del valor de la misma variable
        ////Si la vida del jugador fuera 3
        //if(PlayerHealthController.sharedInstance.currentHealth == 3)
        //{
        //    //Ponemos la imagen de los tres corazones en lleno
        //    heart1.sprite = heartFull;
        //    heart2.sprite = heartFull;
        //    heart3.sprite = heartFull;
        //}

        //Dependiendo del valor de la vida actual del jugador   
        switch (PlayerHealthController.sharedInstance.currentHealth)
        {
            //En el caso en el que la vida actual valga 6
            case 6:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                heart4.sprite = heartFull;
                heart5.sprite = heartFull;
                heart6.sprite = heartFull;
                break;
            //En el caso en el que la vida actual valga 5
            case 5:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                heart4.sprite = heartFull;
                heart5.sprite = heartFull;
                heart6.sprite = heartEmpty;
                break;
            //En el caso en el que la vida actual valga 4
            case 4:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                heart4.sprite = heartFull;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                break;
            //En el caso en el que la vida actual valga 3
            case 3:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartFull;
                heart4.sprite = heartEmpty;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 2
            case 2:
                heart1.sprite = heartFull;
                heart2.sprite = heartFull;
                heart3.sprite = heartEmpty;
                heart4.sprite = heartEmpty;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 1
            case 1:
                heart1.sprite = heartFull;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                heart4.sprite = heartEmpty;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                //Cerramos el caso
                break;
            //En el caso en el que la vida actual valga 0
            case 0:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                heart4.sprite = heartEmpty;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                //Cerramos el caso
                break;
            //En el caso por defecto, el jugador estar� muerto
            default:
                heart1.sprite = heartEmpty;
                heart2.sprite = heartEmpty;
                heart3.sprite = heartEmpty;
                heart4.sprite = heartEmpty;
                heart5.sprite = heartEmpty;
                heart6.sprite = heartEmpty;
                //Cerramos el caso
                break;
        }
    }
}
