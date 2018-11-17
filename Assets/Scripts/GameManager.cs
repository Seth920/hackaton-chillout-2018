using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager: Singleton<GameManager> {

    private Dictionary<GameObject, bool> aerials = new Dictionary<GameObject, bool>();
    private GameObject winText;

    public void AddAerial(GameObject aerial) {
        aerials.Add(aerial, false);
    }

    private void Awake() {
        Debug.Log("Manager awake");
        Events.Instance.aerialAssembled_Event += onAerialAssembled;
        Events.Instance.allAerialsAssembled_Event += onAllAerialAssembled;
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Manager start");
        winText = GameObject.FindGameObjectWithTag("WinText");
    }

    // Update is called once per frame
    void Update() {

    }

    private void onAerialAssembled(GameObject aerial) {
        Debug.Log("Event lanczed");
    }

    private void onAllAerialAssembled() {
        winText.GetComponent<Text>().enabled = true;
        StartCoroutine(GoToWinScene());
    }

    IEnumerator GoToWinScene() {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("WinScene");
    }
}
