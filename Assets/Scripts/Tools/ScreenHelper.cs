using UnityEngine;

public static class ScreenHelper
{
    public static Vector3 GetUpperViewportInWorldSpace(Camera camera)
    {
        if (camera == null)
            return Vector2.zero;

        return camera.ViewportToWorldPoint(new Vector3(1, 1, 10));
    }

    public static Vector3 GetLowerViewportInWorldSpace(Camera camera)
    {
        if (camera == null)
            return Vector2.zero;

        return camera.ViewportToWorldPoint(new Vector3(0, 0, 10));
    }

    public static bool IsInsideBounds(Vector2 worldPos, Camera camera)
    {
        Vector3 top = GetUpperViewportInWorldSpace(camera);
        Vector3 bottom = GetUpperViewportInWorldSpace(camera);

        if (worldPos.x <= top.x && worldPos.x >= bottom.x && worldPos.y <= top.y && worldPos.y >= bottom.y)
            return true;

        return false;
    }

    public static bool IsPointingLeftScreen(Vector3 screenPosition, float percentageOfLeftScreen)
    {
        float screenWidth = Screen.width;
        screenWidth = (screenWidth / 100) * percentageOfLeftScreen;

        if (screenPosition.x <= screenWidth)
            return true;

        return false;
    }

    public static bool IsPointingRightScreen(Vector3 screenPosition, float percentageOfRightScreen)
    {
        float screenWidth = Screen.width;
        screenWidth = Screen.width - ((screenWidth / 100) * percentageOfRightScreen);

        if (screenPosition.x >= screenWidth)
            return true;

        return false;
    }

    public static bool IsPointingInCenterScreen(Vector3 screenPosition, float percentageOfCenterScreen)
    {
        float screenWidth = Screen.width;
        screenWidth = (screenWidth / 100) * percentageOfCenterScreen;

        float centerWidth = screenWidth / 2;

        float leftBorder = centerWidth - screenWidth;
        float rightBorder = centerWidth + screenWidth;

        if (screenPosition.x > leftBorder && screenPosition.x < rightBorder)
            return true;
        return false;

    }
}

