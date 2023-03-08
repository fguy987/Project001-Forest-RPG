using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    
    public static PlayerInputManager s_Instance { get; private set; }
    private static GameControls gameControls;
    public GameControls GameControls => gameControls;

    private void Awake()
    {
        if(s_Instance == null)
        {
            s_Instance = this;
            gameControls = new GameControls();
        }
        else
        {
            Debug.Log("Trying to create another manager!");
            Destroy(gameObject);
        }
    }

    public static void SwitchActiveActionMap(InputActionMap reqMap)
    {
        if (reqMap.enabled) { return; } //if its alrealy enabled there is no need

        gameControls.Disable();//disable asset=disable all action Maps

        reqMap.Enable();
    }
}
