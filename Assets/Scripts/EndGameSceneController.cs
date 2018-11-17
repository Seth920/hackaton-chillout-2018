using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGameSceneController: MonoBehaviour {
    public SpriteRenderer image;
    public Text text1;
    public Text text2;
    public Text text3;
    public float time = 0;

    // Use this for initialization
    void Start() {
        StartCoroutine(ShowSequence());
    }

    // Update is called once per frame
    void Update() {
        time += Time.deltaTime;
    }

    IEnumerator ShowSequence() {
        StartCoroutine(FadeImage(image, false));
        StartCoroutine(FadeText(text1, false));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeText(text1, true));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeText(text2, false));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeText(text2, true));
        yield return new WaitForSeconds(3f);
        StartCoroutine(FadeText(text3, false));
    }


    IEnumerator FadeImage(SpriteRenderer sr, bool fadeAway) {
        // fade from opaque to transparent
        if (fadeAway) {
            // loop over 1 second backwards
            for (float i = 3; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                sr.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for (float i = 0; i <= 3; i += Time.deltaTime) {
                // set color with i as alpha
                sr.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }

    IEnumerator FadeText(Text sr, bool fadeAway) {
        // fade from opaque to transparent
        if (fadeAway) {
            // loop over 1 second backwards
            for (float i = 3; i >= 0; i -= Time.deltaTime) {
                // set color with i as alpha
                sr.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else {
            // loop over 1 second
            for (float i = 0; i <= 3; i += Time.deltaTime) {
                // set color with i as alpha
                sr.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
