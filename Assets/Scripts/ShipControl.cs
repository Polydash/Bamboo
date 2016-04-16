using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipControl : MonoBehaviour
{
    private enum Actions : uint
    {
        INTERACT,
        THRUST,
        ROTATE,
        ACTION_NUM
    }

    private struct ActionState
    {
        public KeyCode Keycode;
        public bool Unlocked;
        public bool Pressed;

        public void SetPressed(bool pressed)
        {
            Pressed = pressed;
        }
    }

    private List<ActionState> m_Controls;

    private void Awake()
    {
        RandomizeControl();
    }

    private void Update()
    {
        for(int i = 0; i < (uint) Actions.ACTION_NUM; ++i)
        {
            if(!m_Controls[i].Unlocked)
            {
                continue;
            }

            if(Input.GetKeyDown(m_Controls[i].Keycode))
            {
                ActionPress((Actions) i);
                m_Controls[i].SetPressed(true);
            }

            if(Input.GetKeyUp(m_Controls[i].Keycode))
            {
                ActionRelease((Actions) i);
                m_Controls[i].SetPressed(false);
            }
        }
    }

    private void RandomizeControl()
    {
        m_Controls = new List<ActionState>();
        for(int i = 0; i < (uint) Actions.ACTION_NUM; ++i)
        {      
            bool keyFound = false;
            ActionState state = new ActionState();
            while(!keyFound)
            {
                int randomKey = Random.Range(0, 25);
                KeyCode randomKeycode = (KeyCode) (randomKey + (int)KeyCode.A);

                bool usedKey = false;
                for(int j = 0; j < (uint) m_Controls.Count; ++j)
                {
                    if(randomKeycode == m_Controls[j].Keycode)
                    {
                        usedKey = true;
                    }
                }

                if(!usedKey)
                {
                    state.Keycode = randomKeycode;
                    state.Unlocked = false;
                }
            }
        }
    }

    private void ActionPress(Actions action)
    {
        switch(action)
        {
            default :
                Debug.LogError("Unsupported action");
                break;
        }
    }

    private void ActionRelease(Actions action)
    {
        switch(action)
        {
            default :
                Debug.LogError("Unsupported action");
                break;
        }
    }
}
