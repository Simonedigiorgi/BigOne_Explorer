using System.Collections;
using UnityEngine;

public class ProvaFiglio : ProvaDotween
{
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {

            StartCoroutine(Prova());
        }


    }

    protected override IEnumerator Prova()
    {
        

        yield return StartCoroutine(base.Prova());

        Debug.Log("Olè");

        yield return null;

    }
}