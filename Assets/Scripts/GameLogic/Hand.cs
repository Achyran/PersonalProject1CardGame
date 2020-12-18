using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameMaster.player player;
    public List<GameObject> cards;
    public Field field;
    private int oldCardCount;
    private void Start()
    {
        GameMaster.current.event_CardIsPlayed += PlayCard;
    }

    private void PlayCard(GameObject pPcard)
    {
        if (cards.Contains(pPcard))
        {
            field.cards.Add(pPcard);
            cards.Remove(pPcard);
            pPcard.transform.SetParent(field.transform);
        }
    }

    private void OnDestroy()
    {
        GameMaster.current.event_CardIsPlayed -= PlayCard;
    }

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
