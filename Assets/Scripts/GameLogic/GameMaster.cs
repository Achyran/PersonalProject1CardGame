using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class GameMaster : MonoBehaviour
{


    //--------------------------Singelton Reference-----------------//
    public static GameMaster current;
    private void Awake()
    {
        current = this;
    }

    //--------------------------------Variables---------------------//
    public enum player
    {
        One = 0,
        Two = 1
    }
    public enum phase
    {
        upkeep = 0,
        main1 = 1,
        battle = 2,
        main2 = 3,
        end = 4
    }
    public static player curentPlayer;
    public static phase curentPhase;
    //------------------------------GameStats------------------------//
    public int StartHP;
    public int StartHand;
    public int maxHandSize;
    public int curentTurne = 1;
    public List<GameObject> Cardlist;   // holds the card prefabs
    //---------------------------------------------------------------//
    public int PlayerOneHP;
    public int PlayerTwoHP;
    public int[] PlayerMana = { 10, 10 };
    private bool eventTriggerd = false;

    private void Start()
    {
        PlayerOneHP = StartHP;
        PlayerTwoHP = StartHP;
        StartGame(StartHand);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Nextphase();
        }
        Debuginfos();

        switch (curentPhase)
        {
            case phase.upkeep:
                if (!eventTriggerd)
                {
                    Upkeep(curentPlayer,curentTurne);
                }
                break;
            case phase.main1:
                if (!eventTriggerd)
                {
                    Main1(curentPlayer,curentTurne);
                }
                break;
            case phase.battle:
                if (!eventTriggerd)
                {
                    Battle(curentPlayer,curentTurne);
                }
                break;
            case phase.main2:
                if (!eventTriggerd)
                {
                    Main2(curentPlayer,curentTurne);
                }
                break;
            case phase.end:
                if (!eventTriggerd)
                {
                    End(curentPlayer,curentTurne);
                }
                break;
            default:
                curentTurne++;
                curentPhase = phase.upkeep;
                if (curentPlayer == player.One) curentPlayer = player.Two;                
                else curentPlayer = player.One;
                break;
        }
    }
    

    public void Nextphase()
    {
        eventTriggerd = false;
        curentPhase++;
    }
    //----------------------Events----------------------------//
    public event Action<player,int> event_upkeep;
    public event Action<player,int> event_main1;
    public event Action<player,int> event_battle;
    public event Action<player,int> event_main2;
    public event Action<player,int> event_end;
    public event Action<int> event_StartGame;
    public event Action<GameObject> event_CardIsPlayed;

    public void StartGame(int pStartHand)
    {
        if(event_StartGame != null)
        {
            event_StartGame(StartHand);
        }
    }

    public void Upkeep(player pPlayer, int pTurne)
    {
        eventTriggerd = true;
        if(event_upkeep != null)
        {
            event_upkeep(pPlayer,pTurne);
        }
    }
    public void Main1(player pPlayer, int pTurne)
    {
        eventTriggerd = true;
        if (event_main1 != null)
        {
            event_main1(pPlayer, pTurne);
        }
    }
    public void Battle(player pPlayer, int pTurne)
    {
        eventTriggerd = true;
        if (event_battle != null)
        {
            event_battle(pPlayer, pTurne);
        }
    }
    public void Main2(player pPlayer, int pTurne)
    {
        eventTriggerd = true;
        if (event_main2 != null) 
        {
            event_main2(pPlayer, pTurne);
        }
    }
    public void End(player pPlayer, int pTurne)
    {
        eventTriggerd = true;
        if (event_end != null)
        {
            event_end(pPlayer, pTurne);
        }
    }

    public void PlayCard(player pPlayer, GameObject pCard, int pmana)
    {

        if (event_CardIsPlayed != null && pPlayer == curentPlayer )           //add mana cost
        {
            if (PlayerMana[(int)curentPlayer] >= pmana)
            {
                PlayerMana[(int)curentPlayer] = PlayerMana[(int)curentPlayer] - pmana;
                event_CardIsPlayed(pCard);
            }
            else Debug.Log("Low Mana");
        }  
    
    }
    //-------------------------------------------------------//



    void Debuginfos()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(curentPhase + "   " + curentPlayer);
        }
    }


    //-----------------------Dokumentation----------------------//
    /* This script will be used as the gamemaster. At this moment 
     * it Resembels the Turn Structure.
     * Turns start at 1.
     * 
     * Controlls:
     * Press Space to adwance a phase 
     * Pres I to get informatino about the current Phase, Player and Turn
    */
}
