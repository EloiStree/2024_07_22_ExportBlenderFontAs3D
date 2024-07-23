using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteLineFromPoolMono : MonoBehaviour
{
    public string m_lineToWrite="Hello World!";
    public ObjCharPoolMono m_charPool;
    public Transform m_whereToCreate;
    public float m_distanceBetween = 0.005f;
    public Vector2 m_offset = new Vector2(0.02f, 0.02f);
    public float m_height = 0.018f;
    public float m_width = 0.012f;
    public float m_depth = 0.001f;

    public int m_maxLineLength = 80;


    private void Reset()
    {
        m_whereToCreate = transform;
    }

    [ContextMenu("Create Elements")]
    public void CreateElements()
    {
       CharPoolUtility.DestroyAllChildrens(m_whereToCreate);

        string s= m_lineToWrite;
        if(s.Length > m_maxLineLength)
        {
            s = s.Substring(0, m_maxLineLength);
        }
        if (m_whereToCreate != null)
        {
            if (m_charPool != null)
            {
                Vector3 position = new Vector3(m_offset.x , m_offset.y, 0);
                for(int i = 0; i < s.Length; i++)
                {
                    GameObject g = m_charPool.CreateGameObject(s[i], m_whereToCreate);
                    if (g != null) { 
                        g.transform.localPosition = position + new Vector3(i * m_distanceBetween, 0, 0);
                        g.transform.localScale = new Vector3(m_width, m_height, m_depth);
                    }
                }
            }
        }
    }

    public void SetTitle(string text)
    {
        m_lineToWrite = text;
        CreateElements();
    }
}
