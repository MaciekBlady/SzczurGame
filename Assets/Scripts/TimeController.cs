using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : ASingleton<TimeController>
{
    [SerializeField]
    private TimerDisplay m_Display = null;
    
    [SerializeField]
    private float m_TimeLimit = 30.0f;

    private float m_AccumuatedTime = 0.0f;

    private bool m_Stopped = false;
    
    private void Update()
    {
        if (m_Stopped)
        {
            return;
        }
        
        m_AccumuatedTime += Time.deltaTime;
        m_AccumuatedTime = Mathf.Clamp(m_AccumuatedTime, 0.0f, m_TimeLimit);
        
        m_Display.SetTime(m_AccumuatedTime);
        
        if (m_AccumuatedTime >= m_TimeLimit)
        {
            GameManager.Instance.LoadOutro();
        }
    }

    public void Stop()
    {
        m_Stopped = true;
    }
}
