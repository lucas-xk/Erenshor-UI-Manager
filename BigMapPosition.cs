using BepInEx;
using UnityEngine;
using System.Reflection;

[BepInPlugin("lucasxk.erenshor.bigmapposition", "BigMap Position", "1.0.0")]
public class BigMapPosition : BaseUnityPlugin
{
    private Vector3 desiredBigMapPos = new Vector3(-100f, 120f, 0f);

    private void Update()
    {        
        var minimap = UnityEngine.Object.FindObjectOfType<Minimap>();
        if (minimap == null)
            return;
                
        var bigMapField = typeof(Minimap).GetField("bigMap", BindingFlags.Instance | BindingFlags.NonPublic);
        if (bigMapField == null)
            return;

        bool isBigMap = (bool)bigMapField.GetValue(minimap);

        if (isBigMap)
        {            
            minimap.MapPar.localPosition = desiredBigMapPos;
        }
    }
}