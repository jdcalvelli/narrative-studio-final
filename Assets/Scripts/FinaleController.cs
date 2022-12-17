using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class FinaleController : MonoBehaviour
{
    
    [SerializeField] private GameManager gameManagerRef;

    [SerializeField] private TextAsset compiledInkStory;
    private Story _inkStoryWrapped;

    [SerializeField] private Text prologueText;
    
    // Start is called before the first frame update
    void Start()
    {
        _inkStoryWrapped = new Story(compiledInkStory.text);
        _inkStoryWrapped.ChoosePathString("Finale_1");

        while (_inkStoryWrapped.canContinue)
        {
            prologueText.text += "\n";
            prologueText.text += _inkStoryWrapped.Continue();
        }

        StartCoroutine(FadeToEnd(10));
    }
    
    private IEnumerator FadeToEnd(int timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        //call the move to gameplay scene function
        gameManagerRef.FadeToBlack(gameObject);
    }
}
