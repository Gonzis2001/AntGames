using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Libra", menuName = "Cards/hability/Libra")]
public class Libra : Card
{
    private GameObject enemySelector;
    public override void Play()
    {
        enemySelector = GameObject.Find("GameManager");
        if (enemySelector.GetComponent<EnemySelector>().selectedEnemy != null)
        {
            Player.Animator.SetTrigger("Hability");
            enemySelector.GetComponent<EnemySelector>().selectedEnemy.GetComponentInChildren<Image>().enabled = true;
        }
    }

}

