using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Libra", menuName = "Cards/hability/Defense")]

public class Defensecard : Card
{
    private GameObject enemySelector;
    public override void Play()
    {
        Player.Animator.SetTrigger("Hability");
        Player.defense *= 2;
        Player.defenseBuff += 2;
    }
}
