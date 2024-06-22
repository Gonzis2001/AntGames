using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    [SerializeField] CombatSO combatSO;
    [SerializeField] private string escenaCambio;
    [SerializeField] private Vector2 spawn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {
            combatSO.firstTime = false;
            combatSO.positionpj = spawn;
            SceneManager.LoadScene(escenaCambio);

        }
    }

}
