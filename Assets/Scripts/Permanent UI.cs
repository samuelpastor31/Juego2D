using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PermanentUI : MonoBehaviour
{
    public int cherrys = 0;
    public TextMeshProUGUI gemCherry;
<<<<<<< HEAD

    public static PermanentUI perm;

    private void Start() {
=======
    public TextMeshProUGUI messageText;
    public static PermanentUI perm;
    public float timeHidden = 10f;

    private void Start() {
        messageText.gameObject.SetActive(false);
>>>>>>> d89e85f (Puerta hecha)
        DontDestroyOnLoad(gameObject);
        if(!perm) {
            perm = this;
        }
        else
            Destroy(gameObject);
    }
    public void Reset(){
        cherrys = 0;
        gemCherry.text = cherrys.ToString();
    }
<<<<<<< HEAD
=======

     public void ShowMessage(string text){
        messageText.text = text;
        messageText.gameObject.SetActive(true);
        StartCoroutine(OcultarMensaje());
    }

    IEnumerator OcultarMensaje()
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(timeHidden);

        // Disable the game object
        messageText.gameObject.SetActive(false);
    }

>>>>>>> d89e85f (Puerta hecha)
}
