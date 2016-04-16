using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(ShipPhysics))]
public class ShipControl : MonoBehaviour
{
    private enum Actions : uint
    {
        INTERACT,
        THRUST,
        ROTATE,
        ACTION_NUM
    }

    public struct ActionState
    {
        public KeyCode Keycode;
        public bool Unlocked;
        public bool Pressed;
    }

    private List<ActionState> m_Controls;
    public List<ActionState> Controls
    {
        get { return m_Controls; }
    }

    private ShipPhysics m_ShipPhysics;

    public void InitControls()
    {
        ActionState state = Controls[(int) Actions.THRUST];
        state.Unlocked = true;
        Controls[(int) Actions.THRUST] = state;
    }

    private void Awake()
    {
        m_ShipPhysics = GetComponent<ShipPhysics>();

        RandomizeControl();
        InitControls();
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
                ActionState state = Controls[i];
                state.Pressed = true;
                Controls[i] = state;
            }

            if(Input.GetKeyUp(m_Controls[i].Keycode))
            {
                ActionRelease((Actions) i);
                ActionState state = Controls[i];
                state.Pressed = true;
                Controls[i] = state;
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
                    keyFound = true;
                }
            }
            m_Controls.Add(state);
        }
    }

    private void ActionPress(Actions action)
    {
        switch(action)
        {
            case Actions.INTERACT:
                break;

            case Actions.THRUST:
                m_ShipPhysics.SetThrust(true);
                break;

            case Actions.ROTATE:
                break;

            default :
                Debug.LogError("Unsupported action");
                break;
        }
    }

    private void ActionRelease(Actions action)
    {
        switch(action)
        {
            case Actions.INTERACT:
                break;

            case Actions.THRUST:
                m_ShipPhysics.SetThrust(false);
                break;

            case Actions.ROTATE:
                break;

            default :
                Debug.LogError("Unsupported action");
                break;
        }
    }
}
