using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackCard", menuName = "Cards/Attack")]
public class cartaataque : Card
{


    public override void Play()
    {
        
        Debug.Log(CardName + " played! Dealt " + Pj.attack + " damage to the enemy.");
        
        
    }
}
