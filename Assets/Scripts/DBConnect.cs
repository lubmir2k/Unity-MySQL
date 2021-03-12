using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBConnect : MonoBehaviour
{
    public Text email, username, score, password;
    public string URL = "http://lubmir2k.mygamesonline.org/";

    // Create
    public void AddDetails()
    {
        StartCoroutine(AddPlayerDetails());
    }

    // Read
    public void GetDetails()
    {
        StartCoroutine(RetrievePlayerDetails());
    }

    // Update
    public void UpdateDetails()
    {
        StartCoroutine(UpdatePlayerDetails());
    }
    
    IEnumerator AddPlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("name", username.text);
        form.AddField("score", score.text);
        form.AddField("password", password.text);
        UnityWebRequest www = UnityWebRequest.Post(URL + "saveplayer.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Success: " + www.responseCode);
        }
    }

    IEnumerator RetrievePlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("password", password.text);
        UnityWebRequest www = UnityWebRequest.Post(URL + "retrieveplayer.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Success: " + www.responseCode);

            string[] details = www.downloadHandler.text.Split('|');
            username.transform.parent.GetComponent<InputField>().text = details[0];
            if(details.Length > 1)
            {
                score.transform.parent.GetComponent<InputField>().text = details[1];
            }
        }
    }

    IEnumerator UpdatePlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("name", username.text);
        form.AddField("score", score.text);
        UnityWebRequest www = UnityWebRequest.Post(URL + "updateplayer.php", form);

        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log("Error: " + www.error);
        }
        else
        {
            Debug.Log("Success: " + www.responseCode);
        }
    }
}
