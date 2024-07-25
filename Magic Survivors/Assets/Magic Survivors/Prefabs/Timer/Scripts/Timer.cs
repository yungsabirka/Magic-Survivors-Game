using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<int> SecondsChanged;
    public event Action<int> MinutesChanged;

    private int _seconds;
    private int _minutes;
    private bool _isPaused;

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private void OnDisable()
    {
        StopCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        while (_isPaused == false)
        {
            yield return new WaitForSeconds(1);
            _seconds++;
            if(_seconds == 60)
            {
                _minutes++;
                MinutesChanged?.Invoke(_minutes);
                _seconds = 0;
            }
            SecondsChanged?.Invoke(_seconds);
        }
    }

    public void Pause()
    {
        _isPaused = true;
        StopCoroutine(StartTimer());
    }
    public void UnPause()
    {
        _isPaused = false;
        StartCoroutine(StartTimer());
    }
}

