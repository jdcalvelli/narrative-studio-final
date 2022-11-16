using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // enum for state management
    public enum GameStates
    {
        InitialCalls,
        DeterminePatching,
        ListenIn,
        DeterminePostConvo,
        PostConvo,
    }

    // tracking current state
    public GameStates currentState;
    
    // to hold result of patch
    public Tuple<string, string> patchResult = new Tuple<string, string>(null, null);
    
    // Start is called before the first frame update
    void Start()
    {
        currentState = GameStates.InitialCalls;
    }

    private void Update()
    {
        if (patchResult.Item1 != null && patchResult.Item2 != null)
        {
            Debug.Log(patchResult);
        }
    }
}
