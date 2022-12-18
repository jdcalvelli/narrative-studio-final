using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RecorderView : MonoBehaviour
{
    [SerializeField] private GameObject orangeGear;
    [SerializeField] private GameObject greyGear;

        // Start is called before the first frame update
    void Start()
    {
        orangeGear.transform.DOLocalRotate(
            new Vector3(0, 0, 360),
            5f, RotateMode.FastBeyond360)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
        
        greyGear.transform.DOLocalRotate(
                new Vector3(0, 0, 360),
                5f, RotateMode.FastBeyond360)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart);
    }
    
}
