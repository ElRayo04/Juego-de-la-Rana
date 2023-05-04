using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para poder trabajar con elementos de la UI
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class PanelFadeBlack : MonoBehaviour
{
    //Referencia al FadeScreen
    public Image fadeScreen;
    //Variable para la velocidad de transición al FadeScreen
    public float fadeSpeed;
    //Variables para conocer cuando hacemos fundido a negro o vuelta a transparente
    private bool shouldFadeToBlack, shouldFadeFromBlack;

    // Start is called before the first frame update
    void Start()
    {
        //Cuando empieza el juego hacemos fundido a transparente
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        //Si hay que hacer fundido a negro
        if (shouldFadeToBlack)
        {
            //Cambiar la transparencia del color a opaco
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
            //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
            //Si el color ya es totalmente opaco
            if (fadeScreen.color.a == 1f)
            {
                //Paramos de hacer fundido a negro
                shouldFadeToBlack = false;
            }
        }
        //Si hay que hacer fundido a transparente
        if (shouldFadeFromBlack)
        {
            //Cambiar la transparencia del color a transparente
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
            //Mathf.MoveTowards (Moverse hacia) -> el valor que queremos cambiar, valor al que lo queremos cambiar, velocidad a la que lo queremos cambiar
            //Si el color ya es totalmente transparente
            if (fadeScreen.color.a == 0f)
            {
                //Paramos de hacer fundido a transparente
                shouldFadeFromBlack = false;
            }
        }
    }

    //Método para hacer fundido a negro
    public void FadeToBlack()
    {
        //Activamos la booleana de fundido a negro
        shouldFadeToBlack = true;
        //Desactivamos la booleana de fundido a transparente
        shouldFadeFromBlack = false;
    }

    //Método para hacer fundido a transparente
    public void FadeFromBlack()
    {
        //Activamos la booleana de fundido a transparente
        shouldFadeFromBlack = true;
        //Desactivamos la booleana de fundido a negro
        shouldFadeToBlack = false;
    }


    public void StartFade(string scene)
    {
        StartCoroutine(ChangeSceneLevel(scene));
        Debug.Log("Cambiando de escena");
    }

    public IEnumerator ChangeSceneLevel(string scene)
    {
        yield return new WaitForSeconds(0.2f);
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);        
        Debug.Log("No me está sudando la polla");
    }
}
