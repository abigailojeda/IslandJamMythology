using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {
    // Creamos una variable est�tica para almacenar la �nica instancia
    public static Scene instance;

    // M�todo Awake que se llama al inicio antes de que se active el objeto. �til para inicializar
    // variables u objetos que ser�n llamados por otros scripts (game managers, clases singleton, etc).
    private void Awake() {
        // ----------------------------------------------------------------
        // COMPORTAMIENTO DE LA CLASE SINGLETON (Garantizamos �nica existencia de instancia del Scene.sc
        // Si no hay instancia, se asigna la actual. Si la hay, destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------
        // Evita destruir el objeto en cambio de escena
        DontDestroyOnLoad(gameObject);
    }

    // M�todo para cargar una nueva escena por nombre
    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
