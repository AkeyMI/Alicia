using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AzufreItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;
    //[SerializeField] Slider azufreSlider = default;

    private int currentUsos = 0;

    public void Apply()
    {
        InventoryManager.Instance.TakeAzufre();

        Destroy(this.gameObject);
    }

    public void OneUse()
    {
        currentUsos++;
        //azufreSlider.value = currentUsos;
        //Debug.Log(currentUsos);

        if (currentUsos >= usos)
        {
            Apply();
        }
    }
}
