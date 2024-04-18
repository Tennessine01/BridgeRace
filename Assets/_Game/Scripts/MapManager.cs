using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
    [SerializeField] public Transform startPosition;
    [SerializeField] public Transform winPos;

}
