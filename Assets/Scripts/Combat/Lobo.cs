using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu( menuName = "Enemies/Wolf")]
public class Lobo :  EnemySo
{
    public override float TakePDamage(float damaga,float life, float defense)
    {
      
         return base.TakePDamage(damaga,life,defense);

        
    }
    public override float TakeMDamage(float damaga, float life, float defense)
    {
        return base.TakeMDamage(damaga, life, defense);

    }

    public override void Accion(float damage, ShowLife objetivo, Enemies me)
    {
        float random = Random.Range(0f, 1f);
        if (random <= 0.6f)
        {
            me.animator.SetTrigger("Attack");
         objetivo.hP -=damage-objetivo.defense;

        }
        else
        {
            me.animator.SetTrigger("Howl");
            me.buffatacck = 3;
        }
       
    }
}
