using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemig2D : MonoBehaviour
{
    [SerializeField] private CombatSO combatSO;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int id;
    private void Awake()
    {
        for (int i = 0; i < combatSO.id.Count; i++)
        if (combatSO.id[i] == id)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PJ"))
        {

            for (int i = 0; i < combatSO.enemeisPrefabs.Length; i++)
            {
                combatSO.enemeisPrefabs[i] = null;
            }
            for (int i = 0; i < enemies.Length; i++)
            {
                combatSO.enemeisPrefabs[i] = enemies[i];
            }
            combatSO.positionpj = collision.transform.position;
            combatSO.id.Add(id);
            SceneManager.LoadScene(2);


        }
    }
}
