using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour {
    [SerializeField] AudioSource music;
    bool fade_out = false;

    // Start is called before the first frame update
    void Start() {
        if (GameObject.FindGameObjectsWithTag("MusicPlayer").Length > 1) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void Update() {
        if (!music.isPlaying) {
            music.Play();
            music.time = 13.3f;
            StartCoroutine(FadeIn(music, 3.0f, 0.5f));
            fade_out = false;
        }
        else if (music.time > 93f && !fade_out) {
            StartCoroutine(FadeOut(music, 3.0f, 0.02f));
            fade_out = true;
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float fade_time, float target_volume) {
        float startVolume = audioSource.volume;

        while (audioSource.volume > target_volume) {
            audioSource.volume -= startVolume * Time.deltaTime / fade_time;

            yield return null;
        }
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float fade_time, float target_volume) {
        while (audioSource.volume < target_volume) {
            audioSource.volume += 0.5f * Time.deltaTime / fade_time;

            yield return null;
        }
    }
}
