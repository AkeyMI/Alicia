using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalancaNave : MonoBehaviour
{
    [SerializeField] Slider slider = default;
    [SerializeField] SpaceShipController spaceShip = default;
    [SerializeField] float thrusterForce = 250f;

    public void OnSliderChanged(float value)
    {
        switch(value)
        {
            case 1:
                //Debug.Log("Velocidad de 1");
                spaceShip.TurnOffContrains();
                spaceShip.ShipForce(thrusterForce / 3);
                break;

            case 2:
                //Debug.Log("Velocidad de 2");
                spaceShip.TurnOffContrains();
                spaceShip.ShipForce(thrusterForce / 2);
                break;

            case 3:
                spaceShip.TurnOffContrains();
                spaceShip.ShipForce(thrusterForce / 1);
                break;

            case 0:
                spaceShip.ShipForce(0);
                spaceShip.ShipForceNegative(0);
                spaceShip.TurnOnContrains();
                break;
        }
    }

    public void ResetPalanca()
    {
        slider.value = 0;
    }
}
