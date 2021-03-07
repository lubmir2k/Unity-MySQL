using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DBConnect : MonoBehaviour
{
    public Text email, username, score, password;

    public void AddDetails()
    {
        StartCoroutine(AddPlayerDetails());
    }

    public void GetDetails()
    {
        StartCoroutine(RetrievePlayerDetails());
    }

    public void UpdateDetails()
    {
        StartCoroutine(UpdatePlayerDetails());
    }

    // Create
    IEnumerator AddPlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("name", username.text);
        form.AddField("score", score.text);
        form.AddField("password", password.text);
        UnityWebRequest www = UnityWebRequest.Post("http://lubmir2k.mygamesonline.org/saveplayer.php", form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.responseCode);
        }
    }

    IEnumerator RetrievePlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("password", password.text);
        WWW www = new WWW("http://lubmir2k.mygamesonline.org/retrieveplayer.php", form);

        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
            string[] details = www.text.Split('|');
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
        UnityWebRequest www = UnityWebRequest.Post("http://lubmir2k.mygamesonline.org/updateplayer.php", form);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.responseCode);
        }
    }
}
