using System;
using ChessController;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public class Game
    {

        ChessGame ChessGame;

        public string WhoseMoving { get; set; }
        public string GameID { get; set; }
        public string HostID { get; set; }
        public string GuestID { get; set; }

        public Game(string hostID)
        {
            HostID = hostID;
            WhoseMoving = hostID;
            GameID = GenerateID();
            ChessGame = new ChessGame();
        }

        public string Move(Move move)
        {
            ChessGame.Move(move);
            WhoseMoving = WhoseMoving == HostID ?
                                         GuestID : HostID;
            return WhoseMoving;
        }

        public bool CheckMove(string moverID, Move move)
        {
            if(WhoseMoving != moverID)
            {
                return false;
            }
            return ChessGame.IsMoveAvailable(move);
        }

        string GenerateID()
        {
            Random random = new Random();
            return $"{GenerateSubID(random)}-{GenerateSubID(random)}-{GenerateSubID(random)}";
        }

        string GenerateSubID(Random random)
        {
            string keyPattern = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string id = "";
            for(int i = 0; i < 4; i++)
            {
                int rand = random.Next(keyPattern.Length);
                id += keyPattern[rand];
            }
            return id;
        }
    }
}
