using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pjPrefabs;
    [SerializeField] private GameObject[] enemeisPrefabs;
    [SerializeField] private Transform[] pjSpawns;
    [SerializeField] private Transform[] enemiesSpawns;

    void Start()
    {
        for (int i = 0; i < pjPrefabs.Length; i++)
        {
            Instantiate(pjPrefabs[i], pjSpawns[i].position, pjSpawns[i].rotation);
        }
        for (int i = 0; i < enemeisPrefabs.Length; i++)
        {
            Instantiate(enemeisPrefabs[i], enemiesSpawns[i].position, enemiesSpawns[i].rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
