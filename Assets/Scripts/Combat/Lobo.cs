using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
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
}
