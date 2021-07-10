using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InOutShipManager : MonoBehaviour
{
    [SerializeField] Button goOutShipButton = default;

    public bool IsAliceOut => isAliceOut;

    private bool isAliceOut = false;

    private SpaceShipController spaceShip;

    private Button btnGoOut;


    public static InOutShipManager Instance;

    private void Awake()
    {
        // I will check if I am the first singletong
        if (Instance == null)
        {
            // ... since i am the one, I declare myself as the one
            Instance = this;

            // ... and I will live forever
            DontDestroyOnLoad(this);

        }
        else
        {
            // I am not the one... I will walk to the eternal darkness
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        btnGoOut = goOutShipButton.GetComponent<Button>();
        btnGoOut.onClick.AddListener(GoOut);
        btnGoOut.gameObject.SetActive(false);

        spaceShip = FindObjectOfType<SpaceShipController>();
    }

    private void Update()
    {
        if(spaceShip.ShipOnGround && !isAliceOut)
        {
            btnGoOut.gameObject.SetActive(true);
        }
    }

    public void GoOut()
    {
        isAliceOut = true;

        spaceShip.GoOut();

        btnGoOut.gameObject.SetActive(false);
    }

    public void GoIn()
    {

    }
}
