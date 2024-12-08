using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer m_MeshRenderer = null;

    [SerializeField]
    private Vector2 m_ScrollSpeed;
    
    void Update()
    {
        m_MeshRenderer.sharedMaterial.mainTextureOffset += m_ScrollSpeed * Time.deltaTime;
    }
}
