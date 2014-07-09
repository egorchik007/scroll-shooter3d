using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class EnemySpawner : MonoBehaviour
{
    private int level;
    void Start()
    {
        level = GameController.Instance.level;

    }
}

