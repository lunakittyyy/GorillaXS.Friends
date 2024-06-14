using UnityEngine;

namespace GorillaXS.Friends.Utils
{
    internal class FriendUtil
    {
        public static bool IsFriend(string userId)
        {
            return PlayerPrefs.GetInt(userId + "_friend", 0) != 0;
        }
    }
}
