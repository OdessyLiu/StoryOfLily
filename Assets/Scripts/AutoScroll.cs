using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(ScrollRect))]
public class AutoScroll : MonoBehaviour
{
    private ScrollRect scrollRect;
    private Text textComponent;
    public float delay = 0.05f; // 文本显示每个字符的延迟时间

    private void Awake()
    {
        scrollRect = GetComponent<ScrollRect>();
        textComponent = scrollRect.content.GetComponent<Text>();
    }

    // 逐字显示文本并滚动到底部
    public void ShowText(string fullText)
    {
        StartCoroutine(ShowTextCoroutine(fullText));
    }

    private IEnumerator ShowTextCoroutine(string fullText)
    {
        textComponent.text = ""; // 开始前清空文本
        foreach (char c in fullText)
        {
            textComponent.text += c; // 添加一个字符
            ScrollToBottom(); // 滚动到底部
            yield return new WaitForSeconds(delay); // 等待指定的延迟
        }
    }

    // 立即滚动到底部
    private void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases(); // 更新画布以获取最新的UI元素布局
        scrollRect.verticalNormalizedPosition = 0f; // 设置滚动条位置到底部
    }
}
