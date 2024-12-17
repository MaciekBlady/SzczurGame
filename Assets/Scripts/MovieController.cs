using UnityEngine;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    [SerializeField] 
    private RenderTexture m_RenderTexture = null;
    
    [SerializeField]
    private VideoPlayer m_Player = null;

    [SerializeField] 
    private bool m_QuitOnFinish = false;
    
    private void Awake()
    {
        GL.Clear(true, true, Color.clear);
        m_Player.Play();
        m_Player.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {   
        m_Player.Stop();
        
        if (m_QuitOnFinish)
        {
            Application.Quit();
        }
        else
        {
            GameManager.Instance.LoadArena();
        }
    }
}
