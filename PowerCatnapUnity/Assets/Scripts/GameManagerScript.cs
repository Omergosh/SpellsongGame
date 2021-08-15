using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    BUBBLE_PAW,
    BURST
}

public class GameManagerScript : MonoBehaviour
{
    List<CardType> deck = new List<CardType>(4);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(deck[1]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
