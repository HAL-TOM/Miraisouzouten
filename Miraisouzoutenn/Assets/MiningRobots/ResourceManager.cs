using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public MiningRobots mining_robots;
    public int ResouceAll;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ResouceAll = mining_robots.GetResource();
    }
}
