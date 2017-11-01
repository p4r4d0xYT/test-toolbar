using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sidebar : MonoBehaviour
{
    public Button expandButton;
    public enum State {
        closed, open, opening, closing
    }
    public State currentState;
    public Sprite[] icons;

    public GameManager gameManager;
    Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator> ();
    }

    void Awake () {
        currentState = State.closed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ExpandMenu ()
    {
        if (currentState == State.closed) {
            anim.SetTrigger ("Open");
            expandButton.GetComponent<Image>().sprite = icons[1];
            //expandButton.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, -90f);
            currentState = State.open;
            GameManager.instance.isPaused = true;
        } else if (currentState == State.open) {
            anim.SetTrigger ("Close");
            expandButton.GetComponent<Image>().sprite = icons[0];
            //expandButton.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, 90f);
            currentState = State.closed;
            GameManager.instance.isPaused = false;
        }
    }
}
