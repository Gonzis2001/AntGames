using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  class  EnemySo : ScriptableObject
{
    
        public float hP;
        public float hPmax;
        public int attack;
        public int magic;
        public int defense;
        public int defenseMagic;
        public int vel;

        public string enemies;

    public virtual float TakePDamage(float damage,float life,float defense)
    {
        life -= (damage-defense);
      
        return(life);
    }
    public virtual float TakeMDamage(float damage, float life, float defense)
    {
        life -= (damage-defense);

        return (life);
    }
    public virtual void Accion(float damage, ShowLife objetivo)
    {

    }

}
