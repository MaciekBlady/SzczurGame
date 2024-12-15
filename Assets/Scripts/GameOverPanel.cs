using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Image m_Image = null;
    
    [SerializeField]
    private GameObject m_ImageObject = null;
    
    [SerializeField]
    private GameObject m_TextObject = null;

    [SerializeField] 
    private float m_PunchInScaling = 0.1f;
    
    [SerializeField] 
    private float m_FadeInTime = 2.0f;
    
    [SerializeField] 
    private float m_HoldTime = 3.0f;

    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        m_ImageObject.SetActive(false);
        m_TextObject.SetActive(false);
    }
    
    public void Show(Action OnFinishedShowing)
    {
        m_ImageObject.SetActive(true);
        StartCoroutine(ShowCoroutine(OnFinishedShowing));
    }
    
    private IEnumerator ShowCoroutine(Action OnFinishedShowing)
    {
        float fadeInTimer = 0.0f;

        while (fadeInTimer < m_FadeInTime)
        {
            float progress = fadeInTimer / m_FadeInTime;;
            fadeInTimer += Time.deltaTime;

            Color color = m_Image.color;
            color.a = progress;
            m_Image.color = color;

            m_ImageObject.GetComponent<RectTransform>().localScale = Vector3.one * (1.0f + m_PunchInScaling * progress);
            yield return null;
        }

        m_TextObject.SetActive(true);
        yield return new WaitForSeconds(m_HoldTime);
        
        OnFinishedShowing.Invoke();
    }

}
