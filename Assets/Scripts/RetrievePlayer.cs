using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrievePlayer : MonoBehaviour
{
    // Operates the button, therefore has to be public
    public void GetDetails()
    {
        StartCoroutine(RetrievePlayerDetails());
    }

    IEnumerator RetrievePlayerDetails()
    {
        WWWForm form = new WWWForm();
        WWW www = new WWW("http://lubmir2k.mygamesonline.org/getplayers.php", form);

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
