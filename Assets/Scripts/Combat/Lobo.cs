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

    public override void Accion(float damage, ShowLife objetivo)
    {
        objetivo.hP -=damage;
       
    }
}
