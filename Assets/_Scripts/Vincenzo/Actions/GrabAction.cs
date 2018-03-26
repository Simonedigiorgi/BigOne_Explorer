using UnityEngine;

public class GrabAction : vTriggerGenericAction
{
    [HideInInspector] public bool isGrabbed;

    protected override void Start()
    {
        base.Start();
        OnDoAction.AddListener(() => Grab());
    }

    public void Grab()
    {
        isGrabbed = true;
    }
}
