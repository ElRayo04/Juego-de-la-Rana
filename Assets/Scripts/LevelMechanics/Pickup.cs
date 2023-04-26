using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //Variables para saber lo que son 
    public bool isFruitMaxHealth;

    //Variable para conocer si un objeto ya ha sido recogido
    private bool isCollected;

    ////Referencia al objeto que aparecerá para representar el efecto de coger un item
    //public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isFruitMaxHealth)
        {
            //El objeto ha sido recogido
            isCollected = true;
            //Destruimos el Game Object
            Destroy(gameObject);
        }
    }
}
