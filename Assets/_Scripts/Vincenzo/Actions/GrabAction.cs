using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GrabAction : vTriggerGenericAction
{

    protected override void Start()
    {
        base.Start();
        OnDoAction.AddListener(() => Grab());
        OnPlayerEnter.AddListener(() => RotateEquip());
    }

    public void Grab()
    {
        StartCoroutine(GrabCoroutine());
    }

    void RotateEquip()
    {
        Sequence sequenceGrab = DOTween.Sequence();
        transform.parent.Rotate(Vector3.up * 20 * Time.deltaTime);
        
    }

    IEnumerator GrabCoroutine()
    {
        Sequence sequenceGrab = DOTween.Sequence();

        sequenceGrab.Append(transform.parent.DORotate(Vector3.up * 200, 2f));
        sequenceGrab.Join(transform.parent.DOScale(0, 2f));

        yield return sequenceGrab.WaitForCompletion();
        
        Destroy(transform.parent.gameObject);
    }

}
