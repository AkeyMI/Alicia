using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InOutShipManager : MonoBehaviour
{
    [SerializeField] float shipMinimumClose = 1f;
    [SerializeField] Button goOutShipButton = default;
    [SerializeField] Button goInShipButton = default;

    public bool IsAliceOut => isAliceOut;

    private bool isAliceOut = false;

    private SpaceShipController spaceShip;

    private Button btnGoOut;
    private Button btnGoIn;


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
        btnGoIn = goInShipButton.GetComponent<Button>();
        btnGoIn.onClick.AddListener(GoIn);
        btnGoIn.gameObject.SetActive(false);

        spaceShip = FindObjectOfType<SpaceShipController>();
    }

    private void Update()
    {
        if(spaceShip.ShipOnGround && !isAliceOut)
        {
            btnGoOut.gameObject.SetActive(true);
        }
        else
        {
            btnGoOut.gameObject.SetActive(false);
        }

        if(ShipIsClose() && spaceShip.ShipOnGround)
        {
            btnGoIn.gameObject.SetActive(true);
        }
        else
        {
            btnGoIn.gameObject.SetActive(false);
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
        isAliceOut = false;

        FindObjectOfType<CharacterControler>().GoIn();

        spaceShip.ResetConstraints();

        btnGoIn.gameObject.SetActive(false);
    }

    private bool ShipIsClose()
    {
        CharacterControler alice = FindObjectOfType<CharacterControler>();

        if (alice == null) return false;

        float distance = Vector3.Distance(spaceShip.transform.position, FindObjectOfType<CharacterControler>().transform.position);

        if (distance <= shipMinimumClose)
        {
            return true;
        }

        return false;
    }
}
