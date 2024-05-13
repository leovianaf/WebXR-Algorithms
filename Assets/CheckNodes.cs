using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckNodes : MonoBehaviour
{
    [SerializeField] private int numberOfNodes;

    private int numberOfNodesChecked = 0;

    public UnityEvent unlock;

    public void AddNode()
    {
        numberOfNodesChecked += 1;
        CheckForAllNodes();
    }

    public void CheckForAllNodes()
    {
        if (numberOfNodesChecked == numberOfNodes)
        {
            unlock.Invoke();
        }
    }

    public void RemoveNode()
    {
        numberOfNodesChecked -= 1;
    }

    public void ResetNodes()
    {
        numberOfNodesChecked = 0;
    }
}
