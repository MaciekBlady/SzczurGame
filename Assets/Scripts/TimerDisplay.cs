using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField]
    private Text m_TimerText;

    public void SetTime(float time)
    {
        m_TimerText.text = time.ToString("0:00");
    }
}
