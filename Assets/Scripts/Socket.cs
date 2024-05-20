using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Socket : MonoBehaviour
{
    public int socketId;
    private XRSocketInteractor socket;
    private CheckNodes checkNodes;

    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        checkNodes = GetComponentInParent<CheckNodes>();
    }

    public void CheckNode()
    {
        if (socket.interactablesSelected.Count > 0)
        {
            IXRSelectInteractable selectedInteractable = socket.interactablesSelected[0];
            GameObject nodeObject = selectedInteractable.transform.gameObject;

            Node node = nodeObject.GetComponent<Node>();

            if (node != null)
            {
                if (node.CompareTag("Node"))
                {
                    if (node.nodeId == socketId)
                    {
                        Debug.Log("Node " + node.nodeId + " colocada no Socket " + socketId + ": TRUE");
                        checkNodes.AddNode(node.nodeId, socketId);
                    }
                    else
                    {
                        Debug.Log("Node " + node.nodeId + " colocada no Socket " + socketId + ": FALSE");
                        checkNodes.RemoveNode(node.nodeId);
                    }
                }
            }
            else
            {
                Debug.Log("O objeto no Socket " + socketId + " não é um Node.");
                checkNodes.RemoveNode(socketId); // Remove se não for um Node
            }
        }
        else
        {
            Debug.Log("Nenhum node está selecionado no Socket " + socketId);
            checkNodes.RemoveNode(socketId); // Remove se não houver seleção
        }
    }
}
