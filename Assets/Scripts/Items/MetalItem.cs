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

        Destroy(this.gameObject);
    }

    public void OneUse()
    {
        currentUsos++;

        if(currentUsos >= usos)
        {
            Apply();
        }
    }
}
