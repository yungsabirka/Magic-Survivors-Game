using UnityEngine;

public class PauseHandler
{
    private bool _isPaused;

    public bool IsPaused => _isPaused;

    public void SetPause(bool isPaused)
    {
        _isPaused = isPaused;
        Time.timeScale = _isPaused ? 0f : 1f;
    }
}

