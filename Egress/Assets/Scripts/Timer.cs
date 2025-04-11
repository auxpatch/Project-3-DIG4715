using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField, Range(0, 24)] private int _hours;
    [SerializeField, Range(0, 60)] private int _minutes;
    [SerializeField, Range(0, 60)] private int _seconds;
    [SerializeField] private TMP_Text _clockFace;
    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        DisplayTime();
        StartCoroutine(Countdown());
        _gameOverPanel.SetActive(false);
    }

    private IEnumerator Countdown()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            if (_seconds == 0)
            {
                if (_minutes == 0)
                {
                    if (_hours == 0)
                    {
                        Debug.Log("Time out");
                        _gameOverPanel.SetActive(true);
                        yield break;
                    }

                    _hours--;
                    _minutes = 60;
                }

                _seconds = 60;
                _minutes--;
            }

            _seconds--;
            DisplayTime();
        }
    }

    private void DisplayTime()
    {
        string seconds = _seconds >= 10 ? _seconds.ToString() : $"0{_seconds}";
        string minutes = _minutes >= 10 ? _minutes.ToString() : $"0{_minutes}";
        string hours = _hours >= 10 ? _hours.ToString() : $"0{_hours}";

        _clockFace.text = $"{hours}:{minutes}:{seconds}";
    }
}
