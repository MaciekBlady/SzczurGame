using UnityEngine;

public class SczurController : MonoBehaviour
{
    private const string HORIZONTAL_NAME = "Horizontal";
    private const string VERITCAL_NAME = "Vertical";

    private readonly int m_AnimatorHorizontal = Animator.StringToHash(HORIZONTAL_NAME);
    private readonly int m_AnimatorVertical = Animator.StringToHash(VERITCAL_NAME);
    
    [SerializeField] 
    private Animator m_Animator = null;    
    
    [SerializeField] 
    private SpriteRenderer m_SpriteRenderer = null;

    [SerializeField] 
    private float m_MovementSpeed = 10.0f;

    private float m_Horizontal = 0.0f;
    private float m_Vertical = 0.0f;

    private bool m_FacingRight = true;
    
    private void Update()
    {
        m_Horizontal = Input.GetAxis(HORIZONTAL_NAME);
        m_Vertical = Input.GetAxis(VERITCAL_NAME);
    
        m_Animator.SetFloat(m_AnimatorHorizontal, m_Horizontal);
        m_Animator.SetFloat(m_AnimatorVertical, m_Vertical);

        if (m_FacingRight != m_Horizontal > 0.0f)
        {
            m_FacingRight = !m_FacingRight;
            m_SpriteRenderer.flipX = !m_FacingRight;
        }
    }

    private void FixedUpdate()
    {
        Vector3 translation = (Vector3.forward * m_Vertical + Vector3.right * m_Horizontal) * (m_MovementSpeed * Time.deltaTime);
        transform.Translate(translation);
    }
}