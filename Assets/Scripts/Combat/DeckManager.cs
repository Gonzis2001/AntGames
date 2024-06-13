using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<Card> deck;
    [SerializeField] private List<Card> hand;
    [SerializeField] private List<Card> graveyard;
    [SerializeField] private Transform handTransform;
    [SerializeField] private int numdraw;
   [SerializeField] private GameObject cardPrefab;
    [SerializeField] private TMP_Text deckText;
    [SerializeField] private TMP_Text graveyardText;
    void Start()
    {
        ShuffleDeck();
        DrawHand();
    }
    private void Update()
    {
        deckText.text=deck.Count.ToString();
        graveyardText.text = graveyard.Count.ToString();
    }

    void DrawHand()
    {
        if(deck.Count <= 0)//si el mazo esta vacio barajea el mazo del cementeio
        {
            deck = graveyard;
            graveyard.Clear();
            ShuffleDeck();
        }
        for (int i = 0; i < numdraw; i++) 
        {
            DrawCard();
        }
    }

    void DrawCard()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            hand.Add(drawnCard);

           
            GameObject cardUI = Instantiate(cardPrefab, handTransform);
            DraggableCard draggableCard = cardUI.GetComponent<DraggableCard>();
            draggableCard.InitializeCard(drawnCard);
           

        }
        
    }
    void ShuffleDeck()
    {
        //baraja el mazo 
        System.Random rng = new System.Random();
        int n = deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = deck[k];
            deck[k] = deck[n];
            deck[n] = value;
        }
    }
    public void CardToGraveyar(Card card)
    {
        //remueve la carta jugada y se añade al cementerio
        hand.Remove(card);
        graveyard.Add(card);
    }
   
}
