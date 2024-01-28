using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopControler : MonoBehaviour
{
    public Text tett = null;
    Image image = null;
    Vector3 orgSize = Vector3.zero;
    public float MouseOverSize = 1.2F;
    public Action OnClick = null;
    PopManager.PopTypeEnum popType = PopManager.PopTypeEnum.None;

    private void Awake()
    {
        orgSize = gameObject.transform.localScale;
    }

    public void Init()
    {
        tett.text = string.Empty;
    }

    public void Show(string showText, PopManager.PopTypeEnum set_popType, Action onClick = null)
    {
        tett.text = showText;
        OnClick = onClick;
        gameObject.SetActive(true);
        popType = set_popType;
        orgSize = gameObject.transform.localScale;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnMouseEnter()
    {
        gameObject.transform.localScale = orgSize * MouseOverSize;
    }

    public void OnMouseExit()
    {
        gameObject.transform.localScale = orgSize;
    }

    public void OnMouseClick()
    {
        Hide();
        OnClick?.Invoke();
        PopManager.Instance.OnClose(popType);
    }
}
