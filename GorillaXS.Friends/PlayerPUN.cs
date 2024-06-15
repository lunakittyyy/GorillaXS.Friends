using GorillaNetworking;
using GorillaXS.Friends.Utils;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

namespace GorillaXS.Friends
{
    internal class PlayerPUN : MonoBehaviourPunCallbacks
    {
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            if (FriendUtil.IsFriend(newPlayer.UserId))
            {
                Notifier.Notify("Friend Join", $"Your friend {newPlayer.NickName} joined the room", timeout: 1.5f);
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            if (FriendUtil.IsFriend(otherPlayer.UserId))
            {
                Notifier.Notify("Friend Leave", $"Your friend {otherPlayer.NickName} left the room", timeout: 1.5f);
            }
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();

            Player[] friends = [.. PhotonNetwork.PlayerListOthers.Where(player => FriendUtil.IsFriend(player.UserId))];
            bool isSafety = PlayFabAuthenticator.instance.GetSafety();

            if (friends.Any()) Notifier.Notify($"Friend{(friends.Length > 1 ? "s" : "")} in room", friends.Length > 1 ? $"Your friends {string.Join(", ", friends.Select(player => isSafety ? player.DefaultName : player.NickName))} is in this room" : $"Your friend {(isSafety ? friends.First().DefaultName : friends.First().NickName)} is in this room", timeout: 1.5f);
        }
    }
}
