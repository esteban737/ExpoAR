using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Services services = new Services();
        services.setCompany("GOOGLE");
    }
}
