using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Enemies/Bat")]
public class Bat : EnemySo
{

    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip chirridoSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private GameObject rayo;
    [SerializeField] private GameObject rayoExplosion;
    public override float TakePDamage(float damaga, float life, float defense, Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {

        audiosorce.PlayOneShot(damageSound);
        animator.SetTrigger("Hit");

        return base.TakePDamage(damaga, life, defense, animator, audiosorce, texDamage);


    }
    public override float TakeMDamage(float damaga, float life, float defense, Animator animator, AudioSource audiosorce, TMP_Text texDamage)
    {
        audiosorce.PlayOneShot(damageSound);
        animator.SetTrigger("Hit");
        return base.TakeMDamage(damaga, life, defense, animator, audiosorce, texDamage);

    }

    public override void Accion(float damage, ShowLife objetivo, Enemies me)
    {
        float random = Random.Range(0f, 1f);
        if (random <= 0.6f)
        {
            me.audioSource.PlayOneShot(attackSound);
            me.animator.SetTrigger("Attack");
            objetivo.hP -= (damage - objetivo.defenseMagic);
            objetivo.Animator.SetTrigger("Hit");

        }
        else
        {
            me.audioSource.PlayOneShot(chirridoSound);
            me.animator.SetTrigger("Chirrido");

            if (objetivo.attackNeerfbool==false )
            {
                Debug.Log("A");
                objetivo.attack /= 2;
                objetivo.attackNeerfbool = true;
            }
                objetivo.attackNerf += 2;
           me.StartCoroutine(Rayo(objetivo));


        }

    }
    public override void Die(float life, GameObject me, Transform spawn, CombatManager combat)
    {
        base.Die(life, me, spawn, combat);
    }

    public IEnumerator Rayo(ShowLife objetivo)
    {
        yield return new WaitForSeconds(2f);
        Debug.Log("rayo");
         Vector3 posicion =objetivo.gameObject.transform.position;
        Quaternion targetRotation = Quaternion.Euler(-90, 0, 0);
        var rayoclon= Instantiate(rayo, new Vector3(posicion.x, posicion.y + 30, posicion.z), targetRotation);
        yield return new WaitForSeconds(1f);
        Destroy(rayoclon);
        var rayoclonExplosion=Instantiate(rayoExplosion,posicion, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        Destroy(rayoclonExplosion);

        yield return null;
    }
}
