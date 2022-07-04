using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraClockTextSlot : MonoBehaviour, ITextSlot
{
    public string label = "kusama_clock_era_time";

    HS.MultiSurfaceDriver _surfaceDriver;

    bool _isCountingDown = false;
    long _timeOfLatestUpdate;
    long _eraTimeInMs;

    float deltaTimeSum = 0.0f;

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
        Debug.Log("Got Era Time: " + text);

        if (_surfaceDriver == null) return;

        _eraTimeInMs = long.Parse(text);

        _timeOfLatestUpdate = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        _isCountingDown = true;

        _surfaceDriver.SetClock(TimeSpan.FromMilliseconds(_eraTimeInMs));

    }

    void Update()
    {
        if (!_isCountingDown) return;

        deltaTimeSum += Time.deltaTime;

        if (deltaTimeSum < 1.0f) return;

        var _currentTimeInMs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var _eraTimeElapsed = _eraTimeInMs - (_currentTimeInMs - _timeOfLatestUpdate);

        if (_eraTimeElapsed < 0) _eraTimeElapsed = 0;

        _surfaceDriver.SetClock(TimeSpan.FromMilliseconds(_eraTimeElapsed));
        deltaTimeSum = 0.0f;
    }



}
