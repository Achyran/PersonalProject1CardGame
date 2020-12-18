using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameMaster.player player;
    public List<GameObject> cards;
    private int oldCardCount;
    public int handAmound()
    {
        return cards.Count;
    }

    private void Update()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].transform.position = new Vector3(i,this.transform.position.y,0) ;

        }
    }

}
