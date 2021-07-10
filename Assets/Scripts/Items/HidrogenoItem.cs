using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidrogenoItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 3;

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
        //Debug.Log(currentUsos);

        if (currentUsos >= usos)
        {
            Apply();
        }
    }
}
