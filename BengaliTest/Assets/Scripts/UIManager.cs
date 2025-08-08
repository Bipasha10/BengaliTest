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
    [SerializeField] private GameObject gameOverScreen;
    private int matchVal, turnVal;
    private int score = 0;

    private void ResetData()
    {
        matchVal = turnVal = score = 0;
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
        score++;
    }

    private void OnGameOver()
    {
        scoreValue.text = $"Current Score: {score}";
        gameOverScreen.SetActive(true);
    }


}
