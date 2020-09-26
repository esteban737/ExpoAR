using UnityEditor;
using UnityEngine;

public class Services : MonoBehaviour
{
    [SerializeField]
    GameObject echoPreFab = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/echoAr/echoAr.prefab", typeof(GameObject));

    // Start is called before the first frame update
    public GameObject setCompany(string company)
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
