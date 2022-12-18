using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitSectionView : MonoBehaviour
{

    [SerializeField] private GameManager gameManagerRef;
    
    [SerializeField] private SpriteRenderer portrait1;
    [SerializeField] private SpriteRenderer portrait2;


    [SerializeField] private List<Sprite> portraitSprites;
    private Dictionary<string, Sprite> _portraits = new Dictionary<string, Sprite>();

    // Update is called once per frame
    private void Start()
    {
        _portraits.Add("Dover", portraitSprites[0]);
        _portraits.Add("Baha", portraitSprites[1]);
        _portraits.Add("JV", portraitSprites[2]);
        _portraits.Add("Ducksly", portraitSprites[3]);
        
        Debug.Log(portraitSprites);
    }

    void Update()
    {
        if (gameManagerRef.currentState == GameManager.GameStates.DayStart 
            || gameManagerRef.currentState == GameManager.GameStates.PreDeterminePostConvoPatching
            || gameManagerRef.currentState == GameManager.GameStates.DayEnd)
        {
            portrait1.sprite = null;
            portrait2.sprite = null;
        }
        else
        {
            if (gameManagerRef.PatchResult["locationPatched"] == null)
            {
                portrait1.sprite = null;
            }
            else
            {
                portrait1.sprite = _portraits[gameManagerRef.PatchResult["locationPatched"]];
            }

            if (gameManagerRef.PatchResult["personPatched"] == null)
            {
                portrait2.sprite = null;
            }
            else
            {
                portrait2.sprite = _portraits[gameManagerRef.PatchResult["personPatched"]];
            }
        }
    }
}
