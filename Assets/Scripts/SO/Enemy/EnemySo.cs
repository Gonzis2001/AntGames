using System.Collections;
using System.Collections.Generic;
using TMPro;

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
    public int exp;
    public int level;



    public string enemies;
    public GameObject dieEffect;
  

    public virtual float TakePDamage(float damage,float life,float defense,Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {
        life -= (damage-defense);

     

        return (life);
    }
    public virtual float TakeMDamage(float damage, float life, float defense, Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {
        life -= (damage-defense);
       

        return (life);
    }
    public virtual void Accion(float damage, ShowLife objetivo,Enemies me)
    {

    }
    public virtual void Die(float life,GameObject me,Transform spawn,CombatManager combat)
    {
        if (life < 0)
        {

            combat.Exp += me.GetComponent<Enemies>().exp;
            combat.enemies.Remove(me.GetComponent<Enemies>());
            Destroy(me);
            Instantiate(dieEffect,spawn.position,Quaternion.identity);

        }
    }
    public IEnumerator MostrateDamgage(float damage,float life,  float defense, TMP_Text texDamage)
    {
        if (texDamage!=null)
        {

            texDamage.enabled = true;
            texDamage.text = (damage - defense).ToString();
            yield return new WaitForSeconds(1f);
            texDamage.enabled = false;
        }
    }
    

}
