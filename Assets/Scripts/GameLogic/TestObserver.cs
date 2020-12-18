using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.current.event_upkeep += Upkeep_Debugg;
        GameMaster.current.event_main1 += Main1_Debugg;
        GameMaster.current.event_battle += Battle_Debugg;
        GameMaster.current.event_main2 += Main2_Debugg;
        GameMaster.current.event_end += End_Debugg;
    }

    void Upkeep_Debugg(GameMaster.player pPlayer, int pTurne)
    {
        Debug.Log("Upkeep Sucsessfull       Current Player = " + pPlayer +"         Current Turne = " + pTurne );
    }
    void Main1_Debugg(GameMaster.player pPlayer, int pTurne)
    {
        Debug.Log("Main1 Sucsesfull         Current Player = " + pPlayer + "         Current Turne = " + pTurne);
    }
    void Battle_Debugg(GameMaster.player pPlayer, int pTurne)
    {
        Debug.Log("Battle Sucsessfull       Current Player = " + pPlayer + "         Current Turne = " + pTurne);
    }
    void Main2_Debugg(GameMaster.player pPlayer, int pTurne)
    {
        Debug.Log("Main2 Sucsessfull        Current Player = " + pPlayer + "         Current Turne = " + pTurne);
    }
    void End_Debugg(GameMaster.player pPlayer, int pTurne)
    {
        Debug.Log("End Sucsessfull          Current Player = " + pPlayer + "         Current Turne = " + pTurne);
    }

    private void OnDestroy()
    {
        GameMaster.current.event_upkeep -= Upkeep_Debugg;
        GameMaster.current.event_main1 -= Main1_Debugg;
        GameMaster.current.event_battle -= Battle_Debugg;
        GameMaster.current.event_main2 -= Main2_Debugg;
        GameMaster.current.event_end -= End_Debugg;
    }

}
