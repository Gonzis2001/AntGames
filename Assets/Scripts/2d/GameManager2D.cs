using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2D : MonoBehaviour
{
    [SerializeField] private CombatSO combat;
    [SerializeField] private GameObject pj;
    [SerializeField] private GameObject canvasMenu;
    [SerializeField] private PlayerSO datosPlayer;
    [SerializeField] private TMP_Text hptext;
    [SerializeField] private TMP_Text attackText;
    [SerializeField] private TMP_Text magicText;
    [SerializeField] private TMP_Text defenseText;
    [SerializeField] private TMP_Text magicDefenseText;
    [SerializeField] private TMP_Text energytext;
    [SerializeField] private TMP_Text velText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text expText;
    [SerializeField] private Image expbar;

    [SerializeField] private GameObject deckmenu;
    [SerializeField] private GameObject deckmenucards;
    [SerializeField] private GameObject scrollbar;
    [SerializeField] private GameObject cardUI;
    private void Awake()
    {

        if (!combat.firstTime)
        {
            combat.positionpj = Vector2.zero;
            combat.id.Clear();
            combat.firstTime = true;
        }
        if (combat.positionpj != null)
        {
            pj.transform.position = new Vector3 (combat.positionpj.x,combat.positionpj.y,pj.transform.position.z);

        }

    }
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.I)) 
        {
              if(canvasMenu.activeInHierarchy==false) 
                {
                canvasMenu.SetActive(true);
                hptext.text = "HP: " + datosPlayer.hP + "/" + datosPlayer.hPmax;
                attackText.text = "Ataque: " + datosPlayer.attack;
                magicText.text ="Magia: "+datosPlayer.magic;
                defenseText.text ="Defensa: "+ datosPlayer.defense;
                magicDefenseText.text = "Defensa Magica: " + datosPlayer.defenseMagic;
                energytext.text = "Energia: " + datosPlayer.energy;
                velText.text ="Velocidad: "+ datosPlayer.vel;
                expText.text = datosPlayer.exp + "/" + datosPlayer.expMax;
                levelText.text = "Lv: " + datosPlayer.level;
                 if (datosPlayer.expMax > 0)
                {
                    expbar.fillAmount = (datosPlayer.exp / datosPlayer.expMax);

                }
                Time.timeScale = 0;

                } 
              else if (canvasMenu.activeInHierarchy == true)
            {
                canvasMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        
        
        
        
        }
    }
    public void DeckMenu()
    {
        if(deckmenu.activeInHierarchy == false)
        {
        scrollbar.SetActive(true);
        deckmenu.SetActive(true); 
           InciateDeckManager("Attack");
            InciateDeckManager("BigAttack");
            InciateDeckManager("Libra");
            InciateDeckManager("MagicAttack");
            //InciateDeckManager("Libra"); defense



        }
        else if (deckmenu.activeInHierarchy == true)
        {
            scrollbar.SetActive(false);
            deckmenu.SetActive(false);
        }
    }
    private void InciateDeckManager(string nombre)
    {
       List<Card> listattack1 =new List<Card>();
        for (int i = 0; i < datosPlayer.deck.Count; i++)
        {
            if (datosPlayer.deck[i].name == nombre)
            {
                listattack1.Add(datosPlayer.deck[i]);
               var card= Instantiate(cardUI,deckmenucards.transform);
              
                card.GetComponent<ActivarDeactivar>().cardActivate = datosPlayer.deck[i];

            }
        }
        int cardactivate=listattack1.Count;
        listattack1.Clear();
        for (int i = 0; i < datosPlayer.deckMax.Count; i++)
        {
            if (datosPlayer.deckMax[i].name == nombre)
            {
                listattack1.Add(datosPlayer.deckMax[i]);
            }
        }
        for (int i = 0; i < (listattack1.Count-cardactivate); i++)
        {
            var card = Instantiate(cardUI, deckmenucards.transform);

            card.GetComponent<ActivarDeactivar>().cardActivate = listattack1[i];
            card.GetComponent<ActivarDeactivar>().active = true;
        }
        listattack1.Clear();
    }
    public void ExitPause()
    {
        if (canvasMenu.activeInHierarchy == true)
        {
            canvasMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void BackMenu()
    {
        if (canvasMenu.activeInHierarchy == true)
        {
            
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
