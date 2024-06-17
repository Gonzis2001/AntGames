using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemig2D : MonoBehaviour
{
    [SerializeField] private CombatSO combatSO;
    [SerializeField] private GameObject[] enemies;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                combatSO.enemeisPrefabs[i] = enemies[i];
            }
            SceneManager.LoadScene(2);


        }
    }
}
