using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckManager : MonoBehaviour
{
    [SerializeField] private List<Card> deck;
    public List<Card> hand;
    [SerializeField] private List<Card> graveyard;
    [SerializeField] private List<Card> ObjectDeck;
    [SerializeField] private Transform handTransform;
    [SerializeField] private int numdraw;
    [SerializeField] private int maxhand;
   [SerializeField] private GameObject cardPrefab;
    [SerializeField] private TMP_Text deckText;
    [SerializeField] private TMP_Text graveyardText;
    [SerializeField] private bool canDrawObject;

    public bool CanDrawObject { get => canDrawObject; set => canDrawObject = value; }
   



    void Start()
    {
        ShuffleDeck();
        DrawHand();
        canDrawObject = true;
    }
    private void Update()
    {
        deckText.text=deck.Count.ToString();
        graveyardText.text = graveyard.Count.ToString();
    }

  public  void DrawHand()
    {
       
        numdraw=maxhand-hand.Count;
        Debug.Log(numdraw);
        for (int i = 0; i < numdraw; i++) 
        {
            DrawCard();
        }
    }

    void DrawCard()
    {
        if (deck.Count <= 0)
        {
            int rebarajar=graveyard.Count;
            for (int i = 0;i < rebarajar;i++)
            {
                Card drawnCard = graveyard[0];
                graveyard.RemoveAt(0);
                deck.Add(drawnCard);
            }
            ShuffleDeck() ;
        }
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
    public void DrawObject()
    {
        if (ObjectDeck.Count > 0 && canDrawObject)
        {
            canDrawObject = false;
            Card drawnCard = ObjectDeck[0];
            ObjectDeck.RemoveAt(0);
            hand.Add(drawnCard);


            GameObject cardUI = Instantiate(cardPrefab, handTransform);
            DraggableCard draggableCard = cardUI.GetComponent<DraggableCard>();
            draggableCard.InitializeCard(drawnCard);


        }
    }


}
