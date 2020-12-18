using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CardSelecTrigger : MonoBehaviour
{
    public BoxCollider2D collider;
    public int id;
    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)&& collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            DeckCreator.current.AddCard(id);
        }
        if (Input.GetMouseButtonDown(1) && collider.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)))
        {
            DeckCreator.current.RemoveCard(id);
        }
    }
}
