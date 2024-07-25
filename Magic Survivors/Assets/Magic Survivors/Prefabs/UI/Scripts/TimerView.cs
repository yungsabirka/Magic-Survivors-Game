using TMPro;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshProUGUI _timeView;

    private int _seconds;
    private int _minutes;

    private void OnEnable()
    {
        _timer.SecondsChanged += SetSeconds;
        _timer.MinutesChanged += SetMinutes;
    }

    private void OnDestroy()
    {
        _timer.SecondsChanged -= SetSeconds;
        _timer.MinutesChanged -= SetMinutes;
    }

    private void SetTimeView()
    {
        _timeView.text = $"{_minutes}:{_seconds}";
    }

    private void SetSeconds(int seconds)
    {
        _seconds = seconds;
        SetTimeView();
    }

    private void SetMinutes(int minutes)
    {
        _minutes = minutes;
        SetTimeView();
    }

    public void SetTimer(Timer timer)
    {
        _timer = timer;
        _timer.SecondsChanged += SetSeconds;
        _timer.MinutesChanged += SetMinutes;
    }
}
