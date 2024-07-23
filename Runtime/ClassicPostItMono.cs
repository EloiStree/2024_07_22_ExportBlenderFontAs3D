using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClassicPostItMono : MonoBehaviour
{
    public WriteLineFromPoolMono m_title;
    public WriteTextPostItFromPoolMono m_text;
    public UnityEvent<Color> m_onColorChanged;


    public bool m_resetAtStart = true;
    private void Start()
    {
        if (m_resetAtStart)
        {
            Refresh();
        }
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        m_title.CreateElements();
        m_text.CreateElements();
        RemoveMeshColliders();
    }

    public void SetTitle(string title)
    {
        if(m_title!=null)
            m_title.SetTitle(title);
    }
    public void SetText(string text) {

        if (m_text != null)
            m_text.SetText(text);
    }
    public void SetColor(Color color)
    {
        m_onColorChanged.Invoke(color);
    }

    [ContextMenu("Set Green ")]
    public void SetColorLightGreen() => SetColor(Color.green*0.1f);
    [ContextMenu("Set Red ")]
    public void SetColorLightRed() => SetColor(Color.red * 0.1f);
    [ContextMenu("Set Blue ")]
    public void SetColorLightBlue() => SetColor(Color.blue * 0.1f);

    [ContextMenu("Set Yellow ")]
    public void SetColorYellow() => SetColor(Color.yellow );


    [ContextMenu("Remove Mesh Colliders")]
    public void RemoveMeshColliders() {

        MeshCollider  [] m = GetComponentsInChildren<MeshCollider>();
        foreach (var item in m)
        {
            if(Application.isPlaying)
                Destroy(item);
            else
                DestroyImmediate(item);
        }
    }

}
