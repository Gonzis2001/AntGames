using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[CreateAssetMenu( menuName = "Enemies/Wolf")]
public class Lobo :  EnemySo
{
    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip howlSound;
    [SerializeField] private AudioClip damageSound;
    public override float TakePDamage(float damaga, float life, float defense, Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {
      
        audiosorce.PlayOneShot(damageSound);
        animator.SetTrigger("TakeDamage");
        
         return base.TakePDamage(damaga,life,defense,animator,audiosorce,texDamage);


    }
    public override float TakeMDamage(float damaga, float life, float defense, Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {
        audiosorce.PlayOneShot(damageSound);
        animator.SetTrigger("TakeDamage");
        return base.TakeMDamage(damaga, life, defense, animator, audiosorce, texDamage);

    }

    public override void Accion(float damage, ShowLife objetivo, Enemies me)
    {
        float random = Random.Range(0f, 1f);
        if (random <= 0.6f)
        {
            me.audioSource.PlayOneShot(attackSound);
            me.animator.SetTrigger("Attack");
            float takeDamage = damage - objetivo.defense;
            if (takeDamage < 0f)
            {takeDamage = 0f;

            }
            objetivo.hP -=takeDamage;
            objetivo.Animator.SetTrigger("Hit");

        }
        else
        {
            me.audioSource.PlayOneShot(howlSound);
            me.animator.SetTrigger("Howl");
            me.buffatacck = 3;
        }
       
    }
    public override void Die(float life, GameObject me, Transform spawn, CombatManager combat)
    {
        base.Die(life, me, spawn,combat);  
    }

}
