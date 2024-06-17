using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Card card;
    public Image artworkImage;
    public Image characterArtImage;
    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public TMP_Text costText;
    public TMP_Text tipeText;
    public Image backGroundHability;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector2 originalPosition;
    private Canvas canvas;
    [SerializeField] private GameObject plater;
  
    [SerializeField]  public GameObject deckmanager;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = rectTransform.anchoredPosition;
    }
    private void Start()
    {
        deckmanager = GameObject.Find("GameManager");
        plater = GameObject.FindGameObjectWithTag(card.Pj);
       card.Player =plater.GetComponent<ShowLife>(); 
    }

    public void InitializeCard(Card newCard)
    {
        card = newCard;
        artworkImage.sprite = card.Art;
        characterArtImage.sprite = card.ArtCharacter;
        nameText.text = card.CardName;
        descriptionText.text = card.CardHability;
        tipeText.text = card.CardType;
        costText.text = card.Cost.ToString();
        if (card.CardType == "Habilidad")
        {
            backGroundHability.color = Color.yellow;
        }
        else if (card.CardType == "Ataque")
        {
            backGroundHability.color = Color.red;
        }
        else if (card.CardType == "Magia")
        {
            backGroundHability.color = Color.blue;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;

        if (eventData.pointerCurrentRaycast.gameObject != null)
        {
            DropZone dropZone = eventData.pointerCurrentRaycast.gameObject.GetComponent<DropZone>();
            if (dropZone != null&& deckmanager.GetComponent<CombatManager>().Energy>=card.Cost)
            {
                dropZone.OnDrop(eventData);
                Destroy(gameObject);
                deckmanager.GetComponent<DeckManager>().CardToGraveyar(card);
                deckmanager.GetComponent<CombatManager>().Energy-=card.Cost;
                
            }
            else
            {
                rectTransform.anchoredPosition = originalPosition;
            }
        }
        else
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}