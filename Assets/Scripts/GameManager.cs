using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using InkFungus;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //reference to narrative director
    [SerializeField] private NarrativeDirector narrativeDirectorReference;
    
    //reference to say dialog for hacky check for end convo;
    [SerializeField] private SayDialog sayDialogReference;
    
    // enum for state management
    public enum GameStates
    {
        GameStart,
        InitialCalls,
        DeterminePatching,
        ListenIn,
        DeterminePostConvo,
        PostConvo,
    }

    // tracking current state
    public GameStates currentState;
    
    // to hold result of patch
    public Tuple<string, string> PatchResult = new Tuple<string, string>(null, null);

    // Start is called before the first frame update
    void Start()
    {
        currentState = GameStates.GameStart;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameStates.GameStart:
                narrativeDirectorReference.Resume();
                currentState = GameStates.InitialCalls;
                break;
            
            case GameStates.InitialCalls:
                // check when the initial calls are done somehow, then switch to determine patching
                // hacky check to see if text is over based on if say dialog is around
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    currentState = GameStates.DeterminePatching;
                }
                break;
            
            case GameStates.DeterminePatching:
                if (PatchResult.Item1 != null && PatchResult.Item2 != null)
                {
                    Debug.Log(PatchResult);
                    if (PatchResult.Item1 == "bridge" && PatchResult.Item2 == "jv")
                    {
                        narrativeDirectorReference.JumpTo("Day1_Baha_JV");
                        currentState = GameStates.ListenIn;
                    }
                    else if (PatchResult.Item1 == "bridge" && PatchResult.Item2 == "ducksly")
                    {
                        narrativeDirectorReference.JumpTo("Day1_Baha_Ducksly");
                        currentState = GameStates.ListenIn;
                    }
                }
                break;
        }
    }
}
