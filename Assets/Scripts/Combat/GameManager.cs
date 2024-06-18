using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CombatSO combatSO;
    [SerializeField] private List<GameObject>  pjPrefabs;
    [SerializeField] private List<GameObject> enemeisPrefabs;
    [SerializeField] private Transform[] pjSpawns;
    [SerializeField] private Transform[] enemiesSpawns;
    private void Awake()
    {
        for (int i = 0; i < combatSO.enemeisPrefabs.Length; i++)
        {
            if (combatSO.enemeisPrefabs[i] != null)
            {
                enemeisPrefabs.Add(combatSO.enemeisPrefabs[i]);

            }
        }
        for (int i = 0; i < combatSO.pjPrefabs.Length; i++)
        {
            if (combatSO.pjPrefabs[i] != null)
            {
               pjPrefabs.Add(combatSO.pjPrefabs[i]);
            }
        }

    }
    void Start()
    {
        for (int i = 0; i < pjPrefabs.Count; i++)
        {
            Instantiate(pjPrefabs[i], pjSpawns[i].position, pjSpawns[i].rotation);
        }
        for (int i = 0; i < enemeisPrefabs.Count; i++)
        {
            Instantiate(enemeisPrefabs[i], enemiesSpawns[i].position, enemiesSpawns[i].rotation);
        }
    }

   public void Continue()
    {
        SceneManager.LoadScene(1);
    }
}
