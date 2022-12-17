using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.UI;

public class PrologueController : MonoBehaviour
{
    [SerializeField] private GameManager gameManagerRef;
    [SerializeField] private GameObject gameplayScene;

    [SerializeField] private TextAsset compiledInkStory;
    private Story _inkStoryWrapped;

    [SerializeField] private Text prologueText;

        // Start is called before the first frame update
    void Start()
    {
        
        
        _inkStoryWrapped = new Story(compiledInkStory.text);
        _inkStoryWrapped.ChoosePathString("Prologue_1");

        while (_inkStoryWrapped.canContinue)
        {
            prologueText.text += "\n";
            prologueText.text += _inkStoryWrapped.Continue();
        }

        StartCoroutine(AdvanceToGameplay(10));
    }

    private IEnumerator AdvanceToGameplay(int timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        //call the move to gameplay scene function
        gameManagerRef.TransitionScenes(
            gameObject, 
            gameplayScene,
            GameManager.GameStates.DayStart);
    }
}
