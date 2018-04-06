using UnityEngine;
using DG.Tweening;
using System.Collections;

public class GrabAction : vTriggerGenericAction
{

    protected override void Start()
    {
        base.Start();
        OnDoAction.AddListener(() => Grab());
        if(this.transform.parent.CompareTag("Equipment"))
        {
            OnPlayerEnter.AddListener(() => RotateEquip());
            OnPlayerExit.AddListener(() => transform.parent.DOMoveY(0.5f, 0.3f));
        }
    }

    public void Grab()
    {
        StartCoroutine(GrabCoroutine());
    }

    void RotateEquip()
    {
        transform.parent.DOMoveY(1f, 0.3f);
        transform.parent.Rotate(Vector3.up * 20 * Time.deltaTime);
    }

    IEnumerator GrabCoroutine()
    {
        if (this.transform.parent.CompareTag("Equipment"))
        {
            Sequence sequenceGrab = DOTween.Sequence();

            sequenceGrab.Append(transform.parent.DORotate(Vector3.up * 200, 2f));
            sequenceGrab.Join(transform.parent.DOScale(0, 2f));

            yield return sequenceGrab.WaitForCompletion();

            Destroy(transform.parent.gameObject);
        }
        else
            Destroy(transform.parent.gameObject);
    }

}
