using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GoalScript : MonoBehaviour
{
    public GameObject gameClearText;
    public GameObject pushSpaceText;
    public static bool isGameClear = false;
    private void OnTriggerEnter(Collider other)
    {
       if (GameManagerScript.score == 4)
       {
          gameClearText.SetActive(true);
          pushSpaceText.SetActive(true);
          isGameClear = true;
       }
    }
    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
