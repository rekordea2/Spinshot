using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Extensions
{
    public static Vector2 STWP(this Vector2 screenpoint)
    {
        if (!MainCamera.maincamera)
        {
            Debug.LogError("No MainCamera found!");
            return Vector2.zero;
        }

        return MainCamera.maincamera.ScreenToWorldPoint(screenpoint);
    }

    public static Vector2 STWP(this Vector3 screenpoint)
    {
        if (!MainCamera.maincamera)
        {
            Debug.LogError("No MainCamera found!");
            return Vector2.zero;
        }
        return MainCamera.maincamera.ScreenToWorldPoint(screenpoint);
    }

    public static Vector2 WTSP(this Vector2 screenpoint)
    {
        if (!MainCamera.maincamera)
        {
            Debug.LogError("No MainCamera found!");
            return Vector2.zero;
        }

        return MainCamera.maincamera.WorldToScreenPoint(screenpoint);
    }

    public static Vector2 WTSP(this Vector3 screenpoint)
    {
        if (!MainCamera.maincamera)
        {
            Debug.LogError("No MainCamera found!");
            return Vector2.zero;
        }
        return MainCamera.maincamera.WorldToScreenPoint(screenpoint);
    }

    public static void DestroyChildren(this Transform parent)
    {
        if (!Application.isPlaying)
        {
            parent.DestroyChildrenImmediate();
            return;
        }

        foreach (Transform child in parent)
            UnityEngine.Object.Destroy(child.gameObject);
    }

    public static void DestroyChildrenImmediate(this Transform parent)
    {
        if (Application.isPlaying)
        {
            parent.DestroyChildren();
            return;
        }

        foreach (Transform child in parent)
            UnityEngine.Object.DestroyImmediate(child.gameObject);
    }

    public static T GetRandom<T>(this List<T> list) => list[Random.Range(0, list.Count)];

    public static List<T> Shuffle<T>(this List<T> list) => list.OrderBy(item => Random.value).ToList();

    public static int Mod(this int x, int y) => ((x % y) + y) % y;

    public static float ToPercent(this float floatingpoint, bool round = false) => round ? Mathf.Round(floatingpoint * 100f) : floatingpoint * 100f;

    public static int ToPercentInt(this float floatingpoint) => Mathf.RoundToInt(floatingpoint * 100f);

    public static Vector2 RandomOffset(this Vector2 vector, float offset, bool squared = false) => !squared ? new Vector2(Random.Range(vector.x - offset, vector.x + offset), Random.Range(vector.y - offset, vector.y + offset)) : new Vector2(Random.Range(vector.x - Mathf.Sqrt(offset), vector.x + Mathf.Sqrt(offset)), Random.Range(vector.y - Mathf.Sqrt(offset), vector.y + Mathf.Sqrt(offset)));

    public static Vector2 RandomOffset(this Vector3 vector, float offset, bool squared = false) => !squared ? new Vector2(Random.Range(vector.x - offset, vector.x + offset), Random.Range(vector.y - offset, vector.y + offset)) : new Vector2(Random.Range(vector.x - Mathf.Sqrt(offset), vector.x + Mathf.Sqrt(offset)), Random.Range(vector.y - Mathf.Sqrt(offset), vector.y + Mathf.Sqrt(offset)));

    public static void SetAlpha(this SpriteRenderer renderer, float alpha)
    {
        Color colori = renderer.color;
        colori.a = Mathf.Clamp01(alpha);
        renderer.color = colori;
    }


}

public static class Helpers
{

}