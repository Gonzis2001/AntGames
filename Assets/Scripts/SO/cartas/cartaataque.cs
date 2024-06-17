using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

[CreateAssetMenu(fileName = "NewAttackCard", menuName = "Cards/Attack")]
public class cartaataque : Card
{
     private GameObject enemySelector;
    [SerializeField] private float multiply;


    public override void Play()
    {
            enemySelector = GameObject.Find("GameManager");
        if (enemySelector.GetComponent<EnemySelector>().selectedEnemy != null)
        {
            
            enemySelector.GetComponent<EnemySelector>().selectedEnemy.GetComponent<Enemies>().TakePhysicaldamage(Player.attack*multiply);
          
        }
 
    }
}
