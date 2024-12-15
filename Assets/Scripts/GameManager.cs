using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : ASingleton<GameManager>
{
    private const string SCENE_NAME_ARENA = "Arena";
    
    public void LoadArena()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene(SCENE_NAME_ARENA);
    }

    public void HandlePlayerHit()
    {
        if (!UIManager.IsSpawned)
        {
            return;
        }
        
        UIManager.Instance.ShowGameOverPanel(HandleGameOverShown);
    }

    private void HandleGameOverShown()
    {
        LoadArena();
    }
}
