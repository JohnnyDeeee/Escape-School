using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Interface : MonoBehaviour
{

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
        GameObject hint = Object.Instantiate(GameManager.pr_hint);
        hint.transform.SetParent(gameObject.transform);
        hint.transform.localPosition = new Vector2(0, 0);
        hint.transform.FindChild("Title").GetComponent<Text>().text = title;
        hint.transform.FindChild("Message").GetComponent<Text>().text = message;
        StartCoroutine(HintTimer(hint, seconds));
    }

    public IEnumerator HintTimer(GameObject hint, float seconds)
    {
        hint.SetActive(true);

        yield return new WaitForSeconds(seconds);

        hint.SetActive(false);
        Destroy(hint);
    }
}
