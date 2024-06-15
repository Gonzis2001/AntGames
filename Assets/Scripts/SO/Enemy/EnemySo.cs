using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemies")]
public class  EnemySo : ScriptableObject
{
    
        public float hP;
        public float hPmax;
        public int attack;
        public int magic;
        public int defense;
        public int defenseMagic;
        public int vel;

        public string enemies;
   


}
