using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource flipAudio, matchAudio, mismatchAudio, gameoverAudio;

    private void OnEnable()
    {
        Delegates.OnCardFlipped += OnCardFlipped;
        Delegates.OnCardMatched += OnCardMatched;
        Delegates.OnCardTurned += OnCardTurned;
        Delegates.OnGameOver += OnGameOver;
    }

    private void OnCardFlipped(Card card)
    {
        PlayFlip();
    }

    private void OnCardMatched()
    {
        PlayMatch();
    }

    private void OnCardTurned()
    {
        PlayMismatch();
    }

    private void OnGameOver()
    {
        PlayGameOver();
    }

    private void PlayFlip()
    {
        flipAudio.Play();
    }

    private void PlayMatch()
    {
        matchAudio.Play();
    }

    private void PlayMismatch()
    {
        mismatchAudio.Play();
    }

    private void PlayGameOver()
    {
        gameoverAudio.Play();
    }
}