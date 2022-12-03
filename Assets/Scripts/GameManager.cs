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

    private int _dayCounter = 1;
    private int _lastDay = 3;

    [SerializeField] private List<PatchCordController> patchCordList;

    // enum for state management
    public enum GameStates
    {
        GameStart,
        DayStart,
        InitialCalls,
        DeterminePatching,
        ListenIn,
        PreDeterminePostConvoPatching,
        DeterminePostConvoPatching,
        ListenPostConvo,
        DayEnd,
        GameEnd,
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
                //if we want to do things in the game beginning
                currentState = GameStates.DayStart;
                break;
            
            case GameStates.DayStart:
                narrativeDirectorReference.JumpTo($"Day{_dayCounter}_Start");
                currentState = GameStates.InitialCalls;
                break;
            
            case GameStates.InitialCalls:
                PatchResult["personPatched"] = null;
                PatchResult["locationPatched"] = null;
                // check when the initial calls are done somehow, then switch to determine patching
                // hacky check to see if text is over based on if say dialog is around
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    currentState = GameStates.DeterminePatching;
                }
                break;
            
            case GameStates.DeterminePatching:
                InitialConversations(_dayCounter,
                    PatchResult["locationPatched"],
                    PatchResult["personPatched"]);
                break;
            
            case GameStates.ListenIn:
                PatchResult["personPatched"] = null;
                PatchResult["locationPatched"] = null;
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    narrativeDirectorReference.JumpTo($"Day{_dayCounter}_PrivateConvoChoice");
                    currentState = GameStates.PreDeterminePostConvoPatching;
                }
                break;
            
            case GameStates.PreDeterminePostConvoPatching:
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    
                    // reset positions of cords
                    foreach (var patchCord in patchCordList)
                    {
                        patchCord.gameObject.transform.position = patchCord._initialPosition;
                    }
                    
                    currentState = GameStates.DeterminePostConvoPatching;
                }
                break;
            
            case GameStates.DeterminePostConvoPatching:

                if (PatchResult["personPatched"] != null && PatchResult["locationPatched"] == "Dover")
                {
                    narrativeDirectorReference.JumpTo(
                            $"Day{_dayCounter}_{PatchResult["locationPatched"]}_{PatchResult["personPatched"]}");
                    currentState = GameStates.ListenPostConvo;
                }
                break;
            
            case GameStates.ListenPostConvo:
                PatchResult["personPatched"] = null;
                PatchResult["locationPatched"] = null;
                
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    currentState = GameStates.DayEnd;
                }
                break;
            
            case GameStates.DayEnd:
                if (_dayCounter >= _lastDay)
                {
                    //stop the game
                    currentState = GameStates.GameEnd;
                    Debug.Log("game stopped " + _dayCounter);
                }
                else
                {
                    _dayCounter++;
                    Debug.Log("next day " + _dayCounter);
                    
                    // reset positions of cords
                    foreach (var patchCord in patchCordList)
                    {
                        patchCord.gameObject.transform.position = patchCord._initialPosition;
                    }

                    PatchResult["personPatched"] = null;
                    PatchResult["locationPatched"] = null;

                    currentState = GameStates.InitialCalls;
                }

                break;
        }
    }

    private void InitialConversations(int dayCount, string firstPerson, string secondPerson)
    {
        if (firstPerson != null && secondPerson != null)
        {
            narrativeDirectorReference.JumpTo($"Day{dayCount}_{firstPerson}_{secondPerson}");
            currentState = GameStates.ListenIn;
        }
    }


}
