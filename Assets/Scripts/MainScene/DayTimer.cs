using JiangH.Runtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public Button speedInc;
    public Button speedDec;
    public Toggle speedPause;

    public int speed { get; set; }
    public bool isSysPause { get; set; }

    public bool isUserPause => speedPause.isOn;

    public bool isPause => isSysPause || isUserPause;

    public int MAX_SPEED => 4;
    public int MIN_SPEED => 1;

    void Start()
    {
        isSysPause = false;

        speed = 1;

        speedInc.onClick.AddListener(() =>
        {
            speed++;
            UpdateSpeedControl();
        });

        speedDec.onClick.AddListener(() =>
        {
            speed--;
            UpdateSpeedControl();
        });

        speedPause.onValueChanged.AddListener((value) =>
        {
            UpdateSpeedControl();
        });

        StartCoroutine(OnTimer());
    }

    private void UpdateSpeedControl()
    {
        speedInc.interactable = !speedPause.isOn && speed < MAX_SPEED;
        speedDec.interactable = !speedPause.isOn && speed > MIN_SPEED;
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1.0f / speed);
        yield return new WaitUntil(() => !isPause);
        
        GSession.inst.OnDayInc();

        StartCoroutine(OnTimer());
    }
}
