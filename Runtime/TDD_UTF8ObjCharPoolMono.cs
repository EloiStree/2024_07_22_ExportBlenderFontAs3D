using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TDD_UTF8ObjCharPoolMono : MonoBehaviour
{
    public ObjCharPoolMono m_charPool;
    public Transform m_whereToCreate;

    public float m_spaceBetween = 1;

    private void Reset()
    {
        m_charPool = GetComponent<ObjCharPoolMono>();
        if(m_charPool == null)
            m_charPool = gameObject.GetComponentInParent<ObjCharPoolMono>();
        m_whereToCreate = transform;
    }

    [ContextMenu("Create Elements")]
    public void CreateElements()
    {
        DestroyCreatedElements();

        if (m_whereToCreate != null) { 
            if (m_charPool != null)
            {
                for (int i = 0; i < m_charPool.m_charToPrefab.Count; i++)
                {
                    GameObject g = Instantiate(m_charPool.m_charToPrefab[i].m_prefab, m_whereToCreate);
                    g.name = m_charPool.m_charToPrefab[i].m_chatAsString;
                    g.transform.localPosition = new Vector3(m_spaceBetween+i* m_spaceBetween, 0,0);
                }
            }
        }
    }

    [ContextMenu("Destroy Elements")]
    public void DestroyCreatedElements()
    {
        CharPoolUtility.DestroyAllChildrens(m_whereToCreate);
    }
   
}



public class CharPoolUtility {

    public static void DestroyAllChildrens(Transform whereToCreate) {

        if (whereToCreate != null)
        {
           
                Transform[] t = whereToCreate.GetComponentsInChildren<Transform>();
                t = t.Where(k => k != whereToCreate).ToArray();
                for (int i = 0; i < t.Length; i++)
                {
                    if (t[i] != whereToCreate)
                    {
                        if (t[i] != null)
                        {
                            if (Application.isPlaying)
                                GameObject. Destroy(t[i].gameObject);
                            else
                               GameObject. DestroyImmediate(t[i].gameObject);
                        }
                    }
                }

            
        }
    }
}
