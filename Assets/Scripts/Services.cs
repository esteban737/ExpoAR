using UnityEditor;
using UnityEngine;

public class Services : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject setCompany(GameObject echoPreFab, string company)
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

        return echo;
    }

}
