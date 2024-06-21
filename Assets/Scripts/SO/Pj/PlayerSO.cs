using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Protagonist", menuName = "Heroes")]
public class PlayerSO : ScriptableObject
{
    public List<Card> ObjectDeck;
    public List<Card> deck;
    public List<Card> deckMax;
    public float hP;
    public float hPmax;
    public int attack;
    public int magic;
    public int defense;
    public int defenseMagic;
    public int energy;
    public float exp;
    public float expMax;
     public int level;
     public int vel;
    public string Pj;
    public Sprite image;


}
