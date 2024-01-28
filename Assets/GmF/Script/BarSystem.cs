using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSystem : MonoBehaviour
{
    public static BarSystem Instance = null;

    public Image GoodBarImage = null;
    public Image GoodBarArrowImage = null;
    public Image BadBarImage = null;
    public Image BadBarArrowImage = null;

    private int GoodMaxValue = 100;
    private int GoodCurrentValue = 100;
    private int GoodStartValue = 20;
    private int BadMaxValue = 100;
    private int BadCurrentValue = 100;
    private int BadStartValue = 20;
    private Vector2 GoodArrowCurrentPos = Vector2.zero;
    private Vector2 BadArrowCurrentPos = Vector2.zero;

    public bool Test_Reset = false;
    public bool Test_SetChangeValue = false;
    public int Test_AddGoodValue = 0;
    public int Test_AddBadValue = 0;
    public bool Test_SetMaxValue = false;
    public int Test_SetGoodMaxValue = 100;
    public int Test_SetBadMaxValue = 100;
    public int Test_SetGoodStartValue = 20;
    public int Test_SetBadStartValue = 20;

    private void Awake()
    {
        Instance = this;
        Init();
    }

    public void Init()
    {
        Reset();
    }

    public void Setup(int goodMaxValue, int badMaxValue, int goodStartValue, int badStartValue)
    {
        GoodMaxValue = Mathf.Max(1, goodMaxValue);
        BadMaxValue = Mathf.Max(1, badMaxValue);
        GoodStartValue = Mathf.Clamp(goodStartValue, 0, GoodMaxValue);
        BadStartValue =Mathf.Clamp(badStartValue, 0, badStartValue);
        Reset();
    }

    public void Reset()
    {
        GoodCurrentValue = GoodStartValue;
        BadCurrentValue = BadStartValue;
        UpdateImage();
    }

    /// <summary>
    /// 修改數值
    /// </summary>
    /// <param name="goodValue">增減值</param>
    /// <param name="badValue">增減值</param>
    public void AddValue(int goodValue, int badValue)
    {
        GoodCurrentValue = Mathf.Clamp(GoodCurrentValue + goodValue, 0, GoodMaxValue);
        BadCurrentValue = Mathf.Clamp(BadCurrentValue + badValue, 0, GoodMaxValue);
        UpdateImage();
    }

    private void UpdateImage()
    {
        GoodBarImage.fillAmount = GoodCurrentValue == 0 ? 0 : (float)GoodCurrentValue / (float)GoodMaxValue;
        BadBarImage.fillAmount = BadCurrentValue == 0 ? 0 : (float)BadCurrentValue / (float)BadMaxValue;
        GoodBarArrowImage.rectTransform.anchoredPosition = new Vector3(GoodBarArrowImage.rectTransform.anchoredPosition.x, (GoodBarImage.rectTransform.rect.height * GoodBarImage.fillAmount) + (-1 * GoodBarImage.rectTransform.rect.height / 2),  0);
        BadBarArrowImage.rectTransform.anchoredPosition = new Vector3(BadBarArrowImage.rectTransform.anchoredPosition.x, (BadBarImage.rectTransform.rect.height * BadBarImage.fillAmount) + (-1 * BadBarImage.rectTransform.rect.height / 2), 0);
    }

    public void Update()
    {
        if (Test_SetChangeValue)
        {
            Test_SetChangeValue = false;
            AddValue(Test_AddGoodValue, Test_AddBadValue);
        }

        if (Test_SetMaxValue)
        {
            Test_SetMaxValue = false;
            Setup(Test_SetGoodMaxValue, Test_SetBadMaxValue, Test_SetGoodStartValue, Test_SetBadStartValue);
        }

        if (Test_Reset)
        {
            Test_Reset = false;
            Reset();
        }

    }
}
