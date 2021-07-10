using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractable : MonoBehaviour
{
    [SerializeField] float radius = 2f;

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            CheckInteractablesItems();
        }
    }

    private void CheckInteractablesItems()
    {
        Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Item"))
            {
                hitCollider.GetComponent<IInteractable>().Apply();
            }
        }
    }
}
