using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PrepareSceneController: MonoBehaviour {
    public Image frequencyImage;
    public int currentIndex;
    public List<GameObject> texts;
    public List<AudioClip> clips;
    public AudioSource audioSource;
    // Use this for initialization
    void Start() {
        StartCoroutine(ShowSequence());
    }

    IEnumerator ShowSequence() {
        yield return new WaitForSeconds(1f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(0.5f);
        yield return new WaitForSeconds(showTextWithAudio(currentIndex) + 0.5f);
        hideCurrentText();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Map");

    }

    private float showTextWithAudio(int index) {
        texts[index].SetActive(true);
        audioSource.clip = clips[index];
        audioSource.Play();
        return clips[index].length;
    }

    private void hideCurrentText() {
        texts[currentIndex].SetActive(false);
        currentIndex++;
    }

    // Update is called once per frame
    void Update() {
        frequencyImage.fillAmount = (Mathf.PerlinNoise(Time.deltaTime, Time.time) * 2) + 0.2f;
    }
}
