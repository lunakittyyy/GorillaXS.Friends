using GorillaXS;
using GorillaXS.Friends.Utils;
using Photon.Pun;
using Photon.Realtime;

namespace GorillaXS.Friends
{
    internal class PlayerPUN : MonoBehaviourPunCallbacks
    {
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            if (FriendUtil.IsFriend(newPlayer.UserId))
            {
                Notifier.Notify("Friend Join", $"Your friend {newPlayer.NickName} joined the room");
            }
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            base.OnPlayerLeftRoom(otherPlayer);
            if (FriendUtil.IsFriend(otherPlayer.UserId))
            {
                Notifier.Notify("Friend Leave", $"Your friend {otherPlayer.NickName} left the room");
            }
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            foreach (Player player in PhotonNetwork.PlayerListOthers)
            {
                if (FriendUtil.IsFriend(player.UserId))
                {
                    Notifier.Notify("Friend In Room", $"Your friend {player.NickName} is in this room");
                }
            }
        }
    }
}
