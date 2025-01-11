using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ReflectManager : MonoBehaviour
{
    [SerializeField] private GameObject brickPrefab;
    public List<GameObject> lists = new List<GameObject>();

    private void Start()
    {
        CountBricks();
    }

    private void CountBricks()
    {
        GameObject[] bricks = GameObject.FindGameObjectsWithTag("Brick");

        Regex regex = new Regex(@"\d+$");

        for (int i = 0; i < bricks.Length; i++)
        {
            GameObject brick = bricks[i];

            Match match = regex.Match(brick.name);
            if (match.Success)
            {
                string number = match.Value;

                bool exists = false;
                for (int j = 0; j < lists.Count; j++)
                {
                    if (Regex.Match(lists[j].name, @"\d+$").Value == number)
                    {
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    lists.Add(brick);
                }
            }
        }
    }

}
