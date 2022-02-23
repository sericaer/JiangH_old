using ModelShark;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TooltipTrigger))]
public class LazyUpdateTooltipTrigger : MonoBehaviour
{
    public Func<IEnumerable<(string paramName, string text)>> funcGenerateTextInfo;

    private TooltipTrigger tooltipTrigger;
    void Start()
    {
        tooltipTrigger = GetComponent<TooltipTrigger>();
        tooltipTrigger.actionBeforPopup = BeforPopup;
    }

    void BeforPopup()
    {
        if (funcGenerateTextInfo != null)
        {
            var textInfo = funcGenerateTextInfo();
            foreach (var info in textInfo)
            {
                tooltipTrigger.SetText(info.paramName, info.text);
            }
        }
    }
}