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
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private PlayerSO playerSOlevel1;

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
        SceneManager.LoadScene(combatSO.escenacargar);
    }
    public void Defeat()
    {
        playerSO.ObjectDeck = playerSOlevel1.ObjectDeck;
        playerSO.deck = playerSOlevel1.deck;
        playerSO.deckMax = playerSOlevel1.deckMax;
        playerSO.hP = playerSOlevel1.hP;
        playerSO.hPmax = playerSOlevel1.hPmax;
        playerSO.attack = playerSOlevel1.attack;
        playerSO.magic = playerSOlevel1.magic;
        playerSO.defense = playerSOlevel1.defense;
        playerSO.defenseMagic = playerSOlevel1.defenseMagic;
        playerSO.energy = playerSOlevel1.energy;
        playerSO.exp = playerSOlevel1.exp;
        playerSO.expMax = playerSOlevel1.expMax;
        playerSO.level = playerSOlevel1.level;
        playerSO.vel = playerSOlevel1.vel;
        playerSO.Pj = playerSOlevel1.Pj;
        playerSO.image = playerSOlevel1.image;
        
        SceneManager.LoadScene("MainMenu");
    }
}
