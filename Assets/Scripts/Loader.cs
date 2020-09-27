using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    public GameObject loadingBar;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = GameObject.Find("loading");
        slider = GameObject.Find("loading").GetComponent<Slider>();

        loadingBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
