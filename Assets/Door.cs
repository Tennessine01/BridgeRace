using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] public int mapHolderId;

    [SerializeField] Renderer doorRenderer;
    public void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null)
        {
            if (character.currentMap != mapHolderId)
            {
                character.currentMap = mapHolderId;
                Platform_manager.Ins.MoveBrickToNextMapByColor(character.colortype, mapHolderId);
            }

        }
    }
}
