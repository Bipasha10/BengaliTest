using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delegates
{
    public delegate void BoardCreated(int count);
    public static BoardCreated OnBoardCreated;

    public delegate void CardFlipped(Card card);
    public static CardFlipped OnCardFlipped;

    public delegate void CardMatched();
    public static CardMatched OnCardMatched;

    public delegate void CardTurned();
    public static CardTurned OnCardTurned;

    public delegate void GameOver();
    public static GameOver OnGameOver;
}
