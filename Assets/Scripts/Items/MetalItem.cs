using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;
    //[SerializeField] Slider metalSlider = default;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        InventoryManager.Instance.TakeMetal();

        //Destroy(this.gameObject);
    }

    public int CurrentUsos()
    {
        return currentUsos;
    }

    public void OneUse()
    {
        currentUsos++;
        FindObjectOfType<SliderManager>().AddSliderValue(currentUsos);

        if(currentUsos >= usos)
        {
            Apply();
            currentUsos = 0;
            //FindObjectOfType<SliderManager>().AddSliderValue(currentUsos);
        }
    }
}
