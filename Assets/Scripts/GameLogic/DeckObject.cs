using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;

public class DeckObject : MonoBehaviour
{
    public string deckname;
    public GameMaster.player player;
    public List<int> cards;
    public int CurrendCardAmount;
    public Hand hand;

    private void Start()
    {
        LoadeDeck("TestDeck");
        CurrendCardAmount = cards.Count;
        GameMaster.current.event_upkeep += Turndraw;
        GameMaster.current.event_StartGame += DeckStartUp;
        if (hand == null)
        {
            Debug.LogError("Hand is Missing on Deck Player " + player);
        }
        else hand.player = player;
    }

    private void Turndraw(GameMaster.player pPlayer,int pturne)
    {
        if(pPlayer == player)
        {
            DrawCard(1);
        }

    }

    public void DrawCard(int pCardAmount)
    {
        int rest;
        if(GameMaster.current.maxHandSize < pCardAmount + hand.cards.Count)
        {
            rest = (pCardAmount + hand.cards.Count) - GameMaster.current.maxHandSize;
            Debug.Log(rest + " Cards Too many");
            pCardAmount -= rest;
        }
        
        Debug.Log(" Player  " + player + "   Has drawn " + pCardAmount + " Cards ");
        for (int i = 0; pCardAmount > i; i++)
        {
            hand.cards.Add(Instantiate(GameMaster.current.Cardlist[cards[cards.Count - 1]]));
            hand.cards[hand.cards.Count - 1].transform.SetParent(hand.transform);
            cards.RemoveAt(cards.Count -1);
        }
        CurrendCardAmount = cards.Count;
    }
    public void Shuffel()
    {
        cards = cards.OrderBy(x => Guid.NewGuid() ).ToList();
    }

    private void DeckStartUp(int pStartHand)
    {
        Shuffel();
        DrawCard(pStartHand);

    }


    private void LoadeDeck(string DeckFilename)
    {
        string loadstring = "Assets/SaveFiles/Decks/" + DeckFilename + ".json";
        if (File.Exists(loadstring))
        {
            string jsonstring = File.ReadAllText(loadstring);
            Debug.Log("FileFound");
            DeckBuffer buffer = new DeckBuffer();
            buffer = JsonUtility.FromJson<DeckBuffer>(jsonstring);
            cards = buffer.cards;
            deckname = buffer.DeckName;

        }
        else Debug.Log("File not Found");
    }
}
