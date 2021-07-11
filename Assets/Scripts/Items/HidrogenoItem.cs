using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidrogenoItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;
    //[SerializeField] Slider hidrogenoSlider = default;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        InventoryManager.Instance.TakeHidrogeno();

        Destroy(this.gameObject);
    }

    public void OneUse()
    {
        currentUsos++;
        //hidrogenoSlider.value = currentUsos;
        //Debug.Log(currentUsos);

        if (currentUsos >= usos)
        {
            Apply();
        }
    }
}
