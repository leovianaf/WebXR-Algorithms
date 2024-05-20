using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckNodes : MonoBehaviour
{
    [SerializeField] private int numberOfNodes;

    private int numberOfNodesChecked = 0;
    private Dictionary<int, int> nodesInSockets = new Dictionary<int, int>();

    public UnityEvent unlock;

    public void AddNode(int nodeId, int socketId)
    {
        nodesInSockets[nodeId] = socketId;
        numberOfNodesChecked += 1;
        CheckForAllNodes();
    }

    public void RemoveNode(int nodeId)
    {
        if (nodesInSockets.ContainsKey(nodeId))
        {
            nodesInSockets.Remove(nodeId);
            numberOfNodesChecked -= 1;
        }
    }

    public void CheckForAllNodes()
    {
        if (numberOfNodesChecked == numberOfNodes && AllNodesInCorrectSockets())
        {
            unlock.Invoke();
        }
    }

    private bool AllNodesInCorrectSockets()
    {
        foreach (var pair in nodesInSockets)
        {
            if (pair.Key != pair.Value)
            {
                return false;
            }
        }
        return true;
    }

    public void ResetNodes()
    {
        nodesInSockets.Clear();
        numberOfNodesChecked = 0;
    }
}
