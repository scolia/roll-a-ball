using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))] // 要求附着的对象必须要有AudioSource组件
public class ResetScene : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    public void Reset()
    {
        //播放音效并重置场景
        m_AudioSource.Play();
        // 延迟等待声音播放完毕后再重置场景, 若不延迟, 就会导致声音无法播放
        StartCoroutine(DelayedRest(m_AudioSource.clip.length)); 
    }

    IEnumerator DelayedRest(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }
}
