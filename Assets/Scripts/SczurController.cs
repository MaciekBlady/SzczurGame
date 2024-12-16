using System;
using System.Collections;
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

    [SerializeField] 
    private float m_DamageFlickerTime = 0.05f;

    private float m_Horizontal = 0.0f;
    private float m_Vertical = 0.0f;

    [SerializeField] 
    private bool m_FacingRight = true;
    
    private Coroutine m_FlickereCoroutine;

    private void Update()
    {
        m_Horizontal = Input.GetAxis(HORIZONTAL_NAME);
        m_Vertical = Input.GetAxis(VERITCAL_NAME);
    
        m_Animator.SetFloat(m_AnimatorHorizontal, m_Horizontal);
        m_Animator.SetFloat(m_AnimatorVertical, m_Vertical);

        if ((m_FacingRight && m_Horizontal < -0.1f) || (!m_FacingRight && m_Horizontal > 0.1f))
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            if (m_FlickereCoroutine == null)
            {
                m_FlickereCoroutine = StartCoroutine(Flicker());
            }
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Projectile>() != null)
        {
            Destroy(other.gameObject);
            GameManager.Instance.HandlePlayerHit();
            
            if (m_FlickereCoroutine == null)
            {
                m_FlickereCoroutine = StartCoroutine(Flicker());
            }
        }
    }

    private IEnumerator Flicker()
    {
        Color previousColor = m_SpriteRenderer.sharedMaterial.color;

        m_SpriteRenderer.material.color = Color.red;
        yield return new WaitForSeconds(m_DamageFlickerTime);
        m_SpriteRenderer.material.color = previousColor;

        m_FlickereCoroutine = null;
        Destroy(gameObject);
    }
}
