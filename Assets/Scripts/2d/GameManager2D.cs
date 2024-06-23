using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager2D : MonoBehaviour
{
    [SerializeField] private CombatSO combat;
    [SerializeField] private GameObject tranformBegin;
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
    [SerializeField] private PlayerSO playerSOlevel1;
    private void Awake()
    {

        if (!combat.firstTime)
        {
            tranformBegin.transform.position = combat.positionpj;
          combat.positionpj = new Vector3(tranformBegin.transform.position.x,tranformBegin.transform.position.y) ;
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
           InciateDeckManager("Defense"); 



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
            datosPlayer.ObjectDeck = playerSOlevel1.ObjectDeck;
            datosPlayer.deck = playerSOlevel1.deck;
            datosPlayer.deckMax = playerSOlevel1.deckMax;
            datosPlayer.hP = playerSOlevel1.hP;
            datosPlayer.hPmax = playerSOlevel1.hPmax;
            datosPlayer.attack = playerSOlevel1.attack;
            datosPlayer.magic = playerSOlevel1.magic;
            datosPlayer.defense = playerSOlevel1.defense;
            datosPlayer.defenseMagic = playerSOlevel1.defenseMagic;
            datosPlayer.energy = playerSOlevel1.energy;
            datosPlayer.exp = playerSOlevel1.exp;
            datosPlayer.expMax = playerSOlevel1.expMax;
            datosPlayer.level = playerSOlevel1.level;
            datosPlayer.vel = playerSOlevel1.vel;
            datosPlayer.Pj = playerSOlevel1.Pj;
            datosPlayer.image = playerSOlevel1.image;
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
        }
    }
}
