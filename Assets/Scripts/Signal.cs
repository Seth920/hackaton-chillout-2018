using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signal: MonoBehaviour {

    public int signalStage = 0;
    public List<Sprite> signalImages;
    // Use this for initialization
    void Start() {
        Events.Instance.aerialAssembled_Event += onAerialAssembled;
    }

    private void onAerialAssembled(GameObject aerial) {
        signalStage++;
        GetComponent<Image>().sprite = signalImages[signalStage];
        StartCoroutine(Fade());

        if (signalStage == 4) {
            Events.Instance.allAerialsAssembled_Event.Invoke();
        }
    }

    IEnumerator Fade() {
        for (float f = 6f; f >= 0; f -= 1f) {
            var image = GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = (f % 2) == 0 ? 1f : 0f;
            image.color = tempColor;
            yield return new WaitForSeconds(.5f);
        }
    }
}
