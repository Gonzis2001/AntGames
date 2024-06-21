using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void NuevaPartida()
    {
        SceneManager.LoadScene("");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
