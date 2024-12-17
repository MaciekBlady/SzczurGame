using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ASingleton<GameManager>
{
    private const string SCENE_NAME_ARENA = "Arena";
    private const string SCENE_NAME_OUTRO = "Outro";
    
    public void LoadArena()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(SCENE_NAME_ARENA);
    } 
    
    public void LoadOutro()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(SCENE_NAME_OUTRO);
    }

    public void HandlePlayerHit()
    {
        if (!UIManager.IsSpawned)
        {
            return;
        }
        
        TimeController.Instance.Stop();
        UIManager.Instance.ShowGameOverPanel(HandleGameOverShown);
    }

    private void HandleGameOverShown()
    {
        LoadArena();
    }
}
