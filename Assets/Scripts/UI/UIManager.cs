using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private bool m_Activated = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            m_Activated = !m_Activated;
            for(int i = 0; i < transform.childCount; ++i)
            {
                transform.GetChild(i).gameObject.SetActive(m_Activated);
            }
        }
    }
}
