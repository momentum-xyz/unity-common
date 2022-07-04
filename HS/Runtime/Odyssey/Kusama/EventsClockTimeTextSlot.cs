using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsClockTimeTextSlot : MonoBehaviour, ITextSlot
{
    public string label = "time";

    HS.MultiSurfaceDriver _surfaceDriver;

    bool _isCountingDown = false;
    float _deltaTimeSum = 0.0f;
    long _timeOfLatestUpdate;
    long _eraTimeInMs;

    void Awake()
    {
        _surfaceDriver = GetComponent<HS.MultiSurfaceDriver>();
    }

    public string GetLabel()
    {
        return label;
    }

    public void SetText(string label, string text)
    {
        Debug.Log("Got Event Time: " + text);

        if (_surfaceDriver == null) return;

        _eraTimeInMs = long.Parse(text);
        _timeOfLatestUpdate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        _isCountingDown = true;
        _surfaceDriver.SetClock(TimeSpan.FromMilliseconds(_eraTimeInMs));
    }

    void Update()
    {
        if (!_isCountingDown) return;

        _deltaTimeSum += Time.deltaTime;

        if (_deltaTimeSum < 1.0f) return;

        var _currentTimeInMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var _eraTimeElapsed = _eraTimeInMs - (_currentTimeInMs - _timeOfLatestUpdate);

        if (_eraTimeElapsed < 0) _eraTimeElapsed = 0;

        _surfaceDriver.SetClock(TimeSpan.FromMilliseconds(_eraTimeElapsed));
        _deltaTimeSum = 0.0f;

    }

}
