using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{

    public string externalDomain = "https://mysim421web.000webhostapp.com/";
    public ScenarioController sC;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public IEnumerator CreateScenario(string name, string predSTC, string preySTC, string fSA, string hR, string fGR, string predType, string preyType)
    {
        WWWForm form = new WWWForm();
        form.AddField("RegName", name);
        form.AddField("RegPredStartCount", predSTC);
        form.AddField("RegPreyStartCount", preySTC);
        form.AddField("RegFoodStartAmount", fSA);
        form.AddField("RegHungerRate", hR);
        form.AddField("RegFoodGenRate", fGR);
        form.AddField("RegPredType", predType);
        form.AddField("RegPreyType", preyType);

        using UnityWebRequest www = UnityWebRequest.Post("https://mysim421web.000webhostapp.com/CreateScenario.php", form);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }

    public IEnumerator GetScenario(string scenarioID, System.Action<string> callback)
    {
        WWWForm form = new WWWForm();
        form.AddField("scenarioID", scenarioID);

        using (UnityWebRequest www = UnityWebRequest.Post("https://mysim421web.000webhostapp.com/GetScenario.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string jsonArray = www.downloadHandler.text;

                callback(jsonArray);
            }
        }
    }

    public IEnumerator GetInfo()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("https://mysim421web.000webhostapp.com/GetInfo.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                sC.thingy = www.downloadHandler.text;
                byte[] results = www.downloadHandler.data;
            }
        }
    }

    public IEnumerator GetScenarioRow(int id)
    {
        WWWForm form = new WWWForm();
        form.AddField("scenarioID", id);
        using (UnityWebRequest www = UnityWebRequest.Get("https://mysim421web.000webhostapp.com/GetScenarioRow.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }
}
