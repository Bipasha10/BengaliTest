using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Card firstCard, secondCard;

    private Card r1, r2;

    private void OnEnable()
    {
        Delegates.OnCardFlipped += OnCardFlipped;
    }
    private void OnDisable()
    {
        Delegates.OnCardFlipped -= OnCardFlipped;
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
        Delegates.OnCardTurned();

        if (r1.GetId() == r2.GetId())
        {
            r1.Match();
            r2.Match();
            Delegates.OnCardMatched();
        }
        else
        {
            r1.Mismatch();
            r2.Mismatch();
        }
    }
}