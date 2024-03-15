using UnityEngine;

// 确保此脚本附加的对象有Collider组件
[RequireComponent(typeof(Collider))]
public class PlayAudioOnClick : MonoBehaviour
{
    public AudioClip sound; // 用于播放的音频剪辑
    private AudioSource audioSource; // AudioSource组件变量

    void Start()
    {
        // 获取或添加AudioSource组件
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = sound; // 设置音频源的音频剪辑
    }

    // 当鼠标点击此对象时调用
    void OnMouseDown()
    {
        // 播放音频
        audioSource.Play();
    }
}
