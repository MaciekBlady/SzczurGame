using UnityEngine;
using UnityEngine.Video;

public class MovieController : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer m_Player = null;
    
    private void Awake()
    {
        m_Player.Play();
        m_Player.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {   
        m_Player.Stop();
        GameManager.Instance.LoadArena();
    }
}
