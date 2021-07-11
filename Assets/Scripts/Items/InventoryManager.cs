using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private int hidrogeno = 0;
    private int metal = 0;
    private int azufre = 0;
    private int bayas = 6;
    private int semillas = 50;

    private int maxItems = 5;

    public static InventoryManager Instance;

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

    public void TakeMetal()
    {
        if(metal < maxItems)
        {
            metal++;
        }
    }

    public void UseMetal()
    {
        if(metal > 0)
        {
            metal--;
        }
    }

    public void TakeHidrogeno()
    {
        if(hidrogeno < maxItems)
        {
            hidrogeno++;
        }
    }

    public void UseHidrogeno()
    {
        if (hidrogeno > 0)
        {
            hidrogeno--;
        }
    }

    public void TakeAzufre()
    {
        if(azufre < maxItems)
        {
            azufre++;
        }
    }

    public void UseAzufre()
    {
        if (azufre > 0)
        {
            azufre--;
        }
    }

    public void EatBaya()
    {
        if(bayas < maxItems)
        {
            bayas++;
        }
    }

    public void MinusBaya()
    {
        if(bayas > 0)
        {
            bayas--;
        }
    }

    public void UseSemilla()
    {
        if(semillas > 0)
        {
            semillas--;
        }
    }
}
