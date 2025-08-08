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

    private Image cardImg;
    [SerializeField]
    private GameObject childItem;
    private bool isFlipped = false;
    private bool isMatched = false;

    private void Start()
    {
        ResetCard();
        cardImg = GetComponent<Image>();
        childItem = transform.GetChild(0).gameObject;
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
        cardImg.enabled = false;
        cardAnim.Play(Constants.cardIdleAnim);
        childItem.SetActive(false);
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