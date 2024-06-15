using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLife : MonoBehaviour
{
    [SerializeField] private PlayerSO playerSO;
    
    [SerializeField] private Transform cameras;

    private Canvas canva;
    private Image lifeBar;
    private void Start()
    {
        lifeBar = GetComponentInChildren<Image>();
        canva = GetComponentInChildren<Canvas>();
        cameras = GameObject.Find("Main Camera").transform;
    }

    private void Update()
    {
        lifeBar.fillAmount = playerSO.hP/playerSO.hPmax;
        ChangeColorLifeBar();
        canva.transform.LookAt(cameras);
        canva.transform.rotation = new Quaternion(canva.transform.rotation.x, 0, 0, canva.transform.rotation.w);
    }
    private void ChangeColorLifeBar()
    {
        
        if (lifeBar.fillAmount >= 0.8f)
        {
            lifeBar.color = Color.green;

        }
        else if (lifeBar.fillAmount>=  0.3f)
        {
            lifeBar.color = Color.yellow;
        }
        else if(lifeBar.fillAmount >=0)
        {
            lifeBar.color = Color.red;
        }
    }
}
