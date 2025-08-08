using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI matchValue;
    [SerializeField] private TextMeshProUGUI turnValue;
    [SerializeField] private TextMeshProUGUI scoreValue;
    [SerializeField] private TextMeshProUGUI totalScoreValue;
    [SerializeField] private GameObject gameOverScreen;

    [SerializeField] private GameObject selectionScreen, gameScreen;

    private int matchVal, turnVal;

    private void OnEnable()
    {
        Delegates.OnGameScreenOpened += OpenGameScreen;
        Delegates.OnCardMatched += OnCardMatched;
        Delegates.OnCardTurned += OnCardTurned;
        Delegates.OnGameOver += OnGameOver;
    }

    private void OnDisable()
    {
        Delegates.OnGameScreenOpened -= OpenGameScreen;
        Delegates.OnCardMatched -= OnCardMatched;
        Delegates.OnCardTurned -= OnCardTurned;
        Delegates.OnGameOver -= OnGameOver;
    }
    private void ResetData()
    {
        matchVal = turnVal = 0;
        UpdateUI();
    }
    private void OpenGameScreen(int row, int col)
    {
        Constants.gridRow = row;
        Constants.gridCol= col;
        gameScreen.SetActive(true);
        selectionScreen.SetActive(false);
    }

    private void OnCardTurned()
    {
        turnVal++;
        UpdateUI();
    }

    private void OnCardMatched()
    {
        matchVal++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        matchValue.text = matchVal.ToString();
        turnValue.text = turnVal.ToString();
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

    public void Replay()
    {
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        selectionScreen.SetActive(true);
        ResetData();
    }
}
