using UnityEngine;
using System.Collections;
using System;

public class GameManager : MonoBehaviour
{
    public Card firstCard, secondCard;

    private Card r1, r2;
    private int totalMatchingItem = 0;
    private int score = 0;

    private void OnEnable()
    {
        Delegates.OnBoardCreated += OnBoardCreated;
        Delegates.OnCardFlipped += OnCardFlipped;
    }
    private void OnDisable()
    {
        Delegates.OnBoardCreated -= OnBoardCreated;
        Delegates.OnCardFlipped -= OnCardFlipped;
    }
    
    private void ResetData()
    {
        score = 0;
    }

    private void OnBoardCreated(int count)
    {
        totalMatchingItem = count;
    }

    public void OnCardFlipped(Card card)
    {
        if (firstCard == null)
        {
            firstCard = card;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            StartCoroutine(EvaluateMatch());
        }
    }

    IEnumerator EvaluateMatch()
    {
        r1 = firstCard;
        r2 = secondCard;
        firstCard = secondCard = null;
        yield return new WaitForSeconds(1f);
        Delegates.OnCardTurned?.Invoke();

        if (r1.GetId() == r2.GetId())
        {
            r1.Match();
            r2.Match();
            Delegates.OnCardMatched?.Invoke();
            score += 10;
            CheckGameOver();
        }
        else
        {
            r1.Mismatch();
            r2.Mismatch();
        }
    }

    private void CheckGameOver()
    {
        totalMatchingItem--;
        if(totalMatchingItem <= 0)
        {
            Delegates.OnGameOver?.Invoke(score);
            ResetData();
        }
    }
}