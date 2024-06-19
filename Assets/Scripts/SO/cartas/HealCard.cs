using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObjectCard", menuName = "Cards/Object")]
public class HealCard : Card
{
    private GameObject enemySelector;
    [SerializeField] private float heal;
    public override void Play()
    {
        Player.hP += heal;
        if (Player.hP > Player.hPmax)
        {
            Player.hP = Player.hPmax;
        }

    }
}
