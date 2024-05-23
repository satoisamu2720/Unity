using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;
    public GameObject goal;
    public GameObject coin;
    public TextMeshProUGUI scoreText;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        int[,] mapA =
        {
            {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,1,1,1,0,0,0, 0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,3,0,0,0,0, 0,0,0,0,0,0,0,2,0,1},
            {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,3,0,0,0,0,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0, 0,3,0,0,1,1,1,0,0,0, 1,1,1,0,0,0,0,0,0,0, 1,1,1,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,3,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,1,1,1, 0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0, 1,1,1,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,1,1,1,0,0, 0,0,0,0,0,0,0,1,1,1, 0,0,0,0,1,1,1,0,0,0, 0,0,0,0,0,0,0,0,0,1},
            {1,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,0, 0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},

        };
        Vector3 positionA = Vector3.zero;

        int lenYA = mapA.GetLength(0);
        int lenXA = mapA.GetLength(1);
        for (int x = 0; x < 40; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                positionA.x = x;
                positionA.y = -y + 5;
                //ブロック
                if (mapA[y, x] == 1)
                {
                    Instantiate(block, positionA, Quaternion.identity);
                }
                //ゴール
                if (mapA[y, x] == 2)
                {
                    Instantiate(goal, positionA, Quaternion.identity);
                }
                //コイン
                if (mapA[y, x] == 3)
                {
                    Instantiate(coin, positionA, Quaternion.identity);
                }
            }
        }
        //int[,] mapB =
        //{
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},
        //    {1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1, 1,1,1,1,1,1,1,1,1,1},

        //};

        //Vector3 positionB = Vector3.forward;


        //int lenYB = mapB.GetLength(0);
        //int lenXB = mapB.GetLength(1);

        //for (int x = 0; x < 40; x++)
        //{
        //    for (int y = 0; y < 10; y++)
        //    {
        //        positionB.x = x;
        //        positionB.y = -y + 5;
        //        //ブロック
        //        if (mapB[y, x] == 1)
        //        {
        //            Instantiate(block, positionB, Quaternion.identity);
        //        }

        //    }
        //}

    }
    // Update is called once per frame
    void Update()
    {
       if(GoalScript.isGameClear == true )
        {
            if (Input.GetKeyDown(KeyCode.Space) )
            {
                SceneManager.LoadScene("TitleScene");
            }
        }
        scoreText.text = "SCORE " + score  ;
    }
}

internal struct NewStruct
{
    public int Item1;
    public int Item2;
    public int Item3;

    public NewStruct(int item1, int item2, int item3)
    {
        Item1 = item1;
        Item2 = item2;
        Item3 = item3;
    }

    public override bool Equals(object obj)
    {
        return obj is NewStruct other &&
               Item1 == other.Item1 &&
               Item2 == other.Item2 &&
               Item3 == other.Item3;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Item1, Item2, Item3);
    }

    public void Deconstruct(out int item1, out int item2, out int item3)
    {
        item1 = Item1;
        item2 = Item2;
        item3 = Item3;
    }

    public static implicit operator (int, int, int)(NewStruct value)
    {
        return (value.Item1, value.Item2, value.Item3);
    }

    public static implicit operator NewStruct((int, int, int) value)
    {
        return new NewStruct(value.Item1, value.Item2, value.Item3);
    }
}