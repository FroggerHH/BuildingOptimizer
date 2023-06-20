using System.Threading;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;
using static BuildingOptimizer.Plugin;
using Object = UnityEngine.Object;

namespace BuildingOptimizer;

[HarmonyPatch]
internal static class AddBuferPatch
{
    [HarmonyPatch(typeof(ZNetScene), nameof(ZNetScene.Awake)), HarmonyPostfix]
    public static void ApplyNoWetEffect(ZNetScene __instance)
    {
        var materials = Resources.FindObjectsOfTypeAll<Material>();
        foreach (var material in materials)
        {
            material.enableInstancing = true;
        }

        foreach (var prefab in __instance.m_namedPrefabs)
        {
            foreach (var renderer in prefab.Value.GetComponentsInChildren<Renderer>())
            {
                renderer.SetPropertyBlock(new());
            }
        }

        // var mPieces = __instance.GetPrefab("Hammer").GetComponent<ItemDrop>().m_itemData.m_shared.m_buildPieces
        //     .m_pieces;
        // foreach (var piece in mPieces)
        // {
        //     foreach (var renderer in piece.GetComponentsInChildren<Renderer>())
        //         renderer.SetPropertyBlock(new());
        // }
    }
}