using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI matchValue;
    [SerializeField] private TextMeshProUGUI turnValue;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI totalScoreValue;
    [SerializeField] private GameObject gameOverScreen;
    private int matchVal, turnVal;

    private void ResetData()
    {
        matchVal = turnVal = 0;
    }

    private void OnEnable()
    {
        Delegates.OnCardMatched += OnCardMatched;
        Delegates.OnCardTurned += OnCardTurned;
        Delegates.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Delegates.OnCardMatched -= OnCardMatched;
        Delegates.OnCardTurned -= OnCardTurned;
        Delegates.OnGameOver -= OnGameOver;
    }

    private void OnCardTurned()
    {
        turnVal++;
        turnValue.text = turnVal.ToString();
    }

    private void OnCardMatched()
    {
        matchVal++;
        matchValue.text = matchVal.ToString();
    }

    private void OnGameOver(int score)
    {
        int prevScore = SaveSystem.instance.LoadScore();
        int totalScore = prevScore + score;
        SaveSystem.instance.SaveScore(totalScore);
        scoreValue.text = $"Current Score: {score}";
        totalScoreValue.text = $"Total Score: {totalScore}";
        gameOverScreen.SetActive(true);
    }
}
