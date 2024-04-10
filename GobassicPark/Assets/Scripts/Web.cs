using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour
{

    public string externalDomain = "https://mysim421web.000webhostapp.com/";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}
