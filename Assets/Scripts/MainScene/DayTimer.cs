using JiangH.Runtime;
using System.Collections;
using UnityEngine;

public class DayTimer : MonoBehaviour
{
    public int speed { get; set; }
    public bool isSysPause { get; set; }

    public bool isUserPause { get; set; }

    public bool isPause => isSysPause || isUserPause;

    private static int count;

    public void OnSpeedChanged(int value)
    {
        speed += value;
    }

    void Start()
    {
        isSysPause = false;

        speed = 1;

        StartCoroutine(OnTimer());
    }

    private IEnumerator OnTimer()
    {
        yield return new WaitForSeconds(1.0f / speed);
        yield return new WaitUntil(() => !isPause);

        count++;
        
        GSession.inst.OnDayInc();

        StartCoroutine(OnTimer());
    }
}
