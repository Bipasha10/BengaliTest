using UnityEngine;
using UnityEngine.UI;
using System;

public class Card : MonoBehaviour
{
    public int cardId;
    public Sprite frontSprite;
    public Sprite backSprite;
    public Image image;
    public Animator cardAnim;

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
            Delegates.OnCardFlipped?.Invoke(this);
        }
    }

    public void Flip()
    {
        isFlipped = true;
        image.sprite = frontSprite;
        cardAnim.Play(Constants.cardFlipAnim);
    }

    public void Match()
    {
        isMatched = true;
    }

    public void Mismatch()
    {
        cardAnim.Play(Constants.cardReverseFlipAnim);
        isFlipped = false;
        image.sprite = backSprite;
    }

    public bool IsMatched() => isMatched;
    public int GetId() => cardId;
}