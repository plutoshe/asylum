using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GuiEventConstant
{
    public static string s_IdentityChange = "ChangeIdentityUI";
    public static string s_PlayerPlaying = "PlayerPlaying";
    public static string s_OpenExamine = "OpenExamine";
    public static string s_CloseExamine = "CloseExamine";
    public static string s_DialogDemonstration = "DialogDemonstration";
    public static string s_DialogClose = "DialogClose";
    public static string s_GameOver = "GameOver";

}

public static class CustomEventConstant
{
    public static string s_ToDayTime = "ToDayTime";
    public static string s_ToNight = "ToNight";
}

public static class CameraEventConstant
{
    public static string s_ChangeToSubCamera = "ChangeToSubCamaera";
    public static string s_BackToParentCamera = "BackToParentCamera";
}
