using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CardType
{
    BUBBLE_PAW,
    BURST
}

public class GameManagerScript : MonoBehaviour
{

    // Resources
    public GameObject cardPrefab;
    public GameObject glyphPrefab;

    // Card-related nonsense
    List<CardType> deck = new List<CardType>();
    public List<CardType> hand = new List<CardType>();
    public int handSize = 5;

    // Display objects/variables
    public List<GameObject> cardHandDisplay = new List<GameObject>();
    public float handSeparationMargin = 2f;

    // Start is called before the first frame update
    void Start()
    {
        hand = new List<CardType>(handSize);
        AddCardsToDeck(handSize * 3);
        Debug.Log(deck[0]);
        Debug.Log(deck[3]);
        Debug.Log(deck[deck.Count - 1]);
        Debug.Log(deck.Count);

        ShuffleDeck();
        PopulateHandFromDeck();
        Debug.Log(hand.Count);
        Debug.Log(deck.Count);
        PlayCard();
        Debug.Log(hand.Count);
        Debug.Log(hand.Capacity);
        for (int i=0; i< hand.Count; i++)
        {
            Debug.Log($"Card {i}: {hand[i]}");
        }
        foreach (CardType card in hand)
        {
            Debug.Log(card);
        }

        InitializeCardDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCardDisplay();
    }

    void InitializeCardDisplay()
    {
        cardHandDisplay = new List<GameObject>(handSize);
        for (int i = 0; i < cardHandDisplay.Capacity; i++)
        {
            cardHandDisplay.Add(Instantiate(cardPrefab));
        }
        UpdateCardDisplay();
    }

    void UpdateCardDisplay()
    {
        for (int i = 0; i < cardHandDisplay.Capacity; i++)
        {
            if (i < hand.Count)
            {
                cardHandDisplay[i].SetActive(true);
                SetCardDisplay(cardHandDisplay[i], hand[i]);

                cardHandDisplay[i].transform.position = new Vector3(
                    ((-0.5f * handSeparationMargin) * (hand.Count - 1))
                        + (i * handSeparationMargin),
                    //-3f + (1f * handSeparationMargin * i),
                    -3f,
                    0
                    );
            }
            else
            {
                cardHandDisplay[i].SetActive(false);
            }
        }
    }

    void SetCardDisplay(GameObject cardDisplayGameObject, CardType cardType)
    {
        CardDisplayScript cardScript = cardDisplayGameObject.GetComponent<CardDisplayScript>();
        cardScript.SetCard(cardType);
    }

    public void ShuffleDeck()
    {
        deck = deck.OrderBy(x => Random.value).ToList<CardType>();
    }
    
    public void PlayCard()
    {
        // Plays currently selected card from hand.
        int indexOfCardToPlay = 0;
        CardType cardToPlay = hand[indexOfCardToPlay];

        // TODO: insert code to play card ability here

        // Remove used card from hand afterwards.
        hand.RemoveAt(indexOfCardToPlay);
    }

    public bool PopulateHandFromDeck()
    {
        // Returns true if any cards were moved from the deck to the hand, and false otherwise.
        // Reasons may include: hand is already full, or deck is empty (no cards left to draw).
        if(hand.Count < handSize && deck.Count > 0)
        {
            int cardsToDraw = handSize - hand.Count;
            cardsToDraw = (int)Mathf.Min(cardsToDraw, deck.Count);
            for (int i = 0; i < cardsToDraw; i++)
            {
                hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
            }
        }

        return false;
    }

    public void AddCardsToDeck(int numberOfNewCards = 2)
    {
        for(int i=0; i < numberOfNewCards; i++)
        {
            if (deck.Count % 2 == 0)
            {
                deck.Add(CardType.BUBBLE_PAW);
            }
            else
            {
                deck.Add(CardType.BURST);
            }
        }
    }
}
