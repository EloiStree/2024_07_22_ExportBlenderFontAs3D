using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjCharPoolMono : MonoBehaviour
{

    public List<CharToPrefab> m_charToPrefab = new List<CharToPrefab>();

    [System.Serializable]
    public class CharToPrefab
    {
        public string m_chatAsString;
        public char m_char;
        public GameObject m_prefab;
    }


    [ContextMenu("Add convex")]
    public void AddConvex() {
        
        
        foreach (var item in m_charToPrefab)
        {
            if (item.m_prefab != null)
            {
                MeshRenderer mf = item.m_prefab.GetComponentInChildren<MeshRenderer>();
                if (mf != null)
                {
                   
                    MeshCollider mc = mf.GetComponent<MeshCollider>();
                    if (mc == null)
                        mc = mf.gameObject.AddComponent<MeshCollider>();
                    if (mc != null) { 
                        mc.convex = true;
                        mc.isTrigger = true;
                    }
                }
            }
        }
    }


    [ContextMenu("Refresh")]
    public void Refresh() {

        GameObject[] objs =FetchInChildren();
        m_charToPrefab.Clear();
        for (int i = 0; i < objs.Length; i++)
        {
            string s = objs[i].name.Replace("C_","");
            if (int.TryParse(s, out int n)) {
                char c = (char) n;
                m_charToPrefab.Add(new CharToPrefab() { 
                    m_char = c,
                    m_chatAsString = c.ToString(),
                    m_prefab = objs[i]
                });
            }
        }
    }

    private GameObject[] FetchInChildren()
    {
        Transform[] o = GetComponentsInChildren<Transform>();
        List<GameObject> g = new List<GameObject>();
        for (int i = 0; i < o.Length; i++)
        {
           
                if(o[i].name.StartsWith("C_"))
                g.Add(o[i].gameObject);
            
        }
        return g.ToArray();
    }

    internal GameObject CreateGameObject(char c, Transform parent)
    {
        for (int i = 0; i < m_charToPrefab.Count; i++)
        {
            if (m_charToPrefab[i].m_char == c)
            {
                GameObject g = Instantiate(m_charToPrefab[i].m_prefab);
                g.transform.SetParent(parent);
                g.name = m_charToPrefab[i].m_chatAsString;
                return g;
            }
        }
        return null;
    }
}
