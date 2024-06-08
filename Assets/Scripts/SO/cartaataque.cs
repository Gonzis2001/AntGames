using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackCard", menuName = "Cards/Attack")]
public class cartaataque : Card
{
    public int damage;

    public override void Play()
    {
        
        Debug.Log(CardName + " played! Dealt " + damage + " damage to the enemy.");
    }
}
