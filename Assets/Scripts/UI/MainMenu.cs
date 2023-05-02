using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class MainMenu : MonoBehaviour
{
    //Variable para saber la escena a la que queremos ir al principio o al continuar el juego
    public string startScene, continueScene;

    //Referencia al botón de Continuar
    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ContinueGame()
    {
        //Para saltar a la escena que le pasamos en la variable
        SceneManager.LoadScene(continueScene);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(startScene);
    }
}
