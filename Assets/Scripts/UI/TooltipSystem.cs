using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem instance;

    public ToolTip tip;

    public void Awake()
    {
        instance = this;
    }

    public static void Show(string content, string header="")
    {
        instance.tip.SetText(content, header);
        instance.tip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.tip.gameObject.SetActive(false);
    }
}
