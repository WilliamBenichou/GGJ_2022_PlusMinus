using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObj : MonoBehaviour
{
    [SerializeField] private Color[] hl_c = new Color[]{};
    [SerializeField] private SpriteRenderer[] hl_renderers;

    private bool[] m_playerInSight = new bool[2];
    

    public void Reached(int player)
    {
        m_playerInSight[player] = true;
        SetColor();
    }

    private void SetColor()
    {
        int nbInside = 0;
        Color c = default;
        for (int i = 0; i < 2; i++)
        {
            if (m_playerInSight[i])
            {
                c = hl_c[i];
                nbInside++;
            }
        }

        if (nbInside == 0)
        {
            foreach (var spriteRenderer in hl_renderers)
            {
                spriteRenderer.enabled = false;
            }
            return;
        }
        if (nbInside == 2) c = hl_c[2]; 

        
        foreach (var spriteRenderer in hl_renderers)
        {
            spriteRenderer.enabled = true;
            spriteRenderer.color = c;
        }
    }

    public void PlayerOOS(int player)
    {
        m_playerInSight[player] = false;
        SetColor();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            m_playerInSight[i] = false;
        }
        SetColor();
    }
}
