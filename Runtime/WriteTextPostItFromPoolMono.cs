using System;
using UnityEngine;

public class WriteTextPostItFromPoolMono : MonoBehaviour
{
    [TextArea(2,8)]
    public string m_textToWrite = "Noun trademark. 1. a small notepad with an adhesive strip on the back of each sheet that allows it to stick to smooth surfaces and be repositioned with ease.";
    public ObjCharPoolMono m_charPool;
    public Transform m_whereToCreate;
    public float m_distanceBetweenChar = 0.005f;
    public float m_heightDistanceBetweenChar = 0.005f;
    public Vector2 m_offset = new Vector2(0.02f, 0.02f);
    public float m_height = 0.018f;
    public float m_width = 0.012f;
    public float m_depth = 0.001f;

    public int m_maxCharInLine = 80;
    public int m_maxLines = 4;
    


    private void Reset()
    {
        m_whereToCreate = transform;
    }

    [ContextMenu("Create Elements")]
    public void CreateElements()
    {
        CharPoolUtility.DestroyAllChildrens(m_whereToCreate);

        string s = m_textToWrite;
        int maxchar = m_maxCharInLine * m_maxLines;
        if (s.Length > maxchar)
        {
            s = s.Substring(0, maxchar);
        }
        if (m_whereToCreate != null)
        {
            if (m_charPool != null)
            {
                Vector3 positionOffset = new Vector3(m_offset.x, m_offset.y, 0);
               
                for (int i = 0; i < maxchar; i++)
                {
                    int column = i % m_maxCharInLine;
                    int row = i / m_maxCharInLine;



                    if (row < m_maxLines && i<s.Length) { 
                        char c = s[i];
                        if(i> maxchar-4)
                        {
                            c = '.';
                        }
                        GameObject g = m_charPool.CreateGameObject(c, m_whereToCreate);
                        if (g != null)
                        {
                            g.transform.localPosition = positionOffset + 
                                new Vector3(
                                    column * m_distanceBetweenChar, 
                                    -row * (m_height/2f+m_heightDistanceBetweenChar)
                                    , 0);
                            g.transform.localScale = new Vector3(m_width, m_height, m_depth);
                        }
                    }
                }
            }
        }
    }

    public void SetText(string title)
    {
        m_textToWrite = title;
        CreateElements();
    }
}
