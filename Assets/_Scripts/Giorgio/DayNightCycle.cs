using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public float time;
    public TimeSpan currentTime;
    public Transform SunTransform;
    public Light Sun;
    public Text timeText;
    public int Days;

    public float intensity;
    public Color fogDay = Color.grey;
    public Color fogNight = Color.black;

 

    public int Speed;

	void Update () {
        ChangeTime();
	}

    public void ChangeTime()
    {
        time += Time.deltaTime + Speed;
        if (time > 8)
        {
            Days += 1;
            time = 0;
        }
        currentTime = TimeSpan.FromSeconds(time);

        SunTransform.rotation = Quaternion.Euler(new Vector3((time-2)/8*360,0,0));

        if (time < 432)
            intensity = 1 - (4 - time) / 4;
        else
            intensity = 1 - ((4 - time) / 4 * -1);

        RenderSettings.fogColor = Color.Lerp(fogNight, fogDay, intensity * intensity);

        Sun.intensity = intensity;
    }


}
