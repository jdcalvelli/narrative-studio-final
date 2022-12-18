using System;
using System.Collections;
using System.Collections.Generic;
using Fungus;
using InkFungus;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //reference to fader
    [SerializeField] private SpriteRenderer fader;
    //reference to start screen
    [SerializeField] private GameObject startScreen;
    //reference to start button
    [SerializeField] private Button startButton;
    
    //reference to prologue screen
    [SerializeField] private GameObject prologueScreen;
    //reference to main screen
    [SerializeField] private GameObject gameplayScreen;
    //reference to finale screen
    [SerializeField] private GameObject finaleScreen;
    
    
    //reference to narrative director
    [SerializeField] private NarrativeDirector narrativeDirectorReference;
    
    //reference to say dialog for hacky check for end convo;
    [SerializeField] private SayDialog sayDialogReference;

    private int _dayCounter = 1;
    private int _lastDay = 3;

    [SerializeField] private List<PatchCordController> patchCordList;

    //very bad for further sub control
    private bool _fadeController = false;
    private bool _secondConvoController = false;
    private bool _endFadeController = false;
    
    // enum for state management
    public enum GameStates
    {
        GameStart,
        PrologueStart,
        FadeDayStart,
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
        
        startButton.onClick.AddListener(() => TransitionScenes(
            startScreen, 
            prologueScreen, 
            GameStates.PrologueStart));
    }

    private void Update()
    {
        switch (currentState)
        {
            case GameStates.GameStart:
                //if we want to do things in the game beginning
                //waiting on button press on start screen
                break;
            
            case GameStates.PrologueStart:
                //Debug.Log("were in the prologue state");
                break;
            
            case GameStates.FadeDayStart:
                if (_fadeController == false)
                {
                    Sequence fadeDayStart = DOTween.Sequence();
                    fadeDayStart.Append(fader.DOFade(1f, 2f));
                    fadeDayStart.AppendInterval(3f);
                    fadeDayStart.Append(fader.DOFade(0f, 2f));
                    fadeDayStart.AppendCallback(() => currentState = GameStates.DayStart);
                    _fadeController = true;
                }
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
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    if (_secondConvoController == false)
                    {
                        StartCoroutine(WaitBeforeSecondConvo(4));
                        _secondConvoController = true;
                    }
                }
                break;
            
            case GameStates.PreDeterminePostConvoPatching:
                PatchResult["personPatched"] = null;
                PatchResult["locationPatched"] = null;
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
                if (!sayDialogReference.isActiveAndEnabled)
                {
                    currentState = GameStates.DayEnd;
                }
                break;
            
            case GameStates.DayEnd:
                PatchResult["personPatched"] = null;
                PatchResult["locationPatched"] = null;
                if (_dayCounter >= _lastDay)
                {
                    if (_endFadeController == false)
                    {
                        TransitionScenes(gameplayScreen, finaleScreen, GameStates.GameEnd);
                        _endFadeController = true;
                    }
                    //stop the game
                    //currentState = GameStates.GameEnd;
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

                    _fadeController = false;
                    _secondConvoController = false;
                    currentState = GameStates.FadeDayStart;
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

    public void TransitionScenes(GameObject transitionFrom, GameObject transitionTo, GameStates newState)
    {
        Sequence fadeStart = DOTween.Sequence();

        //fade down start screen
        //bring fader box up to full color
        fadeStart.Append(fader.DOFade(1f, 2f).SetEase(Ease.InCubic));

        //turn off the start screen
        fadeStart.AppendCallback(() => transitionFrom.SetActive(false));

        //then turn on the main screen
        fadeStart.AppendCallback(() => transitionTo.SetActive(true));

        //then fade up main screen
        //bringing fader box down to no alpha
        fadeStart.Append(fader.DOFade(0f, 2f));

        //then switch state to day start
        fadeStart.AppendCallback(() => currentState = newState);
        Debug.Log(currentState);
    }

    public void FadeToBlack(GameObject transitionFrom)
    {
        Sequence endingFade = DOTween.Sequence();
    
        endingFade.Append(fader.DOFade(1f, 2f).SetEase(Ease.InCubic));
        endingFade.AppendCallback(() => transitionFrom.SetActive(false));

    }


    private IEnumerator WaitBeforeSecondConvo(int timeToWait)
    {
        PatchResult["personPatched"] = null;
        PatchResult["locationPatched"] = null;
        yield return new WaitForSeconds(timeToWait);
        narrativeDirectorReference.JumpTo($"Day{_dayCounter}_PrivateConvoChoice");
        currentState = GameStates.PreDeterminePostConvoPatching;
    }
}
