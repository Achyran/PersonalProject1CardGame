using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckSaveButton : MonoBehaviour
{
    public BoxCollider2D collider;
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            DeckCreator.current.SaveDeck();
        }
    }
}
