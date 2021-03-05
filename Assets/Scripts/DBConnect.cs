using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DBConnect : MonoBehaviour
{
    public Text email, username, score;

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

    IEnumerator AddPlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("name", username.text);
        form.AddField("score", score.text);
        WWW www = new WWW("http://lubmir2k.mygamesonline.org/saveplayer.php", form);

        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
    }

    IEnumerator RetrievePlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
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
            score.transform.parent.GetComponent<InputField>().text = details[1];
        }
    }

    IEnumerator UpdatePlayerDetails()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email.text);
        form.AddField("name", username.text);
        form.AddField("score", score.text);
        WWW www = new WWW("http://lubmir2k.mygamesonline.org/updateplayer.php", form);

        yield return www;

        if (www.error != null)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log(www.text);
        }
    }
}
