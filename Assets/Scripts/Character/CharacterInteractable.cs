using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractable : MonoBehaviour
{
    [SerializeField] float radius = 2f;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            CheckInteractablesItems();
            //Random.Range(0, 1);
        }
    }

    private void CheckInteractablesItems()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Item"))
            {
                Debug.Log("Entro");

                int useOrNot = Random.Range(0, 2);
                if(useOrNot > 0)
                    InventoryManager.Instance.MinusBaya();

                hitCollider.GetComponent<IInteractable>().OneUse();
            }
        }
    }
}
