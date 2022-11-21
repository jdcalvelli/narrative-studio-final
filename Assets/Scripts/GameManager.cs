using System;
using System.Collections;
using System.Collections.Generic;
using InkFungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference to narrative director
    [SerializeField] private NarrativeDirector narrativeDirector;
    
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
        
        narrativeDirector.Resume();
    }

    private void Update()
    {
        if (currentState == GameStates.InitialCalls)
        {
            if (patchResult.Item1 != null && patchResult.Item2 != null)
            {
                Debug.Log(patchResult);
                if (patchResult.Item1 == "bridge" && patchResult.Item2 == "jv")
                {
                    narrativeDirector.JumpTo("D1_Baha_JV");
                    currentState = GameStates.ListenIn;
                }
                else if (patchResult.Item1 == "bridge" && patchResult.Item2 == "ducksly")
                {
                    narrativeDirector.JumpTo("D1_Baha_Ducksly");
                    currentState = GameStates.ListenIn;
                }
            }
        }
    }
}
