using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewAttackCard", menuName = "Cards/Magic")]
public class MagicCard : Card   
{
    private GameObject enemySelector;


    public override void Play()
    {
        enemySelector = GameObject.Find("GameManager");
        if (enemySelector.GetComponent<EnemySelector>().selectedEnemy != null)
        {

            enemySelector.GetComponent<EnemySelector>().selectedEnemy.GetComponent<Enemies>().TakeMagicDamage(Pj.magic);

        }

    }
}
