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
        GameObject echo = GameObject.Find("echoAR");
        if (echo)
        {
            Vector3 pos = echo.transform.position;
            Destroy(echo);
            echo = Instantiate(echoPreFab, pos, Quaternion.identity);
        }
        else
        {
            echo = Instantiate(echoPreFab, Vector3.zero, Quaternion.identity);
        }

        echo.GetComponent<echoAR>().company = company;
        echo.GetComponent<echoAR>().Init();
    }

}
