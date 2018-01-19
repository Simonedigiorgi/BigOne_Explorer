using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTravel : Task 
{

    public override void EnableTask()
    {
        base.EnableTask();
        Database.DataScene dataScene = Database.scenes.Find(x => x.sceneName == taskScene);
        if(!dataScene.isUnlocked)
        {
            dataScene.isUnlocked = true;
        }
    }

    public override void ReadyTask()
    {
        base.ReadyTask();
        this.CompleteTask();
    }

}
