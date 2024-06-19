using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "Protagonist", menuName = "Heroes")]
public class PlayerSO : ScriptableObject
{

    public float hP;
    public float hPmax;
    public int attack;
    public int magic;
    public int defense;
    public int defenseMagic;
    public int energy;
    public int exp;
    public int expMax;
     public int level;
     public int vel;
    public string Pj;
    public Sprite image;


}
