using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniLevelManager : MonoBehaviour {

    public int whichLevel;
    public SpriteRenderer presenceSprite;
    public SpriteRenderer validatingSprite;
    bool playerIn;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            presenceSprite.color = new Color(1, 1, 1, .2f);
            playerIn = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            presenceSprite.color = new Color(1, 1, 1, 0);
            validatingSprite.color = new Color(1, 1, 1, 0);
            playerIn = false;
        }
    }

    private void Update()
    {
        CheckInput();
    }

    void CheckInput()
    {
        if (Input.GetKey(KeyCode.X))
        {
            if (playerIn)
            {
                Color newColor = validatingSprite.color;
                newColor.a = Mathf.Clamp01(newColor.a + 0.02f);
                validatingSprite.color = newColor;
                if (newColor.a >= 1)
                {
                    StartCoroutine(SelectLevelLoadAsync());
                }
            }
        }
        else if (playerIn)
        {
            Color newColor = validatingSprite.color;
            newColor.a = Mathf.Clamp01(newColor.a - 0.02f);
            validatingSprite.color = newColor;
        }

    }

    IEnumerator SelectLevelLoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(whichLevel);

        while (!asyncLoad.isDone)
        {
            print(asyncLoad.progress);
            yield return null;
        }
    }
}
