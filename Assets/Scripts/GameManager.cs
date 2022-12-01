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
    public Dictionary<string, string> PatchResult = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        //creating patch result dictionary
        PatchResult.Add("personPatched", null);
        PatchResult.Add("locationPatched", null);
        
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
                
                Debug.Log(PatchResult["personPatched"]);
                Debug.Log(PatchResult["locationPatched"]);
                if (PatchResult["personPatched"] != null && PatchResult["locationPatched"] != null)
                {
                    if (PatchResult["personPatched"] == "jv" && PatchResult["locationPatched"] == "bridge")
                    {
                        narrativeDirectorReference.JumpTo("Day1_Baha_JV");
                        currentState = GameStates.ListenIn;
                    }
                    else if (PatchResult["personPatched"] == "ducksly" && PatchResult["locationPatched"] == "bridge")
                    {
                        narrativeDirectorReference.JumpTo("Day1_Baha_Ducksly");
                        currentState = GameStates.ListenIn;
                    }
                }
                break;
        }
    }
}
