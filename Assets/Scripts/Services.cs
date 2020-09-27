using UnityEngine;

public class Services : MonoBehaviour
{
    [SerializeField] GameObject echoPreFab;
    
    // Start is called before the first frame update
     void Start()
    {
        
    }

    public void setCompany(string company)
    {
        GameObject echo = GameObject.Find("echoAR(Clone)");
        GameObject arsession = GameObject.Find("AR Session Origin");
        PlaceOnPlane script = arsession.GetComponent<PlaceOnPlane>();

        if (script.m_Anchors.Count > 0)
        {
            if (echo) Destroy(echo);

            echo = Instantiate(echoPreFab, script.m_Anchors[0].transform.position, Quaternion.identity);

            echo.GetComponent<echoAR>().company = company;
            echo.GetComponent<echoAR>().Init();
        }
    }

}
