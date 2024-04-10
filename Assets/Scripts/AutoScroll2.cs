using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class AutoScrollText : MonoBehaviour
{
    private Text textComponent;
    private RectTransform rectTransform;
    public float scrollSpeed = 20f; // 每秒垂直滚动单位数

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        rectTransform = GetComponent<RectTransform>();
    }

    // 逐字显示文本
    public void ShowText(string fullText, float delay)
    {
        StartCoroutine(ShowTextCoroutine(fullText, delay));
    }

    private IEnumerator ShowTextCoroutine(string fullText, float delay)
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            textComponent.text = fullText.Substring(0, i);
            if (i > 0 && fullText[i - 1] == '\n')
            {
                // 假设每次换行都需要滚动
                StartCoroutine(ScrollDown());
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator ScrollDown()
    {
        // 获取当前滚动的目标位置
        float targetPosY = rectTransform.anchoredPosition.y + textComponent.fontSize;
        // 持续移动直到达到目标位置
        while (rectTransform.anchoredPosition.y < targetPosY)
        {
            // 根据滚动速度逐渐改变anchoredPosition.y
            rectTransform.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
