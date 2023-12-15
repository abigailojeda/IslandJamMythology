using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

    // Instancia �nica global del Script (porque es una clase Singleton) STATIC
    // Llama a "Audio.instance" para utilizarlo en otros scripts
    public static Audio instance;

    // Se le asocia dos componentes "Audio" Source para reproducir al menos dos audios a la vez
    public AudioSource musicSource;
    public AudioSource sfxSource;

    // En vez de usar un vector de AudioClips (que podr�a ser) vamos a utilizar un Diccionario
    // en el que cargaremos directamente los recursos desde la jerarqu�a del proyecto
    // Cada entrada del diccionario tiene una string como clave y un AudioClip como valor
    public Dictionary<string, AudioClip> sfxClips = new Dictionary<string, AudioClip>();
    public Dictionary<string, AudioClip> musicClips = new Dictionary<string, AudioClip>();

    private void Awake() {
        // ----------------------------------------------------------------
        // COMPORTAMIENTO DE LA CLASE SINGLETON (Garantizamos �nica exista de instancia del Audio.cs)
        // Si no hay instancia se asigna la actual. Si la hay, destruye la nueva
        if (instance == null) instance = this;
        else { Destroy(gameObject); return; }
        // ----------------------------------------------------------------
        // Evita destruir la instancia en cambio de escena
        DontDestroyOnLoad(gameObject);

        // Cargamos los AudioClips en los diccionarios (M�todos de precarga)
        LoadSFXClips();
        LoadMusicClips();
    }

    // M�todo privado para cargar los efectos de sonido directamente desde las carpetas
    private void LoadSFXClips() {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCI�N DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/SFX
        sfxClips["Button"] = Resources.Load<AudioClip>("SFX/Button");
       // sfxClips["CollectCoin"] = Resources.Load<AudioClip>("SFX/Collect_Coin");
    }

    // M�todo privado para cargar la m�sica de fondo directamente desde las carpetas
    private void LoadMusicClips() {
        // Los recursos (ASSETS) que se cargan en TIEMPO DE EJECUCI�N DEBEN ESTAR DENTRO de una carpeta denominada /Assets/Resources/Music
        musicClips["MainTheme"] = Resources.Load<AudioClip>("Music/Piano");
       // musicClips["InvincibilityTheme"] = Resources.Load<AudioClip>("Music/Invincibility_Theme");
    }

    // M�todo de la clase singleton para reproducir efectos de sonido
    public void PlaySFX(string clipName) {
        if (sfxClips.ContainsKey(clipName)) {
            sfxSource.clip = sfxClips[clipName];
            sfxSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de sfxClips.");
    }

    // M�todo de la clase singleton para reproducir m�sica de fondo
    public void PlayMusic(string clipName) {
        if (musicClips.ContainsKey(clipName)) {
            musicSource.clip = musicClips[clipName];
            musicSource.Play();
        } else Debug.LogWarning("El AudioClip " + clipName + " no se encontr� en el diccionario de musicClips.");
    
        if (clipName == "MainTheme") {
            musicSource.loop = true;
        } else { musicSource.loop = false; }
    }

}
