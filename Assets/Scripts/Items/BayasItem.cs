using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BayasItem : MonoBehaviour, IInteractable
{
    [SerializeField] int usos = 1;
    [SerializeField] TierraItem tierraItem = default;

    private int currentUsos = 0;

    public void Apply()
    {
        //Debug.Log("Se uso item");
        InventoryManager.Instance.EatBaya();

        tierraItem.RespwanBaya();
        this.gameObject.SetActive(false);
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