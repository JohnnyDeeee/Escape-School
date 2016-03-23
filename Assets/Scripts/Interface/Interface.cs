using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{
    public Inventory inventory;

    void Awake()
    {
        GameManager.Initialize();
    }

	void Start ()
    {
        StartCoroutine(temp());
	}

    private IEnumerator temp()
    {
        yield return new WaitForSeconds(2.0f);

        ShowHint("Test", "GameManager is initialized :)", 3.0f);
    }

    //Show a hint on screen for x seconds
    public void ShowHint(string title, string message, float seconds)
    {
        //Hide other hints
        foreach (GameObject oldHint in GameObject.FindGameObjectsWithTag("Hint"))
        {
            StopCoroutine("HintTimer");
            oldHint.SetActive(false);
            Destroy(oldHint);
        }

        //Create new hint
        GameObject hint = Object.Instantiate(GameManager.pr_hint);
        hint.transform.SetParent(gameObject.transform, false);
        //hint.transform.localPosition = new Vector2(0, 0);
        hint.transform.FindChild("Title").GetComponent<Text>().text = title;
        hint.transform.FindChild("Message").GetComponent<Text>().text = message;
        StartCoroutine(HintTimer(hint, seconds));
    }

    public IEnumerator HintTimer(GameObject hint, float seconds)
    {
        hint.SetActive(true);

        yield return new WaitForSeconds(seconds);

        //Check if hint is not
        //already destroyed by
        //a overlapping hint
        if (hint != null)
        {
            hint.SetActive(false);
            Destroy(hint); 
        }
    }
}
