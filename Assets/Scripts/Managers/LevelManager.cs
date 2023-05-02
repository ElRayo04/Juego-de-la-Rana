using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Para cambiar entre escenas

public class LevelManager : MonoBehaviour
{
    //Tiempo antes de respawnear
    public float waitToRespawn;

    //Variable para guardar el nombre del nivel al que queremos ir
    public string levelToLoad;

    //Hacemos el Singleton de este script
    public static LevelManager sharedInstance;

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

    //Método para respawnear al jugador cuando muere
    public void RespawnPlayer()
    {
        //Llamamos a la corrutina que respawnea al jugador
        StartCoroutine(RespawnPlayerCo());
        Debug.Log("respaun");
    }

    //Corrutina para respawnear al jugador
    public IEnumerator RespawnPlayerCo()
    {
        //Desactivamos al jugador
        PlayerControllerEdu.sharedInstance.gameObject.SetActive(false);

        ////Llamamos al sonido de muerte
        //AudioManager.sharedInstance.PlaySFX(8);

        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(waitToRespawn);

        ////Llamamos al método que hace fundido a negro
        //UIController.sharedInstance.FadeToBlack();
        //Esperamos un tiempo determinado
        yield return new WaitForSeconds(waitToRespawn);
        ////Llamamos al método que hace fundido a transparente
        //UIController.sharedInstance.FadeFromBlack();

        //Activamos de nuevo al jugador
        PlayerControllerEdu.sharedInstance.gameObject.SetActive(true);
        //Lo ponemos en la posición de respawn
        PlayerControllerEdu.sharedInstance.transform.position = CheckpointController.sharedInstance.spawnPoint;
        //Ponemos la vida del jugador al máximo
        PlayerHealthController.sharedInstance.currentHealth = PlayerHealthController.sharedInstance.maxHealth;
        //Actualizamos la UI
        UIController.sharedInstance.UpdateHealthDisplay();
    }
}
