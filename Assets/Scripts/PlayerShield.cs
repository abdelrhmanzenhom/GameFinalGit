using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    // Start is called before the first frame update
    private HealthScript healthscript;

    void Start()
    {
        healthscript = GetComponent<HealthScript>();
    }

    // Update is called once per frame
    public void AcitvateShield(bool sheildacitvate)
    {
        healthscript.shieldActivated = sheildacitvate;
    }
}
