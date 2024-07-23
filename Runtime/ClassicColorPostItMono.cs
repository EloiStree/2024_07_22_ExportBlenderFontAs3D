using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassicColorPostItMono : MonoBehaviour
{
    public Renderer[] m_renderer;
    public Material [] m_material;

    public void SetColor(Color color)
    {
        foreach (var r in m_renderer)
        {
            
            r.material.color = color;
        }
        foreach (var m in m_material)
        {
            m.color = color;
        }
    }
}
