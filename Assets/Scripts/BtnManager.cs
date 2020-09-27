using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManager : MonoBehaviour
{

    private Button btn;
    public GameObject merch;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectCompany);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelectCompany()
    {
        DataHandler.Instance.merch = merch;
    }
}
