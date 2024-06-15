using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Libra", menuName = "Cards/Libra")]
public class HabiltyCard : Card
{
    private GameObject enemySelector;
    public override void Play()
    {
        enemySelector = GameObject.Find("GameManager");
        if (enemySelector.GetComponent<EnemySelector>().selectedEnemy != null)
        {
            enemySelector.GetComponent<EnemySelector>().selectedEnemy.GetComponentInChildren<Image>().enabled = true;
        }
    }

}

