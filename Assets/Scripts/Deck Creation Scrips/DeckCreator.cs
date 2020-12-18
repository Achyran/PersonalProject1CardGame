using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeckCreator : MonoBehaviour
{
    public int minCards;
    public int maxCards;
    public int allowedMultibles;
    public List<int> cards;

    //-----------------Singelton Reference---------//
    public static DeckCreator current;
    private void Awake()
    {
        current = this;
    }

    public void AddCard(int id)
    {
        if (cards.Count >= maxCards)
        {
            Debug.Log("Deck is Full");
            return;
        }
        int counter = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i] == id)
            {
                counter++;
            }
        }
        if (counter >= allowedMultibles)
        {
            Debug.Log("To many mulibles");
            return;
        }
        cards.Add(id);
    }
    public void RemoveCard(int id)
    {
        cards.Remove(id);
    }

    public void SaveDeck()
    {
        if (cards.Count >= minCards)
        {
            DeckBuffer deckBuffer = new DeckBuffer();
            deckBuffer.cards = cards;
            string jsonOut;
            jsonOut = JsonUtility.ToJson(deckBuffer);
            File.WriteAllText("Assets/SaveFiles/Decks/TestDeck.json", jsonOut);
            Debug.Log("Deck saved");
        }
        else Debug.Log("Faild To save : not enought cards");
    }
}