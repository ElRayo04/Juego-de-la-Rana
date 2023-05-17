using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public bool imAtacking;

    //Referencia al collider del Ataque
    public Collider2D atackCollider;

    // Start is called before the first frame update
    void Start()
    {
        atackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            StartCoroutine(Ataque());
        }
    }

    //Metodo para hacer daño al enemigo
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Debug.Log("Acemos daño");
        }
    }

    public IEnumerator Ataque()
    {
        Debug.Log("Hola?");
        atackCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        atackCollider.enabled = false;
    }
}
