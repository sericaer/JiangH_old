using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityUITable;

public class TooltipCell : StyleableTableCell<LabelCellStyle>
{
    public interface IToolTipCellData
    {
        string celltext { get; }
        string tooltipText { get; }
    }

    // Use this for initialization
    public Text label;

    public LazyUpdateTooltipTrigger tooltipTrigger;


    public override int GetPriority(MemberInfo member)
    {
        return 10;
    }

    public override bool IsCompatibleWithMember(MemberInfo memberInfo)
    {
        switch (memberInfo)
        {
            case FieldInfo field:
                return typeof(IToolTipCellData).IsAssignableFrom(field.FieldType);
            case PropertyInfo property:
                return typeof(IToolTipCellData).IsAssignableFrom(property.PropertyType);
            default:
                return false;
        }
    }

    void Start()
    {
        tooltipTrigger.funcGenerateTextInfo = GenerateTooltipText;
    }

    private IEnumerable<(string paramName, string text)> GenerateTooltipText()
    {
        var rslt = new List<(string paramName, string text)>();

        if (property == null || property.IsEmpty)
        {
            return rslt;
        }

        object o = property.GetValue(obj);
        if (o == null)
        {
            return rslt;
        }

        var tooltipData = o as IToolTipCellData;

        if(tooltipData.tooltipText != null)
        {
            rslt.Add(("BodyText", tooltipData.tooltipText));
        }

        return rslt;
    }

    void Update()
    {

    }

    public override void UpdateContent()
    {

        if (property == null || property.IsEmpty)
        {
            return;
        }

        object o = property.GetValue(obj);
        if (o == null)
        {
            return;
        }

        var tooltipData = o as IToolTipCellData;
        label.text = tooltipData.celltext;
    }
}