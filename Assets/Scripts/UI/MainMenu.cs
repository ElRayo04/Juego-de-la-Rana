using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class MainMenu : MonoBehaviour
{
    //Variable para saber la escena a la que queremos ir al principio o al continuar el juego
    public string startScene, continueScene, optionsScene, mainMenuScene;

    ////Referencia al botón de Continuar
    //public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //public void ContinueGame()
    //{
    //    //Para saltar a la escena que le pasamos en la variable
    //    SceneManager.LoadScene(continueScene);
    //}
    //Método para el Botón de Start
    public void StartButton()
    {
        SceneManager.LoadScene(startScene);
    }

    //Método para el Botón Quit
    public void QuitGame()
    {
        //Para quitar el juego (solo funciona en la Build no en el editor)
        Application.Quit();
        //Feedback para el editor
        Debug.Log("Quitting Game");
    }
    public void Options()
    {
        SceneManager.LoadScene(optionsScene);
    }
        public void Volver()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
