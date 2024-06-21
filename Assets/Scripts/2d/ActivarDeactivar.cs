using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActivarDeactivar : MonoBehaviour , IPointerClickHandler
{
    [SerializeField] private GameObject activeOpacity;
    [SerializeField] public Card cardActivate;
    [SerializeField] private PlayerSO deck;
    public bool active = false;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Image characterArtImage;
    [SerializeField] private Image ArtType;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text tipeText;
    [SerializeField] private Image backGroundHability;

    void Start()
    {

        InitializeCard();
    }
    public void InitializeCard( )
    {

        artworkImage.sprite = cardActivate.Art;
        ArtType.sprite = cardActivate.ArtType;
        characterArtImage.sprite = cardActivate.ArtCharacter;
        nameText.text = cardActivate.CardName;
        descriptionText.text = cardActivate.CardHability;
        tipeText.text = cardActivate.CardType;
        costText.text = cardActivate.Cost.ToString();
        backGroundHability.sprite = cardActivate.Artbackground;

    }


    void Update()
    {
        if (!active)
        {
            activeOpacity.SetActive(false);
        }
        else
        {
            activeOpacity.SetActive(true);
        }
    }
   public void OnPointerClick(PointerEventData eventData)
    {
        if (!active)//desactivar
        {
            deck.deck.Remove(cardActivate);
         

                active = true;
        }
        else//activar
        {
            deck.deck.Add(cardActivate);    
            
            active = false;
        }

        
       

    } 
    
}
