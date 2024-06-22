using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMainMenu : MonoBehaviour
{

    [SerializeField] private CombatSO combatSO;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NuevaPartida()
    {
        combatSO.firstTime = false;
        combatSO.positionpj = new Vector2(-4.55f, -7.01f);
        SceneManager.LoadScene("2D City");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
