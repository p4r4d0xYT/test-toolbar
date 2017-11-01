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
            expandButton.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, -90f);
            currentState = State.open;
        } else if (currentState == State.open) {
            anim.SetTrigger ("Close");
            expandButton.GetComponent<RectTransform> ().rotation = Quaternion.Euler (0, 0, 90f);
            currentState = State.closed;
        }
    }
}
