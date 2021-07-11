using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiltroItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 1;
    [SerializeField] float segundosParaRecolectarInformacion = 1f;
    //[SerializeField] Slider filtroSlider = default;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        

        //Destroy(this.gameObject);

        StartCoroutine(CheckAir());
    }

    public void OneUse()
    {
        currentUsos++;
        //Debug.Log(currentUsos);

        if (currentUsos >= usos)
        {
            Apply();
        }
    }

    IEnumerator CheckAir()
    {
        yield return new WaitForSeconds(segundosParaRecolectarInformacion);


    }
}
