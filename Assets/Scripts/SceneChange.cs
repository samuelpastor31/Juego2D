using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] private string sceneName; // asegúrate de que la escena objetivo esté en la configuración de compilación

    [SerializeField] private Button btn;

    private void Start()
    {
        btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(NewGame);
            btn.onClick.AddListener(ExitGame); // Agrega el método ExitGame al evento de clic del botón
        }
    }

    public void NewGame()
    {
        if (PermanentUI.perm != null)
            PermanentUI.perm.Reset();
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeScenes()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit(); // Sale de la aplicación
    }
}

