using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : ASingleton<UIManager>
{
    [SerializeField]
    private GameOverPanel m_GameOverPanel = null;

    public void ShowGameOverPanel(Action OnFinishedShowingGameOverPanel)
    {
        m_GameOverPanel.Show(OnFinishedShowingGameOverPanel);
    }
}
