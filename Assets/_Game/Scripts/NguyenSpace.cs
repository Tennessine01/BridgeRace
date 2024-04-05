using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace NguyenSpace
{
    public enum ColorType
    {
        None,
        Red,
        Green,
        Blue,
        Orange
    }

    [CreateAssetMenu(menuName = "ColorData")]
    public class ColorData : ScriptableObject
    {
        //theo tha material theo dung thu tu ColorType
        [SerializeField] Material[] materials;

        //lay material theo mau tuong ung
        public Material GetMat(ColorType colorType)
        {
            return materials[(int)colorType];
        }
    }
}