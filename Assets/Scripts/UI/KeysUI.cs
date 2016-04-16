using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class KeysUI : MonoBehaviour
{
    private Text m_Text;

    private void Awake()
    {
        m_Text = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ShipControl shipControl = GameObject.FindWithTag("Ship").GetComponent<ShipControl>();
        m_Text.text = "";
        if(shipControl.Controls != null)
        {
            for(int i = 0; i < shipControl.Controls.Count; ++i)
            {
                //if(shipControl.Controls[i].Unlocked)
                //{
                char letter = 'A';
                letter += (char) (shipControl.Controls[i].Keycode - KeyCode.A);
                m_Text.text += letter + " ";
                //}
            }
        }
    }
}
