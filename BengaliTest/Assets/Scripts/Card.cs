using UnityEngine;
using UnityEngine.UI;
using System;

public class Card : MonoBehaviour
{
    public int cardId;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Image image;
    private bool isFlipped = false;
    private bool isMatched = false;

    private void Start()
    {
        ResetCard();
    }

    public void Init(int id, Sprite front)
    {
        cardId = id;
        frontSprite = front;
    }

    public void ResetCard()
    {
        isFlipped = false;
        isMatched = false;
        image.sprite = backSprite;
    }

    public void OnClick()
    {
        if (!isFlipped && !isMatched)
        {
            Flip();
        }
    }

    public void Flip()
    {
        isFlipped = true;
        image.sprite = frontSprite;
    }

    public void Match()
    {
        isMatched = true;
    }

    public void Mismatch()
    {
        isFlipped = false;
        image.sprite = backSprite;
    }

    public bool IsMatched() => isMatched;
    public int GetId() => cardId;
}