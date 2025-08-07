using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI matchValue;
    [SerializeField] private TextMeshProUGUI turnValue;
    private int matchVal, turnVal;
    private int score = 0;

    private void ResetData()
    {
        matchVal = turnVal = 0;
    }

    private void OnEnable()
    {
        Delegates.OnCardMatched += OnCardMatched;
        Delegates.OnCardTurned += OnCardTurned;
    }

    private void OnDisable()
    {
        Delegates.OnCardMatched -= OnCardMatched;
        Delegates.OnCardTurned -= OnCardTurned;
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


}
